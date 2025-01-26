using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCode : MonoBehaviour
{
    public int bubbleType; //0 = sample, 1 = light, 2 = heavy, 3 = speed, 4 = slow, 5 = TNT
    public float lifeTime = 15;
    private float lifeTimeTimer;
    private Vector3 originalScale;

    private void Start()
    {
        lifeTimeTimer = 1.25f * lifeTime;
        originalScale = transform.localScale;
    }

    private void Update()
    {
        lifeTimeTimer -= Time.deltaTime;
        transform.localScale = originalScale * (lifeTimeTimer / lifeTime);
        
        if(lifeTimeTimer / lifeTime <= 0.2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //destroy the bubble when being hit by spiky enemy
    }

    private void OnDestroy()
    {
        //release a special effect when being destroyed
    }
}
