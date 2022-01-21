using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{

    public int shieldHealth = 4;
    public int shieldCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        shieldCurrentHealth = shieldHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            this.gameObject.SetActive(false);
        }

        
    }
}
