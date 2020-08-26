using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    public static UILobby instance;
    
    [SerializeField] InputField joinMatchInput;
    
    [SerializeField] private Button joinBtn;

    [SerializeField] private Button hostBtn;

    [SerializeField] private Canvas lobbyCanvas;

    void Start()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void Host()
    {
        joinBtn.interactable = false;
        hostBtn.interactable = false;
        joinMatchInput.interactable = false;
        
        Player.localPlayer.HostGame();
    }

    // Update is called once per frame
    public void Join()
    {
        joinBtn.interactable = false;
        hostBtn.interactable = false;
        joinMatchInput.interactable = false;
    }
    
    public void HostSuccess (bool success) {
        if (success) {
            lobbyCanvas.enabled = true;

            // if (localPlayerLobbyUI != null) Destroy (localPlayerLobbyUI);
            // localPlayerLobbyUI = SpawnPlayerUIPrefab (Player.localPlayer);
            // matchIDText.text = matchID;
            // beginGameButton.SetActive (true);
        } else {
            joinBtn.interactable = false;
            hostBtn.interactable = false;
            joinMatchInput.interactable = false;
        }
    }
    
    public void JoinSuccess (bool success) {
        if (success) {
            lobbyCanvas.enabled = true;

            // if (localPlayerLobbyUI != null) Destroy (localPlayerLobbyUI);
            // localPlayerLobbyUI = SpawnPlayerUIPrefab (Player.localPlayer);
            // matchIDText.text = matchID;
        } else {
            joinBtn.interactable = false;
            hostBtn.interactable = false;
            joinMatchInput.interactable = false;
        }
    }



}
