using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float _timer = 0;
    public float maxTime = 1.5f;
    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > maxTime)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3(12.0f, Random.Range(-0.64f, 4.45f), 0f);

            Destroy(newPipe, 8);

            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}