using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyControl : MonoBehaviour
{
    public GameManager gameManager;
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
        speed = speed + gravity * Time.deltaTime;
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = -flapSpeed;
        }
    }

    // private void FixedUpdate()
    // {
    //     if (_rb.velocity.z < 0)
    //     {
    //         _rb.velocity += Vector3.up * (Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
    //     } else if (_rb.velocity.z > 0 && !Input.GetButton("Jump"))
    //     {
    //         _rb.velocity += Vector3.up * (Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
    //     }
    // }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("I'm colliding");
        gameManager.GameOver();
    }
}