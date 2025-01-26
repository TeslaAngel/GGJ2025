using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += movementSpeed * Time.deltaTime * transform.forward;
    }
}
