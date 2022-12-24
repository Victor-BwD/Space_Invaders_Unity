using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject invaders;
    private Player gameover;
    public Text gameOverText;
    private TMP_Text ScoreText;
    private TMP_Text highScoreText;

    private int score = 0;
    private int highScore;

    public void Start()
    {
        //Instantiate(player, new Vector3(0, -13, 0), transform.rotation); // Instantiate player in position
        gameover = GetComponent<Player>(); 
        gameOverText.enabled = false;
        invaders = GameObject.Find("Invaders");
        ScoreText = FindObjectOfType<ActualScoreMark>().GetComponent<TMP_Text>();
        highScoreText = FindObjectOfType<HighScoreMark>().GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        Debug.Log(invaders.name + " has " + invaders.transform.childCount + " children");

        for(var i = 0; i <= invaders.transform.childCount; i++) // COUNT HOW MANY ENEMIES ALIVES
        {
            if(invaders.transform.childCount == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (!FindObjectOfType<Player>()) // Verify if player is active on scene
        {

            gameOverText.enabled = true;

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
            }
        }
    }

    public void KillFrontlineAddPoints()
    {
        score += 10;
        ScoreText.text = score.ToString("0000");
    }

    public void KillMiddleAlienAddPoints()
    {
        score += 20;
        ScoreText.text = score.ToString("0000");
    }
    
    public void KillBacklineAlienAddPoints()
    {
        score += 30;
        ScoreText.text = score.ToString("0000");
    }

    public void KillMisteryShip()
    {
        score += 300;
        ScoreText.text = score.ToString("0000");
    }
}
