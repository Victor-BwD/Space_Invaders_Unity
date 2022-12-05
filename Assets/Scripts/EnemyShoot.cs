using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBulletPrefab; 
    private GameObject enemyBulletClone;
    
    void Update()
    {
        FireEnemyBullet();
    }

    void FireEnemyBullet()
    {
        foreach (Transform invader in this.transform)
        {
            if (!invader.gameObject.activeInHierarchy) // Checks if invaders is still in hierarchy tree
            {
                continue;
            }
            
            if (Random.Range(0, 10000) < 1)
            {
                enemyBulletClone = Instantiate(enemyBulletPrefab, new Vector3(invader.transform.position.x, invader.transform.position.y - 0.4f, 1), invader.transform.rotation) as GameObject;
            }
        }
            
    }

    
}
