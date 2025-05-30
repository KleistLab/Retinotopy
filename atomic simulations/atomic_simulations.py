#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Tue Nov 12 12:20:49 2024

@author: eric
"""

import os
import numpy as np
import matplotlib as mpl
import matplotlib.pyplot as plt
from matplotlib.patches import Circle, Ellipse
plt.rcParams.update({"text.usetex": False})
COL = np.array(['c', 'g', 'r', 'y', 'tab:purple', 'tab:orange'])
COL2 = np.array(['deepskyblue', 'g', 'r', 'y', 'g', 'deepskyblue'])


def rotate_coord(x, y, angle):
    """
    angle in rad
    """
    return x*np.cos(angle) - y*np.sin(angle), x*np.sin(angle) + y*np.cos(angle)

def create_starting_grid(center_loc_x, center_loc_y):
    """
    uses the center locations of the bundles (center_loc_x, center_loc_y) and 
    adds the six receptor subtypes around them
    """
    r = 26 #32
    xrec = r * np.cos(np.arange(np.pi/6, 2*np.pi + np.pi/6, np.pi/3))
    yrec = r * np.sin(np.arange(np.pi/6, 2*np.pi + np.pi/6, np.pi/3))
    recep_x = xrec[:, None] + center_loc_x[None, :]
    recep_y = yrec[:, None] + center_loc_y[None, :]
    return recep_x, recep_y

def grad_ricker(loc, att, sigma, amp):
    '''
    implements the gradient of the Ricker wavelet aka Mexican hat potential
    loc has shape (2,M)
    '''
    if np.size(att) == 2:
        dist_squared = np.sum((loc-att)**2, axis=0)
        res = np.array([-amp*np.sign(loc[0, :] - att[0, :])*np.sqrt(dist_squared)*(-sigma**2 + dist_squared)*np.exp(-dist_squared/(2/3*sigma**2))/9/sigma**4,
                        -amp*np.sign(loc[1, :] - att[1, :])*np.sqrt(dist_squared)*(-sigma**2 + dist_squared)*np.exp(-dist_squared/(2/3*sigma**2))/9/sigma**4])
    else:
        dist_squared = np.sum((loc[:, :, None]-att[:, None, :])**2, axis=0)
        res = np.array([-amp*np.sign(loc[0, :, None] - att[0, None, :])*np.sqrt(dist_squared)*(-sigma**2 + dist_squared)*np.exp(-dist_squared/(2/3*sigma**2))/9/sigma**4,
                        -amp*np.sign(loc[1, :, None] - att[1, None, :])*np.sqrt(dist_squared)*(-sigma**2 + dist_squared)*np.exp(-dist_squared/(2/3*sigma**2))/9/sigma**4])
    return res

def grad_parabola(loc, att, rad_m, amp):
    '''
    implements the gradient of a parabola bump
    loc has shape (2,M)
    '''
    if np.size(att) == 2:
        dist = loc - att
        res = np.array([np.where(dist[0, :] > rad_m, 0, amp*2*dist[0, :]),
                        np.where(dist[1, :] > rad_m, 0, amp*2*dist[1, :])])
    else:
        dist_eucl = np.sqrt(np.sum((loc[:, :, None]-att[:, None, :])**2, axis=0))
        dist = loc[:, :, None] - att[:, None, :]
        # res = np.array([np.where(dist_eucl > rad_m, 0, amp*2*dist_eucl/rad_m * np.sign(dist[0, :, :])),
        #                 np.where(dist_eucl > rad_m, 0, amp*2*dist_eucl/rad_m * np.sign(dist[1, :, :]))])
        res = np.array([np.where((dist_eucl > 0) * (dist_eucl < rad_m), amp * np.sign(dist[0, :, :]), 0),
                        np.where((dist_eucl > 0) * (dist_eucl < rad_m), amp * np.sign(dist[1, :, :]), 0)])
    return res

def grad_gaussian(loc, att, sigma, amp):
    '''
    implements the gradient of a Gaussian bump
    loc has shape (2,M)
    '''
    if np.size(att) == 2:
        dist_squared = np.sum((loc-att)**2, axis=0)
        res = np.array([amp*np.sign(loc[0, :] - att[0, :])*np.sqrt(dist_squared)*np.exp(-dist_squared/2/sigma**2)/sigma**2,
                        amp*np.sign(loc[1, :] - att[1, :])*np.sqrt(dist_squared)*np.exp(-dist_squared/2/sigma**2)/sigma**2])
    else:
        dist_squared = np.sum((loc[:, :, None]-att[:, None, :])**2, axis=0)
        res = np.array([amp*np.sign(loc[0, :, None] - att[0, None, :])*np.sqrt(dist_squared)*np.exp(-dist_squared/2/sigma**2)/sigma**2,
                        amp*np.sign(loc[1, :, None] - att[1, None, :])*np.sqrt(dist_squared)*np.exp(-dist_squared/2/sigma**2)/sigma**2])
    return res

def calculate_potential_and_grad(x, y, x_r8, y_r8, i, ind_start, r34_start, r16_start, par):
    """
    - calculates the full potential for a given set of locations (xold, yold)
    - contains (i) the inter-bundle adhesion mediated by flamingo, R2-R5, later also R1-R2-R5-R6
              (ii) flamingo interaction of R2 and R5 with R8, to anchor the bundle in the first phase
             (iii) the intra-bundle adhesion mediated by sidekick              
              (iv) density repulsion between all receptors (important for all receptors which do not interact via sidekick and/or flamingo)
             
    """

    scaling = 1 #1.25
    # (i) inter-bundle adhesion, flamingo - only between R2s and R5s
    # (ii) connection to R8
    N = 2 * np.prod(np.shape(x)[1:]) # total number of R2+R5
    grx = np.zeros((N, N-1))
    gry = np.zeros((N, N-1))
    xf,  yf = x.reshape((6, -1)).copy(), y.reshape((6, -1)).copy()
    gradx, grady = np.zeros(np.shape(xf)), np.zeros(np.shape(yf))
    pos_eval = np.c_[np.r_[xf[1], xf[4]],
                     np.r_[yf[1], yf[4]]] # select only R2s and R5s
    pos_eval_ellip = np.c_[np.r_[xf[1], xf[4]],
                           np.r_[par['r_flamingo']*yf[1]/par['r2_flamingo'], par['r_flamingo']*yf[4]/par['r2_flamingo']]]
    pos_eval_16 = np.c_[np.r_[xf[0], xf[5]],
                        np.r_[yf[0], yf[5]]]
    
    pos_r8 = np.c_[np.r_[np.ravel(x_r8), np.ravel(x_r8)],
                   np.r_[np.ravel(y_r8), np.ravel(y_r8)]]

    pos_r8_single = np.c_[np.mean(np.c_[np.ravel(xf[1]), np.ravel(xf[4])], axis=1),
                          np.mean(np.c_[np.ravel(yf[1]), np.ravel(yf[4])], axis=1)]

    for ind in range(N):
        if i <= r34_start[int(ind%3)]:
            dists = [3, 15, 30, 33, 45, 48] # currently only works for 10 bundles per row and 3 rows, might be generalized if needed
            pos_eval_ellip_temp = pos_eval_ellip.copy()
        elif i >= r34_start[int(ind%3)] and i < r16_start[int(ind%3)]:
            dists = [3, 30, 33, 48]
            pos_eval_ellip_temp = pos_eval_ellip.copy()
        elif i >= r16_start[int(ind%3)]:
            dists = [3, 30, 33]
            pos_eval_ellip_temp = pos_eval_ellip.copy()
        else:
            print('this should never happen, ind =' + str(ind))
            dists = []
            pos_eval_ellip_temp = []

        if i > r16_start[ind%3]:
            indi = (i - r16_start[ind%3] + 1)*par['dt']/2 + 1
            sigma = par['r_flamingo'] * np.where(indi > scaling, scaling, indi)
        else:
            sigma = par['r_flamingo']

        gr1x, gr1y = np.zeros(1), np.zeros(1)
        for d in dists:
            grx1, gry1 = 0, 0
            grx2, gry2 = 0, 0
            if ind + d < N:
                grx1, gry1 = grad_ricker(np.array([pos_eval_ellip_temp[ind, :]]).T,
                                         np.array([pos_eval_ellip_temp[ind + d, :]]).T,
                                         sigma = sigma,
                                         amp = par['A_flamingo'])

            if ind - d >= 0:
                grx2, gry2 = grad_ricker(np.array([pos_eval_ellip_temp[ind, :]]).T,
                                         np.array([pos_eval_ellip_temp[ind - d, :]]).T,
                                         sigma = sigma,
                                         amp = par['A_flamingo'])

            gr1x += np.array(grx1, dtype='float') + np.array(grx2, dtype='float')
            gr1y += np.array(gry1, dtype='float') + np.array(gry2, dtype='float')

        if i >= ind_start[ind%3] and i < r34_start[ind%3]:
            gr2x, gr2y = grad_ricker(np.array([pos_eval[ind, :]]).T,
                                     np.array([pos_r8[ind, :]]).T,
                                     sigma = par['r3_flamingo'],
                                     amp = par['A2_flamingo'])
        else:
            gr2x, gr2y = np.zeros(1), np.zeros(1)

        grx[ind] = gr1x[0] + gr2x[0]
        gry[ind] = gr1y[0] + gr2y[0]

    gradx1, grady1 = np.sum(grx, axis=1).reshape((2, -1)), np.sum(gry, axis=1).reshape((2, -1))
    gradx[1, :] += gradx1[0, :]
    gradx[4, :] += gradx1[1, :]
    grady[1, :] += grady1[0, :]
    grady[4, :] += grady1[1, :]

    # late flamingo R1-R2-R5-R6
    pos_latefmg = np.r_[pos_eval, pos_eval_16].T
    for ind in range(2*N):
        if i >= r16_start[int(ind%3)]:
            indi = (i - r16_start[ind%3] + 1)*par['dt']/2 + 1
            sigma = par['r_flamingo'] * np.where(indi > scaling, scaling, indi)

            grx16_temp, gry16_temp = grad_ricker(np.array([pos_latefmg[:, ind]]).T,
                                                 np.r_[pos_eval, pos_eval_16].T,
                                                 sigma = sigma,
                                                 amp = par['A_flamingo'])
            grx16 = grx16_temp.sum(axis=1)
            gry16 = gry16_temp.sum(axis=1)
            if ind < N/2:
                gradx[0, ind] += grx16[0]
                grady[0, ind] += gry16[0]
            elif ind < N:
                gradx[1, ind-int(N/2)] += grx16[0]
                grady[1, ind-int(N/2)] += gry16[0]
            elif ind < 3*N/2:
                gradx[4, ind-int(N)] += grx16[0]
                grady[4, ind-int(N)] += gry16[0]
            else:
                gradx[5, ind-int(3*N/2)] += grx16[0]
                grady[5, ind-int(3*N/2)] += gry16[0]

    #(iii) intra-bundle adhesion, sidekick
    N2 = np.prod(np.shape(x)[1:])
    grx = np.zeros((N2, 6))
    gry = np.zeros((N2, 6))
    for ind in range(N2):
        pos_eval = np.c_[xf[:, ind], yf[:, ind]]
        for j in range(6):
            if j == 0:
                if i > r16_start[ind%3]:
                    indi = (i - r16_start[ind%3] + 1)*par['dt']/2 + 1
                    sigma = par['r_sidekick'] * np.where(indi > scaling, scaling, indi)
                else:
                    sigma = par['r_sidekick']
                gr1x, gr1y = grad_ricker(np.array([pos_eval[0, :]]).T,
                                         np.array([pos_eval[1, :]]).T,
                                         sigma = sigma,
                                         amp = par['A_sidekick'])
            elif j == 5:
                if i > r16_start[ind%3]:
                    indi = (i - r16_start[ind%3] + 1)*par['dt']/2 + 1
                    sigma = par['r_sidekick'] * np.where(indi > scaling, scaling, indi)
                else:
                    sigma = par['r_sidekick']
                gr1x, gr1y = grad_ricker(np.array([pos_eval[5, :]]).T,
                                         np.array([pos_eval[4, :]]).T,
                                         sigma = sigma,
                                         amp = par['A_sidekick'])
            else:
                if (j == 2 or j ==3) and i > r34_start[ind%3]:
                    indi = (i - r34_start[ind%3] + 1)*par['dt']/2 + 1
                    sigma = par['r_sidekick'] * np.where(indi > scaling, scaling, indi)
                else:
                    sigma = par['r_sidekick']

                gr1x, gr1y = grad_ricker(np.array([pos_eval[j, :]]).T,
                                         pos_eval[j-1:j+2:2, :].T,
                                         sigma = sigma,
                                         amp = par['A_sidekick'])
        if np.size(gr1x) == 1:
            grx[ind, j] = gr1x[0]
            gry[ind, j] = gr1y[0]
        else:
            grx[ind, j] = np.sum(gr1x, axis=1)[0]
            gry[ind, j] = np.sum(gr1y, axis=1)[0]

    gradx += grx.T
    grady += gry.T

    # additional force between bundles - usually set to zero via A_density_bundle
    # can be used to grow the lamina
    grx_r8, gry_r8 = grad_gaussian(pos_r8_single.T,
                                   pos_r8_single.T,
                                   sigma = par['r_density_bundle'],
                                   amp = par['A_density_bundle'])
    gx_r8 = np.sum(grx_r8, axis=1)
    gy_r8 = np.sum(gry_r8, axis=1)

    gradx += gx_r8[None, :]
    grady += gy_r8[None, :]

    # (iv) density kernel to not let bundles overlap even if there is no explicit force between them
    # make the heel grow after R1/6 are spawned
    for ind in range(3):
        if i > r16_start[ind]:
            indi = (i - r16_start[ind] + 1)*par['dt']/2 + 1
            sigma = par['r_density'] * np.where(indi > scaling, scaling, indi)
        else:
            sigma = par['r_density']
        gr1x, gr1y = grad_parabola(np.c_[np.ravel(xf[:, ind::3]), np.ravel(yf[:, ind::3])].T,
                                   np.c_[np.ravel(xf), np.ravel(yf)].T,
                                       rad_m = sigma,
                                       amp = par['A_density'])
        grx = np.sum(gr1x, axis=1)
        gry = np.sum(gr1y, axis=1)

        gradx[:, ind::3] += grx.reshape((6, -1))
        grady[:, ind::3] += gry.reshape((6, -1))

    # final reshape
    gradx = gradx.reshape(np.shape(x))
    grady = grady.reshape(np.shape(y))
    return gradx, grady

def random_walks(par):
    '''
    Euler-Maruyama algorithm for Ito diffusion
    '''
    print('Initialization ... ')
    axislim = [-200, 500, -100, 300]

    time = np.arange(par['t_start'][0], par['t_end'] + par['dt']/2, par['dt'])
    bundle_x = np.zeros((par['num_bundles'], par['num_rows']))
    bundle_y = np.zeros((par['num_bundles'], par['num_rows']))
    for g in range(par['num_rows']):
        scale = 75
        bundle_x[:, g] = np.r_[scale*np.arange(int(par['num_bundles']/2), dtype='float') + par['jitter'] * np.random.randn(int(par['num_bundles']/2)),
                               scale*(np.arange(int(par['num_bundles']/2), dtype='float') - 0.45) + par['jitter'] * np.random.randn(int(par['num_bundles']/2))]
        bundle_y[:, g] = np.r_[(g*scale)*np.ones(int(par['num_bundles']/2)) + par['jitter'] * np.random.randn(int(par['num_bundles']/2)),
                               (g*scale + 0.5*scale)*np.ones(int(par['num_bundles']/2)) + par['jitter'] * np.random.randn(int(par['num_bundles']/2))]
    Xrec_store, Yrec_store = create_starting_grid(np.ravel(bundle_x), np.ravel(bundle_y))
    # R8 locations
    x_r8 = np.mean(np.array([Xrec_store[1, :], Xrec_store[4, :]]), axis=0)
    y_r8 = np.mean(np.array([Yrec_store[1, :], Yrec_store[4, :]]), axis=0)
    # rotate bundles
    xrot, yrot = rotate_coord(Xrec_store - x_r8[None, :], Yrec_store - y_r8[None, :], -np.pi/6)
    Xrec_store = xrot + x_r8[None, :]
    Yrec_store = yrot + y_r8[None, :]
    Xrec_store = Xrec_store.reshape((6, par['num_bundles'], par['num_rows']))
    Yrec_store = Yrec_store.reshape((6, par['num_bundles'], par['num_rows'])) # (Rx, bundle_index, row_index)
    x_r8 = x_r8.reshape((par['num_bundles'], par['num_rows']))
    y_r8 = y_r8.reshape((par['num_bundles'], par['num_rows']))

    x = Xrec_store.copy()
    y = Yrec_store.copy()
    x[:, :, 1:] = 1e4
    x[np.array([0, 2, 3, 5]), :, 0] = 1e4

    posx = np.zeros((len(time)+1, *np.shape(x)))
    posy = np.zeros((len(time)+1, *np.shape(x)))
    posx[0, :, :, :] = x
    posy[0, :, :, :] = y

    ind_start = np.array((par['t_start'] - par['t_start'][0])/par['dt'], dtype='int')
    r34_start = np.array((par['t_start'] + par['t_34'] - par['t_start'][0])/par['dt'], dtype='int')
    r16_start = np.array((par['t_start'] + par['t_16'] - par['t_start'][0])/par['dt'], dtype='int')
    print('Starting the simulation ...')
    for i, t_i in enumerate(time):
        print(i)
        # calculate gradients
        gradx, grady = calculate_potential_and_grad(x, y, x_r8, y_r8, i, ind_start, r34_start, r16_start, par)

        # update positions
        wienerproc_x = par['sigma']*np.sqrt(par['dt'])*np.random.randn(*np.shape(gradx))
        wienerproc_y = par['sigma']*np.sqrt(par['dt'])*np.random.randn(*np.shape(gradx))
        d_x = par['sp']*gradx*par['dt'] + wienerproc_x
        d_y = par['sp']*grady*par['dt'] + wienerproc_y

        x += d_x
        y += d_y

        for j in range(par['num_rows']):
            # check starting points for other rows
            # make rows visible if the time is right
            if j > 0 and i == ind_start[j]:
                x[1, :, j] = Xrec_store[1, :, j].copy()
                x[4, :, j] = Xrec_store[4, :, j].copy()
                y[1, :, j] = Yrec_store[1, :, j].copy()
                y[4, :, j] = Yrec_store[4, :, j].copy()

            # add R3-R4
            if i == r34_start[j]:
                x[2, :, j] = Xrec_store[2, :, j].copy()
                x[3, :, j] = Xrec_store[3, :, j].copy()
                y[2, :, j] = Yrec_store[2, :, j].copy()
                y[3, :, j] = Yrec_store[3, :, j].copy()

            # add R1-R6
            if i == r16_start[j]:
                x[0, :, j] = Xrec_store[0, :, j].copy()
                x[5, :, j] = Xrec_store[5, :, j].copy()
                y[0, :, j] = Yrec_store[0, :, j].copy()
                y[5, :, j] = Yrec_store[5, :, j].copy()

        # append to arrays
        posx[i+1, :, :, :] = x.copy()
        posy[i+1, :, :, :] = y.copy()

        print('Simulated time: ' + str(np.round(t_i, 0)) + ' hAPF \n'\
              if t_i%1 < par['dt'] else '', end='')

        fig, ax = plt.subplots(2, 1, figsize=(12, 10), gridspec_kw={'height_ratios': [1, 20]})
        ax[0].barh([1], [par['t_end']], color='w', edgecolor='k', height=0.3)
        ax[0].barh([1], [t_i], color='k', height=0.3)
        ax[0].set_title('Developmental time (hAPF)')
        ax[0].tick_params(axis='y', which='both', right=False,
                          left=False, labelleft=False)
        ax[0].set_xticks(np.arange(par['t_start'][0], par['t_end']+1, 1))
        for pos in ['right', 'top', 'bottom', 'left']:
            ax[0].spines[pos].set_visible(False)
        ax[0].set_xlim([par['t_start'][0]-0.01, par['t_end']+0.1])

        for nn in range(par['num_bundles']):
            for j in range(par['num_rows']):
                for k in range(6):
                    if k == 2 or k == 3:
                        # uncomment if you want the see the trajectory of heels over time
                        None #ax[1].plot(posx[r34_start[j]+1:i+2, k, nn, j], posy[r34_start[j]+1:i+2, k, nn, j], color=COL[k])
                    elif k == 0 or k == 5:
                        None #ax[1].plot(posx[r16_start[j]+1:i+2, k, nn, j], posy[r16_start[j]+1:i+2, k, nn, j], color=COL[k])
                    else:
                        # ax[1].plot(posx[ind_start[j]+1:i+2, k, nn, j], posy[ind_start[j]+1:i+2, k, nn, j], color=COL[k])
                        if par['A_flamingo'] > 0:
                            ax[1].add_patch(Ellipse((x[k, nn, j], y[k, nn, j]), 2*par['r_flamingo'], 2*par['r2_flamingo'], ls = '--', edgecolor='b', facecolor='none', alpha=0.1)) #, alpha=par['A_flamingo']))
                    if par['A_sidekick'] > 0:
                       ax[1].add_patch(Circle((x[k, nn, j], y[k, nn, j]), par['r_sidekick'], ls = '--', edgecolor='k', facecolor='none', alpha=0.1)) #, alpha=par['A_sidekick']))
                    if k < 5 and x[k, nn, j] < 5000 and x[k+1, nn, j] < 5000:
                        ax[1].plot([x[k, nn, j], x[k+1, nn, j]], [y[k, nn, j], y[k+1, nn, j]], 'k--')
                    if k == 1:
                        ax[1].plot([x[1, nn, j], x[4, nn, j]], [y[1, nn, j], y[4, nn, j]], 'k')
                if par['A2_flamingo'] > 0:
                    ax[1].add_patch(Circle((x_r8[nn, j], y_r8[nn, j]), par['r3_flamingo'], ls = '--', edgecolor='k', facecolor='none', alpha=0.3)) #, alpha=par['A_sidekick']))
        for k in range(6):
            for j in range(par['num_rows']):
                if (k == 2 or k==3) and i >= r34_start[j] and i < r34_start[j] + 1/par['dt']:
                    ax[1].scatter(x[k, :, j], y[k, :, j], s=50, c=COL2[k], zorder=5, alpha=(i-r34_start[j])*par['dt'])
                elif (k == 0 or k == 5) and i >= r16_start[j] and i < r16_start[j] + 1/par['dt']:
                    ax[1].scatter(x[k, :, j], y[k, :, j], s=50, c=COL2[k], zorder=5, alpha=(i-r16_start[j])*par['dt'])
                elif (k == 1 or k == 4) and i >= ind_start[j] and i < ind_start[j] + 1/par['dt']:
                    ax[1].scatter(x[k, :, j], y[k, :, j], s=50, c=COL2[k], zorder=5, alpha=(i-ind_start[j])*par['dt'])
                else:
                    ax[1].scatter(x[k, :, j], y[k, :, j], s=50, c=COL2[k], zorder=5)

        for j in range(par['num_rows']):
            if i >= ind_start[j] - 1/par['dt'] and i < ind_start[j]: # fade in
                ax[1].scatter(x_r8[:, j], y_r8[:, j], c='k', alpha = (i-ind_start[j]+1/par['dt'])*par['dt'])
            elif i >= ind_start[j] and i < r34_start[j]: # solid black dot
                ax[1].scatter(x_r8[:, j], y_r8[:, j], c='k')
            elif i >= r34_start[j] and i < r34_start[j] + 1/par['dt']: # fade out
                ax[1].scatter(x_r8[:, j], y_r8[:, j], c='k', alpha = 1 - (i-r34_start[j])*par['dt'])

        ax[1].axis(axislim)
        ax[1].set_aspect('equal')

        props = dict(facecolor='none', edgecolor='black')
        string = ''
        for k in par.keys():
            string += (k + ' = ' + str(par[k]) + '\n')
        ax[1].text(-270, -100, string, fontsize=10,
        horizontalalignment='right', verticalalignment='bottom', bbox=props)

        fig.tight_layout()

        filename = str('%04d' % (i)) + '.png'
        fig.savefig(OUTDIR + filename, dpi=100)
        plt.close(fig)
        
    print('Simulation finished ...')
    command = ('mencoder',
               'mf://*.png',
               '-mf',
               'type=png:w=800:h=600:fps=10',
               '-ovc',
               'lavc',
               '-lavcopts',
               'vcodec=mpeg4',
               '-oac',
               'copy',
               '-o',
               'lamina_grid_mhpotentials.mp4')
    
    os.chdir(OUTDIR)
    os.spawnvp(os.P_WAIT, 'mencoder', command)
    # for file in glob.glob("*.png"):
    #     os.remove(file)
    
    angles_R25 = np.arctan2(posy[:, 1, :, :] - posy[:, 4, :, :], posx[:, 1, :, :] - posx[:, 4, :, :])
    
    return angles_R25, posx, posy


if __name__ == '__main__':
    mpl.use('Agg') # do not show figures while creating movie
    r_all = 36
    PARAMS = {
            'num_bundles': 10,
            'num_rows': 3,
            't_start': np.array([10, 12, 14]),
            't_34': 2, # i.e. 2 hours after t_start
            't_16': 4,
            't_end': 22,
            'dt': 0.01,
            'sigma': 0, # currently no noise, can be added if needed
            'sp': 1,
            'A_density': 100,
            'r_density': 0.4*r_all,
            'A_density_bundle': 0,
            'r_density_bundle': 75,
            'A_sidekick': 1000,
            'A_flamingo': 100,
            'A2_flamingo': 10000,
            'r_sidekick': r_all,
            'r_flamingo': r_all, # long axis ellipse R2-R5, we currently use circles, so both ellipse axes are the same 
            'r2_flamingo': r_all, # short axis ellipse R2-R5
            'r3_flamingo': 26, # for R8
            'jitter': 0,
            'anchor': False}
    
    if PARAMS['A_sidekick'] + PARAMS['A_flamingo'] == 0:
        OUTDIR = '/home/eric/lamina_arrangement/movie/no_forces/'
    elif PARAMS['A_sidekick'] == 0:
        OUTDIR = '/home/eric/lamina_arrangement/movie/no_sidekick/'
    elif PARAMS['A_flamingo'] == 0:
        OUTDIR = '/home/eric/lamina_arrangement/movie/no_flamingo/'
    else:
        OUTDIR = '/home/eric/lamina_arrangement/movie/WT/'
    
    ANGLES_R25, _, _ = random_walks(PARAMS)    
    mpl.use('qt5agg')
    
