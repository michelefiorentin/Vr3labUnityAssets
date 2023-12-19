/*
 * IMPORTANT NOTE: uses legacy input system
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
/// USAGE 
// 1) add script to an object with collider 
// 2) add/drag used Camera on camera
// 3) choose mouse related customeevent 
// enjoy

*/
using System;
using UnityEngine;
using UnityEngine.Events;



[RequireComponent(typeof(Collider))]
public class Mouse_customeevent : MonoBehaviour
{
    public enum Mode
    {
        LeftButton = 0,    // Just broadcast the action on to the target
        RightButton = 1,    // replace target with source
        MiddleButton = 2,   // Activate the target GameObject
    }
    [TextArea]
    public string Notes = "Copyright 2021 Michele Fiorentino  - Politecnico di Bari\n Attach the script to GameObject having collider too set up custom events on mouse click";

    [Tooltip("Set the camera e.g. avatar (default maincam)")]
    public Camera mycam = null;

    [Tooltip("Set here the mouse Button (default -left)")]
    public Mode mybutton = Mode.LeftButton;
 
    [Tooltip("Set here the object and the Event to invoke")]
    public UnityEvent MouseDownCustomEvent; // the events to be run
    [Tooltip("Set here the object and the Event to invoke")]
    public UnityEvent MouseEnterCustomEvent; // the events to be run
    [Tooltip("Set here the object and the Event to invoke")]
    public UnityEvent MouseExitCustomEvent; // the events to be run

    [Tooltip("Set here if you want a Debug Log-remove in final build")]
    public bool printdebug = true;

    private void Start()
    {

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown((int)mybutton))
        {
            MouseDownCustomEvent.Invoke();
            if (printdebug) Debug.Log("Pressed Mouse:" + mybutton.ToString() + "on Object " + this.name);
        } 
    }

    private void OnMouseEnter()
    {
        MouseEnterCustomEvent.Invoke();
        if (printdebug) Debug.Log("Enter Mouse:" + mybutton.ToString() + "on Object " + this.name);
    }

    private void OnMouseExit()
    {
       MouseExitCustomEvent.Invoke();
        if (printdebug) Debug.Log("Exit Mouse:" + mybutton.ToString() + "on Object " + this.name);
    }

}

