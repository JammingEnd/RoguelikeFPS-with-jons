using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    public List<CardBase> allCards = new List<CardBase>();
    public List<CardBase> selectionCards = new List<CardBase>();
    public int cardsToSelect = 5;
    // Update is called once per frame
    public void NewCards()
    {
        for (int i = 0; i < cardsToSelect; i++)
        {
            selectionCards.Add(GetCards());
        }
    }

    CardBase GetCards()
    {
        CardBase newcard = allCards[Random.Range(0, allCards.Count + 1)];
        foreach (CardBase Dupcard in selectionCards)
        {
            if(Dupcard == newcard)
            {
                newcard = allCards[Random.Range(0, allCards.Count + 1)];
            }
        }

        return newcard;
    }
}
