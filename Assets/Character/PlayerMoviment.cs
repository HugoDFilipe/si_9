using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    private float horizontal;
    private float speed = 4f;
    private float jumpingpower = 10f;
    private bool isfacingright = true;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius=0.2f, coyoteTimer = 0.1f;
    private bool isGrounded=false;




    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y >0f)
        {            
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
        CheckGrounded();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void CheckGrounded()
    {
        if(Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            Invoke("NotGrounded", coyoteTimer);
        }
    }

    private void NotGrounded()
    {
        isGrounded = false;
    }

    private void Flip()
    {
        if(isfacingright && horizontal <0f  || !isfacingright && horizontal > 0f)
        {
            isfacingright = !isfacingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundcheck.position, groundCheckRadius);
    }
}
