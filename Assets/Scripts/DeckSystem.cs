using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSystem : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] bubbleCards;
    [SerializeField]
    public List<GameObject> cardsInDeck = new List<GameObject>();
    [SerializeField]
    public int maxCardCount;

    [Space]
    [SerializeField]
    public float rollCardInterval;
    private float rollCardTimer = 0;

    [Space]
    [SerializeField]
    private Vector3 cardSlotStartingPosition;
    [SerializeField]
    private Vector3 cardSlotSpaceInterval;




    GameObject selectRandomCard()
    {
        int randomNum = Random.Range(0, bubbleCards.Length - 1);
        return bubbleCards[randomNum];
    }

    void Start()
    {
        //reset the timer
        rollCardTimer = rollCardInterval;
        
        //begin with 5 cards for player to choose
        for (int i = 0; i < 5; i++)
        {
            //Instantiate the card in scene
            cardsInDeck.Add(Instantiate(selectRandomCard(), cardSlotStartingPosition + cardsInDeck.Count* cardSlotSpaceInterval, Quaternion.identity, transform));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //when timer zeros, give a new card
        if(rollCardTimer <= 0 && cardsInDeck.Count< maxCardCount)
        {
            //Instantiate the card in scene
            cardsInDeck.Add(Instantiate(selectRandomCard(), cardSlotStartingPosition + cardsInDeck.Count * cardSlotSpaceInterval, Quaternion.identity, transform));
            //reset the timer
            rollCardTimer = rollCardInterval;
        }
        //otherwise, cycle the timer
        else
        {
            rollCardTimer -= Time.deltaTime;
        }
    }
}
