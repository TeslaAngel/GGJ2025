using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class CardSystem : MonoBehaviour, IPointerDownHandler
{
    public int cardType;
    private bool dragging = false;

    [Space]
    public GameObject bubblePrefab;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("1");
        if (eventData.button == 0)
        {
            dragging = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(dragging)
            {
                var worldRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(worldRay, out hit))
                {
                    Debug.Log("2"+ hit.transform.tag);
                    //if player has dragged this card to an bubble engine
                    if (hit.transform.gameObject.tag == "Engine")
                    {
                        //check if engine is empty, if yes, implement this card's bubble to the engine and destroy this card
                        if (!hit.transform.GetComponent<EngineCode>().bubble)
                        {
                            hit.transform.GetComponent<EngineCode>().bubble = Instantiate(bubblePrefab, hit.transform.GetComponent<EngineCode>().bubblePlacer.position, hit.transform.GetComponent<EngineCode>().bubblePlacer.rotation, hit.transform);
                            Destroy(gameObject);
                        }
                    }
                }
            }

            dragging = false;
        }
    }
}