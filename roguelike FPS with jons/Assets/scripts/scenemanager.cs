using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenemanager : MonoBehaviour
{
    private GuiHandler guiHandler;
   // private PlayersInGameHandler playersInGame;
    private Lobby lobby;
    private CardHandler playerLostRound;
    void Start()
    {
        Physics.IgnoreLayerCollision(7, 7, true);
        lobby = GameObject.FindObjectOfType<Lobby>();

        guiHandler = GetComponent<GuiHandler>();
       // playersInGame = GetComponent<PlayersInGameHandler>();
        playerLostRound = lobby.playersInLobby[0].GetComponent<CardHandler>();
        guiHandler.cardHandler = playerLostRound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
