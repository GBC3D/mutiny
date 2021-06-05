using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 offset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    void Start()
    {
        offset = transform.position - playerPos.position;
    }

    void Update()
    {
        Vector3 newPos = playerPos.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
}
