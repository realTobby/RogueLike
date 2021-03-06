﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerRef;

    public static CameraController instance;

    private Vector3 _originalPos;
    private float _timeAtCurrentFrame;
    private float _timeAtLastFrame;
    private float _fakeDelta;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Calculate a fake delta time, so we can Shake while game is paused.
        _timeAtCurrentFrame = Time.realtimeSinceStartup;
        _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
        _timeAtLastFrame = _timeAtCurrentFrame;

        // Temporary vector
        Vector3 temp = playerRef.transform.position;
        temp.y = this.transform.position.y;
        // Assign value to Camera position
        transform.position = temp;


        StickCameraToPlayer();

    }

    public static void Shake(float duration, float amount)
    {
        instance._originalPos = instance.gameObject.transform.localPosition;
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(duration, amount));
    }

    public IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (duration > 0)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= _fakeDelta;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }

    public void StickCameraToPlayer()
    {
        _originalPos = new Vector3(playerRef.transform.position.x, this.transform.position.y, playerRef.transform.position.z);
        this.transform.position = _originalPos;
    }

}
