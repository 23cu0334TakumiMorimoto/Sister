using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransform : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time) * 2.0f + initialPosition.y, initialPosition.z);
    }
}