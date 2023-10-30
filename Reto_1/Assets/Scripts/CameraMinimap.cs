using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMinimap : MonoBehaviour
{
    public Transform target;
    public float offsetX, offsetZ;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(target.position.x + offsetX, transform.position.y, target.position.z + offsetZ), lerpSpeed);
    }
}
