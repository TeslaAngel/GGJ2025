using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCode : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //destroy the bubble when being hit by spiky enemy
    }

    private void OnDestroy()
    {
        //release a special effect when being destroyed
    }
}
