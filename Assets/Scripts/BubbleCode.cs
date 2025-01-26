using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCode : MonoBehaviour
{
    public int bubbleType; //0 = sample, 1 = light, 2 = heavy, 3 = speed, 4 = slow, 5 = TNT

    private void OnCollisionEnter(Collision collision)
    {
        //destroy the bubble when being hit by spiky enemy
    }

    private void OnDestroy()
    {
        //release a special effect when being destroyed
    }
}
