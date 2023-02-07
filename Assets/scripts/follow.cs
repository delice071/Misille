using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;


    private void Start()
    {
        offset = target.position - transform.position;
    }

    private void FixedUpdate()
    {
        var position = -offset + target.position;
        var currentPosition = Vector3.Lerp(transform.position, position, .5f);
        currentPosition.z = transform.position.z;
        transform.position = currentPosition;

    }

}
