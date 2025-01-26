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

    private void Update()
    {
        //execute lane shift under the 3 lane setting, work for both keyboard and controller
        if (Input.GetAxis("Vertical") > 0.5f)
        {
            //gradually rotate to the left
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, turningRotationAngle), turningSpeed * Time.deltaTime);

            //move left according to rotation angle

        }
        else if (Input.GetAxis("Vertical") < -0.5f)
        {
            //gradually rotate to the right
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, -turningRotationAngle), turningSpeed * Time.deltaTime);

            //move right according to rotation angle

        }
        else
        {
            //back to original rotation
            if (Quaternion.Angle(transform.rotation, Quaternion.identity) > 2f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, turningSpeed * Time.deltaTime);
            }
        }


        //impose effect by type of bubbles in each engine
        foreach (EngineCode code in EngineList)
        {
            if (code != null && code.bubble != null)
            {
                switch (code.bubble.GetComponent<BubbleCode>().bubbleType)
                {
                    case 1: //light bubble
                        //GetComponent<Rigidbody>().AddForce(Vector3.up * lightBubbleForce * Time.deltaTime);
                        break;

                    case 2: //heavy bubble
                        //GetComponent<Rigidbody>().AddForce(Vector3.down * heavyBubbleForce * Time.deltaTime);
                        break;
                    case 3: //speed bubble
                        //GetComponent<Rigidbody>().AddForce(Vector3.forward * fastBubbleForce * Time.deltaTime);
                        break;

                    case 4: //slow bubble
                        //GetComponent<Rigidbody>().AddForce(Vector3.back * slowBubbleForce * Time.deltaTime);
                        break;
                }
            }
        }
    }
}
