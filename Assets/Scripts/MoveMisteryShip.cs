using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMisteryShip : MonoBehaviour
{
    private Vector3 _direction = Vector2.left;
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direction * speed * Time.deltaTime; // go to left side
    }
}
