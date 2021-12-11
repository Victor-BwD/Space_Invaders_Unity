using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject invaders;

    private void FixedUpdate()
    {
        invaders = GameObject.Find("Invaders");
        Debug.Log(invaders.name + " has " + invaders.transform.childCount + " children");

        for(var i = 0; i <= invaders.transform.childCount; i++)
        {
            if(invaders.transform.childCount == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
