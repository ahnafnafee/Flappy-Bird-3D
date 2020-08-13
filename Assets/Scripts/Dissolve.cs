using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private float _currentValue;
    public Animator anim, ground;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.deltaTime);
        // _currentValue = _rend.material.GetFloat(TransparencyLevel);
        // _rend.material.SetFloat(TransparencyLevel, Mathf.Lerp(_currentValue, _transparencyLevel, Time.deltaTime));

    }

    IEnumerator DoFadeOut()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("TIME STOPPED");
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        anim.SetTrigger("die");
        ground.enabled = false;
        gameOverCanvas.SetActive(true);
        StartCoroutine(DoFadeOut());
    }
}
