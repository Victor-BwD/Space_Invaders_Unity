using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMisteryShip : MonoBehaviour
{
    private Vector3 _direction = Vector2.left;
    public float speed = 15f;

    private AudioSource audioSource;
    public AudioClip misteryShipAudio;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(misteryShipAudio);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direction * speed * Time.deltaTime; // go to left side
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Destroy(gameObject);
        }

    }
}
