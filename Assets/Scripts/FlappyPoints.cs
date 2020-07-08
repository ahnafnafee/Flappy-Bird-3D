using UnityEngine;
using UnityEngine.UI;

public class FlappyPoints : MonoBehaviour
{
    public static int Score = 0;

    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = Score.ToString();
    }
}
