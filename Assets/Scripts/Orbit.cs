using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private float DistScale = 0.1f;
    private float LocalScaleMult = 1f;
    private float speedMultiplier = 0.001f;
    public float yearLength;
    public GameObject centerOfMass;
    public float OrbitRadius;
    public float Radius;

    private void Awake()
    {
        transform.localScale = new Vector2(Radius * 2 * LocalScaleMult, Radius * 2 * LocalScaleMult);
        if (centerOfMass != this.gameObject)
        {
            OrbitRadius = (DistScale * OrbitRadius) + centerOfMass.transform.localScale.x / 2;
        }
        
        transform.position =  new Vector2(centerOfMass.transform.position.x + (-Mathf.Pow(OrbitRadius, 2) / 2), centerOfMass.transform.position.y + (Mathf.Pow(OrbitRadius, 2) / 2));
        transform.RotateAround(centerOfMass.transform.position, new Vector3(0, 0, -1), Random.Range(0f,360f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject != centerOfMass)
        {
            transform.RotateAround(centerOfMass.transform.position, new Vector3(0, 0, -1), (360 / yearLength) * speedMultiplier);

        }
        
    }
}
