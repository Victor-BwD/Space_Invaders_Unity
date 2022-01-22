using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject invaders;

    public GameObject player;

    private Player gameover;

    public Text gameOverText;


    public void Start()
    {
        //Instantiate(player, new Vector3(0, -13, 0), transform.rotation); // Instantiate player in position
        gameover = GetComponent<Player>(); 
        gameOverText.enabled = false;
    }

    private void FixedUpdate()
    {
        invaders = GameObject.Find("Invaders");
        Debug.Log(invaders.name + " has " + invaders.transform.childCount + " children");

        for(var i = 0; i <= invaders.transform.childCount; i++) // COUNT HOW MANY ENEMIES ALIVES
        {
            if(invaders.transform.childCount == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (!Player.FindObjectOfType<Player>()) // Verify if player is active on scene
        {

            gameOverText.enabled = true;

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
            }
        }
    }
}
