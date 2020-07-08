using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float cloudSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var transformVar = transform;
        transformVar.position = transformVar.position + Vector3.left * (Time.deltaTime * cloudSpeed);
    }
}
