using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerGround : MonoBehaviour
{
    Vector2 boxExtents;
    Animator animator;
    Rigidbody2D rigidBody;
    public float speed = 5.0f;
    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;
    string curLevel;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
        curLevel = SceneManager.GetActiveScene().name;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody.velocity.x * transform.localScale.x < 0.0f)
            transform.localScale = new Vector3(-transform.localScale.x,
           transform.localScale.y, transform.localScale.z);
    }
    void FixedUpdate()
    {
        
        float h = Input.GetAxis("Horizontal");
        // check if we are on the ground
        Vector2 bottom =
        new Vector2(transform.position.x, transform.position.y - boxExtents.y);

        Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

        RaycastHit2D result = Physics2D.BoxCast(bottom, hitBoxSize, 0.0f,
        new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));

        bool grounded = result.collider != null && result.normal.y > 0.9f;
        if (grounded)
        {
            if (Input.GetAxis("Jump") > 0.0f)
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            else
                rigidBody.velocity = new Vector2(speed * h, rigidBody.velocity.y);
        }
        else
        {
            // allow a small amount of movement in the air
            float vx = rigidBody.velocity.x;
            if (h * vx < airControlMax)
                rigidBody.AddForce(new Vector2(h * airControlForce, 0));
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "DeathZone")
        {
            StartCoroutine(DoDeath());
            //SceneManager.LoadScene(0);
            //Spawn();
        }

        if (collision.gameObject.tag == "Victory")
        {
            // hide the level end object
            collision.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }

    }

    IEnumerator DoDeath()
    {
        // freeze the rigidbody
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        // hide the player
        GetComponent<Renderer>().enabled = false;
        // reload the level in 2 seconds
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(curLevel);
    }
}