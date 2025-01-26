using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speed;
    private Vector2 screenBounds;
    float spawnInterval = 5f;
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
            SpawnEnemy();
        }
        
        //if (Input.GetKeyDown(KeyCode.Space))
        
    }
    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab) as GameObject;
        int laneIndex = Random.Range(0, shipManager.lanePositions.Length);
        Vector3 enemryLanePosition = shipManager.lanePositions[laneIndex];
        // TODO spawn slgihtly beyond camera view plane
        enemryLanePosition.z = shipManager.transform.position.z + 20;
        enemy.transform.position = enemryLanePosition;
        Rigidbody enemyRigidBody = enemy.AddComponent<Rigidbody>();
        EnemyMovement enemyMovement = enemy.AddComponent<EnemyMovement>();
    }
}
