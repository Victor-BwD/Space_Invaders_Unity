using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    private GameController GC;

    private void Start()
    {
        GC = FindObjectOfType<GameController>();
        InvokeRepeating(nameof(FireEnemyBullet), 1.0f, 1.0f);
    }

    void FireEnemyBullet()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy) // Checks if invaders is still in hierarchy tree
            {
                continue;
            }

            if (Random.value < 1.0f / GC.invaders.transform.childCount)
            {
                Instantiate(enemyBulletPrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    
}
