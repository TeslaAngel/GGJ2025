using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public List<EngineCode> EngineList = new List<EngineCode>();
    public float lightBubbleForce;
    public float heavyBubbleForce;
    public float fastBubbleForce;
    public float slowBubbleForce;
    public float TNTBubbleForce;

    [Space]
    public float turningRotationAngle;
    public float turningSpeed;
    private float turningSpeedFactor = 1f;
    public float switchLaneSpeed;
    private float switchLaneSpeedFactor = 1f;

    [Space]
    public Vector3[] lanePositions;
    public int currentLane = 0;

    private bool switchedLane = false; //use this to avoid continuous lane switch

    private void Start()
    {
        //put player in 0 or 1 lane (top or middle)
        if(lanePositions.Length > 0)
        {
            transform.position = lanePositions[0];
            currentLane = 0;
        }
        if (lanePositions.Length > 1)
        {
            transform.position = lanePositions[1];
            currentLane = 1;
        }
    }

    private void Update()
    {
        //execute lane shift under the 3 lane setting, work for both keyboard and controller
        if (Input.GetAxis("Vertical") > 0.3f)
        {
            //gradually rotate to the left
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, turningRotationAngle), turningSpeed * turningSpeedFactor * Time.deltaTime);

            //switch to left (upper) lane
            if (Input.GetAxis("Vertical") > 0.5f && !switchedLane && currentLane>0)
            {
                switchedLane = true;
                currentLane--;
            }
        }
        else if (Input.GetAxis("Vertical") < -0.3f)
        {
            //gradually rotate to the right
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, -turningRotationAngle), turningSpeed * turningSpeedFactor * Time.deltaTime);

            //switch to right (lower) lane
            if (Input.GetAxis("Vertical") < -0.5f && !switchedLane && currentLane < lanePositions.Length-1)
            {
                switchedLane = true;
                currentLane++;
            }
        }
        else
        {
            //back to original rotation
            if (Quaternion.Angle(transform.rotation, Quaternion.identity) > 2f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, turningSpeed * turningSpeedFactor * Time.deltaTime);
            }

            switchedLane = false;
        }

        
        //always align to lane position
        if(lanePositions.Length > 0)
        {
            transform.position = Vector3.Lerp(transform.position, lanePositions[currentLane], switchLaneSpeed * switchLaneSpeedFactor * Time.deltaTime);
        }


        turningSpeedFactor = 1f;
        switchLaneSpeedFactor = 1f;

        //impose effect by type of bubbles in each engine
        foreach (EngineCode code in EngineList)
        {
            if (code != null && code.bubble != null)
            {
                switch (code.bubble.GetComponent<BubbleCode>().bubbleType)
                {
                    case 1: //light bubble
                        //nothing For now
                        break;

                    case 2: //heavy bubble
                        turningSpeedFactor *= 0.5f;
                        switchLaneSpeedFactor *= 0.5f;
                        break;

                    case 3: //speed bubble
                        turningSpeedFactor *= 2f;
                        switchLaneSpeedFactor *= 2f;
                        break;

                    case 4: //slow bubble
                        turningSpeedFactor *= 0.5f;
                        switchLaneSpeedFactor *= 0.5f;
                        break;
                }
            }
        }
    }
}
