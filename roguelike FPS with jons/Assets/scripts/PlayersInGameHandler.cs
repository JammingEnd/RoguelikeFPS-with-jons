using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInGameHandler : MonoBehaviour
{
    public List<string> allPlayerNames = new List<string>();
   
    public List<StatCenter> allPlayers = new List<StatCenter>();
    
    public List<GameObject> spawnsPositions = new List<GameObject>();
    private Lobby lobby;
   
    void Start()
    {
        lobby = GameObject.FindObjectOfType<Lobby>();

        for (int i = 0; i < lobby.allPlayerNames.Count; i++)
        {
            allPlayerNames.Add(lobby.allPlayerNames[i]);
            allPlayers.Add(lobby.playersInLobby[i].GetComponent<StatCenter>());
        }
        SwitchPlayerCam();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayers()
    {
        for (int i = 0; i < allPlayerNames.Count; i++)
        {
            Instantiate(allPlayers[i].gameObject, spawnsPositions[i].transform.position, spawnsPositions[i].transform.rotation);
            allPlayers[i].SetName(allPlayerNames[i]);
        }

        StatCenter[] players = GameObject.FindObjectsOfType<StatCenter>();
        for (int i = 0; i < players.Length; i++)
        {
            allPlayers.Add(players[i]);
        }

        
    }
    public void SwitchPlayerCam()
    {
        bool playerCamIsOff = true;
        if (playerCamIsOff)
        {
            foreach (var player in allPlayers)
            {
                player.playerCamera.enabled = true;
            }
            playerCamIsOff = false;
            return;
        }
        if (!playerCamIsOff)
        {
            foreach (var player in allPlayers)
            {
                player.playerCamera.enabled = false;
            }
            playerCamIsOff = true;
            return;
        }
        
    }
}
