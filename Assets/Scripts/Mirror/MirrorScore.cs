using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MirrorScore : NetworkBehaviour
{
    [SyncVar]
    public int index;

    [SyncVar]
    public int score;

    public override void OnStartServer()
    {
        index = connectionToClient.connectionId;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10f + (index * 110), 10f, 100f, 25f), $"P{index}: {score:000}");
    }
}
