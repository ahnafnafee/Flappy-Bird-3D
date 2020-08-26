using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FlappyControl1 : NetworkBehaviour
{
    public float speed = 5.0f;
    // Implement gravity
    public float gravity = 1.0f;
    public float flapSpeed = 5.0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private int _hitNo = 0;
    
    [FMODUnity.EventRef] public string hitSound, jumpSound;

    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return;
        }
        
        var transformVar = transform;
        transformVar.position = transformVar.position + Vector3.down * (Time.deltaTime * speed);
        speed = speed + gravity * (fallMultiplier - 1) * Time.deltaTime;
    
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        
        CmdMove();
        
    }
    
    [Command]
    private void CmdMove()
    {
        RpcMove();
    }
    
    // To move EVERY player
    [ClientRpc]
    private void RpcMove()
    {
        gravity = 10.0f;
        speed = 0f;
        flapSpeed = 5.5f;
            
        FMODUnity.RuntimeManager.PlayOneShot(jumpSound);
        speed = -flapSpeed * (lowJumpMultiplier - 1);
    }
    
    public void OnCollisionEnter(Collision other)
    {
        _hitNo++;
        gravity = 0f;
        speed = 0f;
        flapSpeed = 0f;

        // // Debug.Log("I'm colliding");
        // if (_hitNo == 1)
        // {
        //     FMODUnity.RuntimeManager.PlayOneShot(hitSound);
        //     gameManager.GameOver();
        // }
    }
    
    
}