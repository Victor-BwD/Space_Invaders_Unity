using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;

    public float speed;


    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
          
        }

        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        
    }
}
