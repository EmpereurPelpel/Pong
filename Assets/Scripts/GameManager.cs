using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int ScoreP1 = 0;
    public int ScoreP2 = 0;

    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private Text scoreText1;
    [SerializeField]
    private Text scoreText2;

    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject gameOverScreen2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddPlayerScore(bool isGoal1)
    {
        if (isGoal1)
        {
            ScoreP2++;
            scoreText2.text = ScoreP2.ToString();
        }
        else
        {
            ScoreP1++;
            scoreText1.text = ScoreP1.ToString();
        }

        winCheck();
    }
    public void ResetPosition()
    {
        ball.GetComponent<BallScript>().Reset();
        player1.GetComponent<PlayerMovement>().Reset();
        player2.GetComponent<PlayerMovement>().Reset();
    }

    private void winCheck()
    {
        if (ScoreP1 > ScoreP2 + 1 && ScoreP1 > 4)
        {
            gameOverScreen.SetActive(true);
            ball.GetComponent<BallScript>().stop();

        }
        else if (ScoreP2 > ScoreP1 + 1 && ScoreP2 > 4)
        {
            gameOverScreen2.SetActive(true);
            ball.GetComponent<BallScript>().stop();
        }
    }
}
