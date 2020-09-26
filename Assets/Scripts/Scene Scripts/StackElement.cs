using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackElement : MonoBehaviour
{
    private bool movingRight = true;
    private bool moving = true;
    private bool onStack = false;

    private Rigidbody2D stackElementPhysics;

    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        stackElementPhysics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Move();
        }
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

    void OnTriggerEnter2D(Collider2D target)
    {
        if((target.tag == "Player") && !onStack)
        {
            GameManager.gameManager.piggyBack(gameObject);
        }
    }

    public void ChangeDirection()
    {
        movingRight = !movingRight;
    }

    public void StopMoving()
    {
        moving = false;
    }

    public void StartMoving()
    {
        moving = true;
    }

    public void SetOnStack(bool _onStack)
    {
        onStack = _onStack;
    }

    public void SetKinematic(bool isKinematic)
    {
        stackElementPhysics.isKinematic = isKinematic;
    }
}
