using UnityEngine;

public class IncrementScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FlappyPoints.Score++;
        if (FlappyPoints.Score > BestScore.HighestScore)
        {
            BestScore.HighestScore = FlappyPoints.Score;
        }
    }
}