using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FlappyControl2 : NetworkBehaviour
{
    public Dissolve gameManager;
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
        // v = u + at
        
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
        FMODUnity.RuntimeManager.PlayOneShot(jumpSound);
        speed = -flapSpeed * (lowJumpMultiplier - 1);
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Bird"))
        {
            gravity = 0f;
        }
        
        _hitNo++;
        if (other.collider.CompareTag("Floor"))
        {
            gravity = 0f;
        }
        speed = 0f;
        flapSpeed = 0f;

        // Debug.Log("I'm colliding");
        if (_hitNo == 1)
        {
            FMODUnity.RuntimeManager.PlayOneShot(hitSound);
            gameManager.GameOver();
        }
    }
}