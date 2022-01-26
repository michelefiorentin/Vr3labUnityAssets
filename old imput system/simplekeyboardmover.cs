/*
 * IMPORTANT NOTE: uses legacy input system
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
Usage: attach to the object you want to move and set keys and setps
*/


/// <summary>
/// Copyright 2021 Michele Fiorentino  - Politecnico di Bari
/// Attach to object and it can be moved accoding arrow keypress
/// 1-11-2021 includes part of the code Keyrotator from class 2020, improved with all configurable keys so you can do multipel instances
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplekeyboardmover : MonoBehaviour
{

    [TextArea]
    public string Notes = "Move accoding custom keypress\n(C) 2021 Michele Fiorentino - Politecnico di Bari";
    [Tooltip("Step in meters at each keystroke")]

    [Header("Moving Settings")]
    public float movingstep = 1.0f;

    [Tooltip("Key1 increae X")]
    public string keyXPlus = "left";
    [Tooltip("Key2 decrease  X")]
    public string keyXMinus = "right";

    [Tooltip("Key1 increae Y")]
    public string keyYPlus = "a";
    [Tooltip("Key2 decrease Y")]
    public string keyYMinus = "z";

    [Tooltip("Key1 increae Z")]
    public string keyZPlus = "up";
    [Tooltip("Key2 decrease  Z")]
    public string keyZMinus = "down";

    [Header("Angular Settings")]
    [Tooltip("value of rotation per keypress in degrees")]
    public float angularstep = 5f;
    [Tooltip("Axis of rotation")]
    public Vector3 myaxis = new Vector3(1, 0, 0);
    [Tooltip("Key1 increae rotation")]
    public string keyAnglePlus = "s";
    [Tooltip("Key2 decrease  rotation")]
    public string keyAngleminus = "x";


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyXMinus))
        {
            Vector3 position = this.transform.position;
            position.x -= movingstep;
            this.transform.position = position;
        }
        else if (Input.GetKeyDown(keyXPlus))
        {
            Vector3 position = this.transform.position;
            position.x += movingstep;
            this.transform.position = position;
        }
        else if (Input.GetKeyDown(keyZPlus))
        {
            Vector3 position = this.transform.position;
            position.z += movingstep;
            this.transform.position = position;
        }
        else if (Input.GetKeyDown(keyZMinus))
        {
            Vector3 position = this.transform.position;
            position.z -= movingstep;
            this.transform.position = position;
        }
        else if (Input.GetKeyDown(keyYPlus))
        {
            Vector3 position = this.transform.position;
            position.y += movingstep;
            this.transform.position = position;
        }
        else if (Input.GetKeyDown(keyYMinus))
        {
            Vector3 position = this.transform.position;
            position.y -= movingstep;
            this.transform.position = position;
        }
        else if (Input.GetKeyDown(keyAnglePlus))
        {
            gameObject.transform.Rotate(myaxis, angularstep);
        }
        else if (Input.GetKeyDown(keyAngleminus))
        {
            gameObject.transform.Rotate(myaxis, -angularstep);
        }
    }
}
