using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour
{
    public List<Button> cards = new List<Button>();
    private GameObject cardSelectCanvas;
    private CardSelector cardSelector;
    public CardHandler cardHandler;
    private PlayersInGameHandler players;
    private CardBase selectedCard;
    private Camera DrawCam;

    private void Start()
    {
        cardSelector = GameObject.FindObjectOfType<CardSelector>();
        DrawCam = gameObject.GetComponentInChildren<Camera>();
        cardSelectCanvas = GameObject.FindGameObjectWithTag("CardSelect").gameObject;
        players = GameObject.FindObjectOfType<PlayersInGameHandler>();
    }

    // Update is called once per frame
    public void AssignCards(int dex)
    {
        
        foreach (Button card in cards)
        {
            int KeyIndex = dex;
            card.GetComponentInChildren<Text>().text = cardSelector.selectionCards[dex].cardName;
            card.onClick.AddListener( () => OnClick(KeyIndex));


            dex++;
        }
    }

    private void OnClick(int pos)
    {
        players.SpawnPlayers();
        Debug.Log(pos);
        selectedCard = cardSelector.selectionCards[pos];
        cardHandler.currentCards.Add(selectedCard);
        if(selectedCard.behaviourScript != null)
        {
            cardHandler.cardBehaviourScriptsRef.Add(selectedCard);
        }
        cardHandler.NewRound();
        cardSelectCanvas.SetActive(false);
        players.SwitchPlayerCam();
        DrawCam.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void Getcards()
    {
        int i = 0;
       
        cardSelector.NewCards();
        AssignCards(i);
    }
}