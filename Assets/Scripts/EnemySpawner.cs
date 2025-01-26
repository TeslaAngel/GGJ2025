using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed;
    private Vector2 screenBounds;
    float spawnInterval = 3f;
    float spawnTimer = 0;

    public ShipManager shipManager;

    // Start is called before the first frame update
    void Start()
    {
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - spawnTimer > spawnInterval)
        {
            spawnTimer = Time.time;
            for (int i = 0; i < shipManager.lanePositions.Length; i++) {
                int coinFlip = Random.Range(0, 2);
                if (coinFlip == 1) {
                    SpawnEnemy(i);
                }
            }
        }
        
        //if (Input.GetKeyDown(KeyCode.Space))
        
    }
    void SpawnEnemy(int laneIndex)
    {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;
        // int laneIndex = Random.Range(0, shipManager.lanePositions.Length);
        Vector3 enemryLanePosition = shipManager.lanePositions[laneIndex];
        // TODO spawn slgihtly beyond camera view plane
        enemryLanePosition.z = shipManager.transform.position.z + 20;
        enemy.transform.position = enemryLanePosition;
    
        Destroy(enemy, 10f);
    }
}
