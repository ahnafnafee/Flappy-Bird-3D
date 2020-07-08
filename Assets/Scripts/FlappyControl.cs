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
    
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("I'm colliding");
        gameManager.GameOver();
    }
}