using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
     public float speed = 1.5f;
    public float distance = 5f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float y = startPosition.y + Mathf.Abs(Mathf.Sin(Time.time * speed) * distance);
        transform.position = new Vector3(startPosition.x, y, startPosition.z);
    }
}
