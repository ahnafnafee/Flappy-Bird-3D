using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public static Player localPlayer;
    [SyncVar] public string _matchID;

    private NetworkMatchChecker networkMatchChecker;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            localPlayer = this;
            networkMatchChecker = GetComponent<NetworkMatchChecker>();
        }
    }

    // Update is called once per frame
    public void HostGame()
    {
        string matchID = MatchMaker.GetRandomMatchID();
        CmdHostGame(matchID);
    }

    [Command]
    void CmdHostGame(string matchID)
    {
        _matchID = matchID;
        if (MatchMaker.instance.HostGame(matchID, gameObject))
        {
            Debug.Log("<color=green>Game hosted successfully</color>");
            // networkMatchChecker.matchId = matchID.ToGuid();
            TargetHostGame(true, matchID);
        }
        else
        {
            Debug.Log($"<color=red>Game hosted failed</color>");
            TargetHostGame(false, matchID);
        }
    }

    [TargetRpc]
    void TargetHostGame(bool success, string matchID)
    {
        Debug.Log($"MatchID: {matchID} -- {_matchID}");
        UILobby.instance.HostSuccess(success);
    }
}
