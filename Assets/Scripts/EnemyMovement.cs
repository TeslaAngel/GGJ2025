using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    
    void MoveEnemy()
    {
        //gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
        //this.transform.Translate(0, 0, speed * Time.deltaTime);
        Vector3 tempVect = new Vector3(0, 0, 2);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + tempVect);
    }
}
