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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == 0)
        {
            dragging = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
                    //if player has dragged this card to an bubble engine
                    if(hit.transform.tag == "Engine")
                    {
                        //check if engine is empty, if yes, implement this card's bubble to the engine and destroy this card
                        
                    }
                }
            }

            dragging = false;
        }
    }
}
