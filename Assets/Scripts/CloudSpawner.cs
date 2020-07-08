using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    private float _timer = 0;
    public float maxTime = 1.5f;
    public GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > maxTime)
        {
            GameObject newPipe = Instantiate(cloud);
            newPipe.transform.position = new Vector3(13.0f, Random.Range(3f, 18f), Random.Range(16f, 22f));

            Destroy(newPipe, 8);

            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}
