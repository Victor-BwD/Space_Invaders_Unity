using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.5f;

    public Bullet bulletPrefab;

    private float fireRate = 0.5f;
    private float nextFire;

    private AudioSource audioSource;
    public AudioClip shootingAudioClip;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
     
    }

    // Update is called once per frame
    void Update()
    {
       
        

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            audioSource.PlayOneShot(shootingAudioClip);
            Shoot();
        }
    }

    public void Shoot()
    {
        
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            Destroy(gameObject);
            GameObject spawnExplosion = Instantiate(explosion, gameObject.transform.localPosition, Quaternion.identity);
            Destroy(spawnExplosion, 3f);
        }
    }
}
