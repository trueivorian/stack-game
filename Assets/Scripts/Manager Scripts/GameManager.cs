using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;

    private GameObject playerGO;

    private GameObject[] stackElements;

    private Stack<GameObject> stack;

    public float stackOffset = 5.0f;

    public static GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        playerGO = GameObject.FindGameObjectWithTag("Player");
        player = playerGO.GetComponent<Player>();
        stackElements = GameObject.FindGameObjectsWithTag("StackElement");
        stack = new Stack<GameObject>();

        for(int i=0; i<stackElements.Length; i++)
        {
            Physics2D.IgnoreCollision(playerGO.GetComponent<Collider2D>(), stackElements[i].GetComponent <Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Escape))
        {
            player.Jump();
        }
        else
        {
            Application.Quit();
        }
    }

    public void piggyBack(GameObject knight)
    {
        Vector2 playerPos = playerGO.transform.position;
        StackElement stackElement = knight.GetComponent<StackElement>();

        stackElement.StopMoving();
        stackElement.SetOnStack(true);
        stackElement.SetKinematic(true);

        stack.Push(knight);

        knight.transform.parent = playerGO.transform;
        knight.transform.position = new Vector2(playerPos.x, playerPos.y + (stack.Count - 1)*stackOffset);
    }
}
