using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileTerrainSystem : MonoBehaviour
{
    public GameObject terrainPrefab;
    private List<GameObject> terrain = new List<GameObject>();
    public float terrainPrefabLength;
    public float terrainSpeed;

    // Start is called before the first frame update
    void Start()
    {
        terrain.Add(Instantiate(terrainPrefab, transform));
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < terrain.Count; i++)
        {
            if (terrain[i])
            {
                terrain[i].transform.Translate(0f, 0f, terrainSpeed * Time.deltaTime);
            }
            else
            {
                terrain.RemoveAt(i);
            }

            if (terrain[i].transform.position.z <= -terrainPrefabLength/4)
            {
                if(i == terrain.Count - 1)
                {
                    terrain.Add(Instantiate(terrainPrefab, terrain[i].transform.position + new Vector3(0f, 0f, terrainPrefabLength - terrainSpeed * Time.deltaTime), Quaternion.identity, transform));
                }
            }
            if (terrain[i].transform.position.z <= -terrainPrefabLength)
            {
                Destroy(terrain[i]);
            }
        }
    }
}
