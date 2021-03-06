﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] Vector3 offset;

    [SerializeField] float rotationOffset;
    // Camera speeds
    [Range(0, 10)]
    [SerializeField] float lerpPositionMultiplier = 1f;

    public void Update()
    {
        Vector3 tPos = target.position + offset + target.forward * rotationOffset;
        transform.position = Vector3.Lerp(transform.position, tPos, Time.deltaTime * lerpPositionMultiplier);
    }

}
