using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    public bool grounded;

    private Rigidbody2D rb2d;
    private Animator animator;    

    void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
	}
	
	void Update ()
    {
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }

        if(Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        if(Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * h);

        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }
}
