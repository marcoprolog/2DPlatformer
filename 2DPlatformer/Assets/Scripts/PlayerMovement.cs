using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 25;
    public float maxSpeed = 10;
    float moveInput = 0;
    public float jumpForce = 10;
    public bool isGrounded = false;
    bool jump = false;
    public GameObject groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        RaycastHit2D hit = Physics2D.Linecast(transform.position, groundCheck.transform.position, groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
            rb.AddForce(Vector2.right * moveInput * speed);

        if (jump)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            jump = false;
        }
    }
}
