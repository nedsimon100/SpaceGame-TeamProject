using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveX;
    private float moveY;
    public float Speed = 200;
    public GameObject trailProvider;
    public GameObject Manager;

    private void Awake()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
        Manager.GetComponent<SceneChangeManager>().Player = this.gameObject;
        trailProvider.SetActive(false);
    }
    void Update()
    {
        getInputs();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        transform.Rotate(new Vector3(0, 0, -moveX));

        rb.AddForce(transform.up * moveY * Speed);

    }
    public void getInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.UpArrow) == true|| Input.GetKey(KeyCode.W) == true)
        {
            Time.timeScale = 1f;
            trailProvider.SetActive(true);
        }
        //if (Input.GetKey(KeyCode.Space) == true)
        //{
        //    Time.timeScale = 10f;
        //}
        //
        //else
        //{
        //    Time.timeScale = 1f;
        //}
    }

}
