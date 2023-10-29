using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject player;
    public GameObject direction;
    public float offset = 8;
    void Update()
    {
        transform.position = (direction.transform.position - player.transform.position).normalized * offset + player.transform.position;
    }
}
