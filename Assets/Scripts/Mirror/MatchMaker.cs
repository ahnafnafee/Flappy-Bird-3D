using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using Mirror;
using Random = UnityEngine.Random;

[System.Serializable]
public class Match
{
    public string matchID;
    public SyncListGameObject players = new SyncListGameObject();

    public Match(string matchID, GameObject player)
    {
        this.matchID = matchID;
        players.Add(player);
    }

    public Match()
    {
        
    }
}

[System.Serializable]
public class SyncListGameObject : SyncList<GameObject>
{
    
}

[System.Serializable]
public class SyncListMatch : SyncList<Match>
{
    
}


public class MatchMaker : NetworkBehaviour
{
    public static MatchMaker instance;
    
    public SyncListMatch matches = new SyncListMatch();
    
    public SyncListString matchIDs = new SyncListString();
    
    public static string GetRandomMatchID()
    {
        string id = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, 36);
            if (random < 36)
            {
                id += (char) (random + 65);
            }
            else
            {
                id += (random - 26).ToString();
            }
        }
        Debug.Log($"Rand Match ID: {id}");
        return id;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    
    public bool HostGame (string matchID, GameObject player) 
    {
        if (matchIDs.Contains(matchID))
        {
            matchIDs.Add(matchID);
            matches.Add(new Match(matchID, player));
            Debug.Log($"Match ID generated");
            return true;
        }
        else
        {
            Debug.Log($"Match ID already exists");
            return false;
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

}

public static class MatchExtensions {
    public static Guid ToGuid (string id) {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider ();
        byte[] inputBytes = Encoding.Default.GetBytes (id);
        byte[] hashBytes = provider.ComputeHash (inputBytes);

        return new Guid (hashBytes);
    }
}
