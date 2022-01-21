using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryShip : MonoBehaviour
{
    public GameObject misteryShipPrefab;
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
        StartCoroutine(MisteryShipWave());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnShip()
    {
        GameObject spawn = Instantiate(misteryShipPrefab, gameObject.transform.localPosition, Quaternion.identity); 

    }

    IEnumerator MisteryShipWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnShip();
        }
        
    }
}
