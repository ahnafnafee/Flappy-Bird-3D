using UnityEngine;

public class IncrementScore : MonoBehaviour
{
    [FMODUnity.EventRef] public string pointSound;
    private void OnTriggerEnter(Collider other)
    {
        FlappyPoints.Score++;
        FMODUnity.RuntimeManager.PlayOneShot(pointSound);
        if (FlappyPoints.Score > BestScore.HighestScore)
        {
            BestScore.HighestScore = FlappyPoints.Score;
        }
    }
}