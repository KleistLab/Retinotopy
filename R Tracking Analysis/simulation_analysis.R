library(tidyverse)
library(magrittr)
library(ggplot2)
library(viridis)
library(plotly)
library(ggh4x)



#replace file names for other analyses
files <-list.files(path= "./healthy half", pattern = "test")

data<-read.delim(paste("./healthy half/",files[1], sep = ""), header = FALSE, sep= " ")
tracking_dat<-data[,1:4]
tracking_dat$V3<-sub("\\(","",tracking_dat$V3,perl = TRUE)
tracking_dat$V3<-sub("\\,","",tracking_dat$V3,perl = TRUE)%>%
  as.numeric()
tracking_dat$V4<-sub("\\,","",tracking_dat$V4,perl = TRUE)%>%
  as.numeric()
time<-as.numeric(length(tracking_dat$V4))
condition<-rep((substr(files[1], start = (nchar(files[1])-6), stop = (nchar(files[1])-4))),each=time)
tracking_dat <- cbind(tracking_dat, condition)
#make for loop to read file, clean and attach

for (i in 2:length(files)) {
  print(files[i])
  data<-read.delim(paste("./healthy half/",files[i], sep = ""), header = FALSE, sep= " ")
  data<-data[,1:4]
  data$V3<-sub("\\(","",data$V3,perl = TRUE)
  data$V3<-sub("\\,","",data$V3,perl = TRUE)%>%
    as.numeric()
  data$V4<-sub("\\,","",data$V4,perl = TRUE)%>%
    as.numeric()
  time<-as.numeric(length(data$V4))
  condition<-rep((substr(files[i], start = (nchar(files[i])-6), stop = (nchar(files[i])-4))),each=time)
  data <- cbind(data, condition)
  tracking_dat<-rbind(tracking_dat,data)
}


tracking_dat$row<- substr(tracking_dat$V1,0,1) #first symbol
tracking_dat$pos<- substr(tracking_dat$V1,4,4) #last symbol
tracking_dat$bundle<- paste(substr(tracking_dat$V1,0,1),substr(tracking_dat$V1,4,4), sep ="" ) 

tracking_dat<-tracking_dat[tracking_dat$V2 == 'R2'| tracking_dat$V2 == 'R5'|tracking_dat$V2 == 'R1'|tracking_dat$V2 == 'R6'|tracking_dat$V2 == 'R3'|tracking_dat$V2 == 'R4', ]

####plot all

ggplot(tracking_dat, aes(x=V3, y=V4,color=V2)) +
  geom_point(size=8,alpha = .1)+
  stat_ellipse(geom = "polygon",aes(group=V1,color=V2,fill=V2),alpha = 0.25, type = "euclid")+ 
  scale_color_manual(values=c('deepskyblue','green', 'red','yellow', 'green','deepskyblue', 'black'))+ 
  scale_fill_manual(values=c('deepskyblue','green', 'red','yellow', 'green','deepskyblue', 'black'))+ 
  labs(x = "X coordinate",y = "Y coordinate", color= "heel", fill = "heel")+
  theme_bw()


###plot r2r5

r2r5<-tracking_dat[tracking_dat$V2 == 'R2'| tracking_dat$V2 == 'R5', ]

ggplot(r2r5, aes(x=V3, y=V4,color=V2)) +
  geom_point(size=8,alpha = .009)+
  stat_ellipse(geom = "polygon",aes(group=V1,color=V2,fill=V2),alpha = 0.5, type = "euclid")+ 
  scale_color_manual(values=c('green',  'green'))+ 
  scale_fill_manual(values=c('green',  'green'))+ 
  labs(x = "X coordinate",y = "Y coordinate", color= "heel", fill = "heel")+theme_bw()



heels<-unique(tracking_dat$V1)
data_sd = data.frame()

for (h in heels) {
  
  all_h<-tracking_dat[tracking_dat$V1 == h, ]
  meanx<-all_h$V3%>%
    mean()
  meany<-all_h$V4%>%
    mean()
  sumx<-0
  sumy<-0
  for (i in 1:nrow(all_h)) {
    row <- all_h[i,]
    sumx<- sumx +(row$V3-meanx)^2
    sumy<- sumy +(row$V4-meany)^2
    
  }
  
  res<-(sumx+sumy)/nrow(all_h)
  sdd<- sqrt(res)
  
  row<-substr(h,1,1)
  heel<-substr(h,2,3)
  bund<-substr(h,4,4)
  data_sd <- rbind(data_sd, c(h,heel, bund,row,sdd))
  
}

###sd per row
colnames(data_sd)<-c("type","heel","bund","row","sd")
data_sd$sd<-as.numeric(data_sd$sd)

# ###sd per heel
funky<-strip_themed(background_x = elem_list_rect(fill = c('deepskyblue','green', 'red','yellow', 'green','deepskyblue', "#323232")))


### average sd  √ (s12 +  s22 + … + sk2) / k

#average per type per row
utype<-unique(data_sd$heel)
av_sd <-data.frame()
for (i in 0:max(data_sd$row)){
  print(i)
  for (h in utype)
  {print(h)
    temp_s<-(sum(data_sd[data_sd$heel == h & data_sd$row == i , "sd" ])/(length(data_sd[data_sd$heel == h& data_sd$row == i, "sd" ])))
    temp_av <-sqrt(temp_s)
    av_sd<- rbind(av_sd, c(h,i,temp_av))
    
  } 
  
  
  
}
colnames(av_sd)<-c("heel","row","sd")
av_sd$sd<-as.numeric(av_sd$sd)


ggplot(av_sd,aes(x=row, y=sd))+
  geom_col(aes(fill=heel),position = position_dodge()) +
  geom_smooth(method = "lm",aes(as.numeric(row), sd),se=F,position = position_nudge(x = 1), linewidth =2)+
  scale_fill_manual(values=c('deepskyblue','green', 'red','yellow', 'green','deepskyblue', 'black'))+
  ylim(0,4)+labs(x = "Differential row",y = " Av. Standard Distance Deviation", fill = "heel")+
  theme_bw()


ggplot(av_sd,aes(x=row, y=sd)) +
  geom_col()+
  facet_grid2(.~heel,strip = funky )+
  geom_smooth(method = "lm",aes(as.numeric(row), sd),se=F,position = position_nudge(x = 1,y=0), linewidth =2)  +
  scale_fill_manual(values=c("#323232","#454545","#595959","#7F7F7F", "#A5A5A5","#CCCCCC"))+
  ylim(0, 4)+labs(x = "Differential row",y = " Av. Standard Distance Deviation")+
  theme_bw()



