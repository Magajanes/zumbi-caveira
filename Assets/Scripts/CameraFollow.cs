using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target parameters")]
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform target;

    [Header("Lerp parameters")]
    [Range(1, 10)]
    [SerializeField]
    private float lerpTime;

    private Vector3 _position;

    private void Start()
    {
        transform.position = target.position + offset;
    }

    private void FixedUpdate()
    {
        _position = transform.position;
        _position.x = Mathf.Lerp(_position.x, target.position.x + offset.x, lerpTime * Time.deltaTime);
        transform.position = _position;
    }
}
