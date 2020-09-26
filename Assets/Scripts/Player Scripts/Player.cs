using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    private bool movingRight = true;
    private bool canJump = true;

    private Rigidbody2D playerPhysics;
    
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    void Awake()
    {
        playerPhysics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingRight)
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
        else
        {
            transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }
    }

    public void ChangeDirection()
    {
        movingRight = !movingRight;
    }

    public void Jump()
    {
        if (canJump)
        {
            playerPhysics.AddForce(new Vector2(0.0f, jumpForce));
        }
    }
}
