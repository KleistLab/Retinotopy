using UnityEngine;

//from Sina Glöckner
public class Growth : MonoBehaviour
{
    public float maxRadius = 1.0f;
    public float growthFactor = 0.001f;

    protected virtual void FixedUpdate()
    {
        transform.localScale = GrowthFun(transform.localScale);
        
        if (gameObject.transform.localScale[0] >= maxRadius) {
            // scaleChange = new Vector3(0.0f, 0.0f, 0.0f);
            // state = true;
            //Debug.Log(gameObject.name+ " has fully grown.");
            this.enabled = false;
        }

    }

    protected Vector3 GrowthFun(Vector3 former_dimensions) => former_dimensions + Vector3.one * growthFactor;
    protected float GrowthFun(float former_radius) => former_radius + growthFactor;
}
