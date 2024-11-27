using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{

    private GameManager gameManager;

    [SerializeField]
    private bool isGoal1;
    [SerializeField] AudioSource goalSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) { 
            if (isGoal1)
            {
                gameManager.AddPlayerScore(true);
            }
            else
            {
                gameManager.AddPlayerScore(false);
            }
            goalSound.Play();
            gameManager.ResetPosition();
        }
    }
}
