using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    public List<CardBase> currentCards = new List<CardBase>();

    public List<CardBase> cardBehaviourScriptsRef = new List<CardBase>();

    
    public void NewRound()
    {
        foreach (CardBase card in currentCards)
        {
            card.SelectCard(this.gameObject.GetComponent<StatCenter>());
            card.SetVariablesForStatCenter();
        }
    }
}
