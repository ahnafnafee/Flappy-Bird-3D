﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private float _currentValue;
    public GameObject bird;
    public Animator anim, ground;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator DoFadeOut()
    {
        yield return new WaitForSeconds(1f);
        // Debug.Log("TIME STOPPED");
        Destroy(bird);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        
        anim.SetTrigger("die");
        ground.enabled = false;
        // Instantiate(gameOverCanvas);
        gameOverCanvas.SetActive(true);
        StartCoroutine(DoFadeOut());
    }
}
