using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    // public GameObject mainMenu;

    private bool active = true;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        // mainMenu.SetActive(true);
        // Time.timeScale = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && active)
        // {
        //     mainMenu.SetActive(false);
        //     Time.timeScale = 1;
        //     active = false;
        // }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
