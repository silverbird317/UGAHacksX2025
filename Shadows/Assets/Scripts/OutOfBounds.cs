using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
    // if you need check distance, you can do it like this:
    if ((transform.position - startPosition).magnitude > 13f)
        transform.position = startPosition;
    }
}
