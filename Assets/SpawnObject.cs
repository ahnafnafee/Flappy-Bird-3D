using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnObject : NetworkBehaviour
{
    public GameObject lightPrefab;
    private GameObject myObject;
    private bool unspawned = true;

    [SyncVar(hook = nameof(CounterChange))]
    private int counter = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasAuthority)
            {
                if (unspawned)
                {
                    CmdSpawnObject();
                    unspawned = false;
                }
                else
                {
                    CmdDestroyObject();
                    unspawned = true;
                }
            }
        }
    }

    void CounterChange(int oldCounter, int newCounter)
    {
        Debug.Log("Counter change from " + oldCounter + " to " + newCounter);
    }

    [Command]
    void CmdDestroyObject()
    {
        NetworkServer.Destroy(myObject);
    }

    [Command]
    void CmdSpawnObject()
    {
        myObject = Instantiate(lightPrefab);
        NetworkServer.Spawn(myObject, connectionToClient);
        counter++;
    }
}
