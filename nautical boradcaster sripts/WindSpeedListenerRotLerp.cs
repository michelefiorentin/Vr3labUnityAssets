using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
/// <summary>
/// Listerner of wind angle with lerp fuction, set the local angurar rotation against the axis ( normalized)
/// TODo: ora gira sempre nella stessa direzione bisognerebeb migliorare il lerp a girare nei due sensi e a fare la strada minima
/// </summary>

// https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
//minimal rotation issue
//https://stackoverflow.com/questions/2708476/rotation-interpolation
public class WindSpeedListenerRotLerp : MonoBehaviour
{
    //  public NauticalEventBroadcasterFromFile myhandler;

    [TextArea]
    public string Notes = "Copyright 2021 Michele Fiorentino  - Politecnico di Bari\n";

    [Tooltip("Axis of rotation")]
    public Vector3 myaxis = new Vector3(0, 0, 1);

    [Tooltip("Set interpolation to target")]
    public bool LerpOn = true;

    [Tooltip("Duration of teh interpolation to target")]
    public float lerpDuration = 4f; // considering nemea  = 1 sec

    [Tooltip("Switch direction of arrow")]
    public float switchdirection = 1;
    // privates
    float timeElapsed = 0;
    public float current;
    public float original;
    public float target;
 
    private void Start()
    {
        // subscribe
        NauticalEventBroadcasterFromFilePretest.WindChanged += OnWindChanged;
        original = 0;
        //  normalize axis in case of wrong input
        myaxis = myaxis.normalized;
    }

    private void Update()
    {
        if (LerpOn == false)
        {
            transform.localRotation = Quaternion.AngleAxis(target, switchdirection * myaxis); // immediate set
        }
        else if (timeElapsed < lerpDuration) // lerp activated
        {
            current = Mathf.Lerp(original, target, timeElapsed / lerpDuration);

            transform.localRotation = Quaternion.AngleAxis(current, switchdirection * myaxis);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(target, switchdirection * myaxis); // immediate set
            timeElapsed = 0;
        }

    }

    public void OnWindChanged(object source, WindEventArgs wind)
    {
        original = transform.localEulerAngles.z;
        target = wind.Angle;
        
       // else timeElapsed = 0;
        //Debug.Log("WindSpeedListenerRot :" + wind.Dump());
    }

}
