using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyControl : MonoBehaviour
{
    public Dissolve gameManager;
    public float speed = 5.0f;
    // Implement gravity
    public float gravity = 1.0f;
    public float flapSpeed = 5.0f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var transformVar = transform;
        transformVar.position = transformVar.position + Vector3.down * (Time.deltaTime * speed);
        // v = u + at
        
        speed = speed + gravity * (fallMultiplier - 1) * Time.deltaTime;
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = -flapSpeed * (lowJumpMultiplier - 1);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        speed = 0f;
        flapSpeed = 0f;
        
        Debug.Log("I'm colliding");
        gameManager.GameOver();
    }
}