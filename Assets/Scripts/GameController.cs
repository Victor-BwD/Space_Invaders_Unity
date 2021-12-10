using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    private void FixedUpdate()
    {
        GameObject invaders = GameObject.Find("Invaders");
        Debug.Log(invaders.name + " has " + invaders.transform.childCount + " children");

        for(var i = 0; i <= invaders.transform.childCount; i++)
        {
            if(invaders.transform.childCount == 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}
