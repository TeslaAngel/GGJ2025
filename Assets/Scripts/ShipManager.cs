using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public List<EngineCode> EngineList = new List<EngineCode>();
    public GameObject lightBubblePrefab;

    [Space]
    public float turningRotationAngle;
    public float turningSpeed;
    private float turningSpeedFactor = 1f;
    public float switchLaneSpeed;
    private float switchLaneSpeedFactor = 1f;

    [Space]
    public float unstableAfterTime;
    private float unstableTimer = 1f;
    private bool falling = false;

    [Space]
    public Vector3[] lanePositions;
    public int currentLane = 0;

    private bool switchedLane = false; //use this to avoid continuous lane switch

    [Space]
    public RGBPanel rgbPanel;

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

        //gives player two light bubbles
        if(EngineList.Count > 1)
        {
            int index = Random.Range(0, EngineList.Count - 2);
            EngineList[index].bubble = Instantiate(lightBubblePrefab, EngineList[index].bubblePlacer.position, EngineList[index].bubblePlacer.rotation, EngineList[index].transform);
            EngineList[index+1].bubble = Instantiate(lightBubblePrefab, EngineList[index+1].bubblePlacer.position, EngineList[index + 1].bubblePlacer.rotation, EngineList[index + 1].transform);
        }
    }

    private void Update()
    {
        if(!falling)
        {
            //execute lane shift under the 3 lane setting, work for both keyboard and controller
            if (Input.GetAxis("Vertical") > 0.3f)
            {
                //gradually rotate to the left
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, turningRotationAngle), turningSpeed * turningSpeedFactor * Time.deltaTime);

                //switch to left (upper) lane
                if (Input.GetAxis("Vertical") > 0.5f && !switchedLane && currentLane > 0)
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
                if (Input.GetAxis("Vertical") < -0.5f && !switchedLane && currentLane < lanePositions.Length - 1)
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
            if (lanePositions.Length > 0)
            {
                Vector3 syncPos = lanePositions[currentLane];
                syncPos.y += 3f * Mathf.Sin(2f * Mathf.PI * (unstableTimer / unstableAfterTime));
                transform.position = Vector3.Lerp(transform.position, syncPos, switchLaneSpeed * switchLaneSpeedFactor * Time.deltaTime);
            }


            //reset speed factors
            turningSpeedFactor = 1f;
            switchLaneSpeedFactor = 1f;
            float requiredLightBubble = 2f;


            //impose effect by type of bubbles in each engine
            foreach (EngineCode code in EngineList)
            {
                if (code != null && code.bubble != null)
                {
                    switch (code.bubble.GetComponent<BubbleCode>().bubbleType)
                    {
                        case 1: //light bubble
                            requiredLightBubble--;
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
                            requiredLightBubble--;
                            turningSpeedFactor *= 0.5f;
                            switchLaneSpeedFactor *= 0.5f;
                            break;

                        case 5: //speed bubble
                            turningSpeedFactor *= 0.8f;
                            switchLaneSpeedFactor *= 0.8f;
                            break;
                    }
                }
            }

            //if there's not enough light bubble, swing the ship!
            if (requiredLightBubble > 0f)
            {
                //if not light bubble is there, the ship falls
                if (requiredLightBubble == 2f && !falling)
                {
                    falling = true;
                }
                //if there's only one light bubble, the shop swings
                if (requiredLightBubble == 1f)
                {
                    unstableTimer -= Time.deltaTime;
                }
            }
            else
            {
                unstableTimer = unstableAfterTime;
            }
        }

        //fall
        if (falling)
        {
            Rigidbody body = GetComponent<Rigidbody>();
            body.useGravity = true;
            body.constraints = RigidbodyConstraints.None;

            if(rgbPanel && !rgbPanel.activate)
            {
                rgbPanel.activate = true;
            } 

        }
        //swing
        if(unstableTimer <= 0f)
        {
            if(currentLane == lanePositions.Length-1)
            {
                currentLane--;
            }
            else
            {
                currentLane++;
            }

            unstableTimer = unstableAfterTime;
        }
    }
}
