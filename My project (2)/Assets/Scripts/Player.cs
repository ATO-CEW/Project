using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public float speed2;
    public float speed3;
    private bool grounded;
    private float horizontalInput;
    //private bool jump;
    public GameObject manager;
    public GameObject doll;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 6;
        speed2 = 9;
        speed3 = 1;
        grounded = false;
        //jump = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput*speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rb.velocity= new Vector2(rb.velocity.x, speed);
            grounded = false;
        }
        if (horizontalInput > 0) { transform.localScale = new Vector3(1, 1, 1); }
        else if (horizontalInput < 0) { transform.localScale = new Vector3(-1, 1, 1); }
        //Debug.Log(grounded);
        anim.SetBool("Walking", horizontalInput != 0);
        anim.SetBool("Grounded", grounded);
        //anim.SetBool("Jump", jump);

        if (transform.position.y < -10) {
            manager.GetComponent<Manager>().Restart();

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
        if (collision.gameObject.tag == "Doll") {
            collision.gameObject.SetActive(false);
            rb.velocity = new Vector2(rb.velocity.x, speed3);
            grounded = true;
        }
        if (collision.gameObject.tag == "Broom")
        {
            collision.gameObject.SetActive(false);
            rb.velocity = new Vector2(rb.velocity.x, speed2);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flag") {
            manager.GetComponent<Manager>().Win();
        }

        if (collision.gameObject.tag == "Poison")
        {
            manager.GetComponent<Manager>().Restart();
        }
        if (collision.gameObject.tag == "Diamond")
        {
            collision.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint();
        }
    }


}
