using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public List<EngineCode> EngineList = new List<EngineCode>();
    public float upBubbleForce;

    private void Update()
    {
        //impose effect by type of bubbles in each engine
        foreach (EngineCode code in EngineList)
        {
            if (code != null)
            {
                switch (code.bubble.GetComponent<BubbleCode>().bubbleType)
                {
                    case 1: //light bubble
                        GetComponent<Rigidbody>().AddForce(Vector3.up * upBubbleForce * Time.deltaTime);
                        break;

                    case 2: //light bubble
                        GetComponent<Rigidbody>().AddForce(Vector3.up * upBubbleForce * Time.deltaTime);
                        break;
                }
            }
        }
    }
}
