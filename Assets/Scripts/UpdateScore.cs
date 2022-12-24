using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class UpdateScore : MonoBehaviour
    {
        private GameController GC;

        private void Start()
        {
            GC = FindObjectOfType<GameController>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Frontline Alien")
            {
                GC.KillFrontlineAddPoints();
                Destroy(gameObject);
            }
            if (col.gameObject.tag == "Middle Alien")
            {
                GC.KillMiddleAlienAddPoints();
                Destroy(gameObject);
            }
            if (col.gameObject.tag == "Backline Alien")
            {
                GC.KillBacklineAlienAddPoints();
                Destroy(gameObject);
            }
            if (col.gameObject.tag == "MisteryShip")
            {
                GC.KillMisteryShip();
                Destroy(gameObject);
            }
        }
    }
}