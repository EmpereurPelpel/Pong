using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer1 = false;

    [SerializeField]
    private Rigidbody2D rb;

    [Range(0f,20f)]
    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private bool is1PMode = false;

    private float movement;
    private Vector2 startPos;

    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        if (is1PMode)
        {
            ball = GameObject.FindGameObjectWithTag("Ball");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical_J1");
        }
        else if (!is1PMode)
        {
            movement = Input.GetAxisRaw("Vertical_J2");
        }
        else
        {
            movement = (ball.transform.position.y - transform.position.y);
            if (movement != 0)
            {
                movement /= Mathf.Abs(movement) * 2.5f;
            }
            Debug.Log(movement);
        }
        
    }

    private void LateUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}
