using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            target.gameObject.GetComponent<Player>().ChangeDirection();
        } else if(target.tag == "StackElement")
        {
            target.gameObject.GetComponent<StackElement>().ChangeDirection();
        }
    }
}
