using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    private Vector3 _direction = Vector2.right;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direction * speed * Time.deltaTime; // go to right side

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
}
