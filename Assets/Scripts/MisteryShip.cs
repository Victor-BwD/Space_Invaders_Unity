using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisteryShip : MonoBehaviour
{
    [SerializeField]private GameObject misteryShipPrefab;
    private float respawnTime = 10.0f;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
        StartCoroutine(MisteryShipWave());
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
