using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
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
        float x = startPosition.x + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(x, startPosition.y, startPosition.z);

    }
}
