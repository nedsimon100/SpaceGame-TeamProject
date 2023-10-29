using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    const float G = 6.67408f;
    public GameObject player;
    public Rigidbody2D rb;
    public GameObject Manager;
    private void Awake()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        if(Manager.GetComponent<SceneChangeManager>().lastPlanet == this.gameObject.name)
        {
            Manager.GetComponent<SceneChangeManager>().spawnPlanet = this.gameObject;
        }
    }
    void Update()
    {
        Attraction();


    }
    void Attraction()
    {
        Rigidbody2D rbToAttract = player.GetComponent<PlayerController>().rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
