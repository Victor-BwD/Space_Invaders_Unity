using UnityEngine;

public class Invaders : MonoBehaviour
{
    private Vector3 _direction = Vector2.right;
    private float speed = 1f;
    private float timer;
    private float timeToIncrease = 5.0f; //this is the time between "speedups"
    private float currentTime;  //to keep track
    private float speedIncrement = 0.8f;
    void Start()
    {
        currentTime = Time.time + timeToIncrease;

        GameObject go = GameObject.Find("Invaders");
    }
    
    void Update()
    {
        this.transform.position += _direction * (speed * Time.deltaTime); // go to right side

        timer += Time.deltaTime;

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
}
