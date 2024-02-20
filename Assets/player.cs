using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player: MonoBehaviour
{
    private Rigidbody2D rb2d;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveU;
    private float moveH;
    private KeyCode jumpKey = KeyCode.U;

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
        moveU = 0f;
        moveH = 0f;

        if (Input.GetKey(KeyCode.U))
        {
            moveU = 1f;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            moveU = -1f;
        }

        if (Input.GetKey(KeyCode.H))
        {
            moveH = -1f;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            moveH = 1f;
        }

        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveH, moveU);
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
