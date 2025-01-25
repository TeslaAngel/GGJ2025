using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public List<EngineCode> EngineList = new List<EngineCode>();

    private void Update()
    {
        //impose effect by type of bubbles in each engine
        foreach (EngineCode code in EngineList)
        {
            
        }
    }
}
