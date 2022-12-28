// Attach to campera an dmove with mouse 
// by Michele Fiorentino
/// Copyright 2022
/// In case of issues or bugs email fiorentino@poliba.it - give details
/// WARNING: legacy imput system required (=no imput package)
/// Instructions:
/// 1) add to Camera (Chek initial view)
/// 2) use keyboard arrow to move 
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U10PS_MouseRotation : MonoBehaviour
{
    [Tooltip("How sensitive is to mouse movemenet")]
    public float sensitivity =0.2f;



    public bool lockZRot = false;

    public bool lockMouse = false;
    private void Start(){


        if (lockMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private float yValue = 0.0f, zValue = 0.0f;
    private void Update(){
        // 0 -> 50 && 360 -> 310
        yValue = transform.eulerAngles.y + sensitivity * Input.GetAxis("Mouse X");
        zValue = transform.eulerAngles.z + sensitivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0, 
            Mathf.Clamp(yValue > 180 ? yValue - 360 : yValue, -50, 50), 
            !lockZRot ? Mathf.Clamp(zValue > 180 ? zValue - 360 : zValue, -20, 20) : 0.0f);
    }
}
