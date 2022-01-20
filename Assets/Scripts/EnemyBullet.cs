using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;


    private Shields getShield;

    // Start is called before the first frame update
    void Start()
    {
        getShield = FindObjectOfType<Shields>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
            getShield.shieldCurrentHealth -= 1;
        }

        //if(destroyed != null)
        //{
        //    destroyed.Invoke();
        //}

        //Destroy(gameObject);

    }
}
