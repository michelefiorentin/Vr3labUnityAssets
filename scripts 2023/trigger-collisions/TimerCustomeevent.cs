/*
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
*/
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerCustomeevent : MonoBehaviour
{


    [Tooltip("Set here the countdown time")]
    public float timeLeft = 3.0f;
    private float temp_timeLeft ;
    [Tooltip("Only output: used for showing countdown ")]
    public string startText =""; // used for showing countdown from 3, 2, 1 
    [Tooltip("rtreiggers at end ")]
    public bool retrigger = false;
    private bool awaiting;
    [Tooltip("Set here the object and the Event")]
    public UnityEvent TimerCustomEvent; // the events to be run


    private void Start()
    {
        Reset();
    }


    public void Reset()
    {
        awaiting = true;
        temp_timeLeft = timeLeft;
    }
    void Update()
    {
        temp_timeLeft -= Time.deltaTime;
        startText = (temp_timeLeft).ToString("0");
        if (awaiting && temp_timeLeft < 0)
        {
            TimerCustomEvent.Invoke();
            print("elapsed");
            //Do something useful or Load a new game scene depending on your use-case
            if (retrigger)  Reset();
        }
    }
}


