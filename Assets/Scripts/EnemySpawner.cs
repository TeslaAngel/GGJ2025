using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed;
    private Vector2 screenBounds;
    float spawnInterval = 10f;
    float spawnTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTimer > spawnInterval)
        {
            spawnTimer = Time.time;
            SpawnEnemy();
        }
        
        //if (Input.GetKeyDown(KeyCode.Space))
        
    }
    void SpawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
    }
}
