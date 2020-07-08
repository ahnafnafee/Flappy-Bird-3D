using UnityEngine;
using UnityEngine.UI;

public class SetBestScore : MonoBehaviour
{
    private static int _score = 0;

    private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        // _score = BestScore.HighestScore;
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _score.ToString();
        _score = BestScore.HighestScore;
    }
}
