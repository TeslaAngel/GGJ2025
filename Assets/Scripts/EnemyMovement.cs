using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }
    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    
    void MoveEnemy()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
}
