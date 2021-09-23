using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour
{
    public List<Button> cards = new List<Button>();
    private GameObject cardSelectCanvas;
    private CardSelector cardSelector;
    private CardHandler cardHandler;

    private CardBase selectedCard;

    private StatCenter choosingPlayer;

    private void Start()
    {
        cardSelector = GameObject.FindObjectOfType<CardSelector>();
        cardHandler = GameObject.FindObjectOfType<CardHandler>();
        cardSelectCanvas = GameObject.FindGameObjectWithTag("CardSelect").gameObject;
    }

    // Update is called once per frame
    public void AssignCards()
    {
        int i = 0;
        foreach (Button card in cards)
        {
            int KeyIndex = i;
            card.GetComponentInChildren<Text>().text = cardSelector.selectionCards[i].cardName;
            card.onClick.AddListener( () => OnClick(KeyIndex));


            i++;
        }
    }

    private void OnClick(int pos)
    {
        Debug.Log(pos);
        selectedCard = cardSelector.selectionCards[pos];
        cardHandler.currentCards.Add(selectedCard);
        if(selectedCard.behaviourScript != null)
        {
            cardHandler.cardBehaviourScriptsRef.Add(selectedCard);
        }
        cardHandler.NewRound();
        cardSelectCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Getcards()
    {
        cardSelector.NewCards();
        AssignCards();
    }
}