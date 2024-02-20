using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveW;
    private float moveA;
    private KeyCode jumpKey = KeyCode.W;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = 3f;
        jumpForce = 65f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveW = 0f;
        moveA = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveW = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveW = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveA = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveA = 1f;
        }

        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveA, moveW);
        rb2d.velocity = new Vector2(movement.x * moveSpeed, rb2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}

