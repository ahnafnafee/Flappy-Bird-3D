using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
