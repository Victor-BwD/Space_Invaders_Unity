using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    private Vector3 _direction = Vector2.right;
    public float speed = 1f;

    public GameObject enemyBulletPrefab;
    public GameObject enemyBulletClone;


    //public float maxSpeed = 9.0f;
    //public float middleSpeed = 3.0f;

    public float timer = 0f;

    public float missileAttackRate;

    float timeToIncrease = 5.0f; //this is the time between "speedups"
    float currentTime;  //to keep track
    float speedIncrement = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time + timeToIncrease;

        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);

        GameObject go = GameObject.Find("Invaders");

       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direction * speed * Time.deltaTime; // go to right side

        timer += Time.deltaTime;

        float seconds = timer % 60;

        //if(seconds >= 140)
        //{
        //    this.transform.position += _direction * speed * middleSpeed * Time.deltaTime;
        //}else if (seconds >= 200)
        //{
        //    this.transform.position += _direction * speed * maxSpeed * Time.deltaTime;
        //}


        if (Time.time >= currentTime)
        {
            speed += speedIncrement;
            currentTime = Time.time + timeToIncrease;
        }


        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero); // End point left side of screen
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right); // End point right side of screen

        foreach (Transform invader in this.transform) // each invader is checked
        {
            if (!invader.gameObject.activeInHierarchy) // Checks if invaders is still in hierarchy tree
            {
                continue;
            }

            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f)) 
            {
                AdvanceRow();
            } else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
        }
    }



    private void AdvanceRow() // Function to go down a row and flip direction
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void MissileAttack()
    {
        foreach (Transform invader in this.transform) // each invader is checked
        {
            if (!invader.gameObject.activeInHierarchy) // Checks if invaders is still in hierarchy tree
            {
                continue;
            }

            if (Random.Range(0f, 3000f) < 1)
            {
                enemyBulletClone = Instantiate(enemyBulletPrefab, new Vector3(invader.transform.position.x, invader.transform.position.y - 0.4f, 0), invader.transform.rotation) as GameObject;
            }

        }
        
    }


}
