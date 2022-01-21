using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyBulletPrefab; 
    private GameObject enemyBulletClone;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireEnemyBullet();
        
    }

    void FireEnemyBullet()
    {

        foreach (Transform invader in this.transform)
        {
            if (Random.Range(0f, 12000f) < 1) // Random number to see which enemie will fire a bullet
            {
                enemyBulletClone = Instantiate(enemyBulletPrefab, new Vector3(invader.transform.position.x, invader.transform.position.y - 0.4f, 1), invader.transform.rotation) as GameObject;
            }
        }
            
    }

    
}
