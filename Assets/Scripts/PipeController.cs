using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float pipeSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var transformVar = transform;
        transformVar.position = transformVar.position + Vector3.left * (Time.deltaTime * pipeSpeed);
    }
}