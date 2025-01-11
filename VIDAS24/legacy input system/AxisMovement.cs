/// Simple script for triggers a custom event 
/// the Gameobject requires a collider with is triggered enabled 
/// WARNING: legacy imput system required (=no imput package)
/// Instructions:
/// 1) add to gameobject
/// 2) use keyboard arrow to move 


/// By Michele Fiorentino
/// Politecnico di Bari
/// Copyright 2022
/// In case of issues or bugs email fiorentino@poliba.it - give details
/// V2 : with increment

using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class AxisMovement : MonoBehaviour  
{
    [Tooltip("Increment value")]
     public float increment = 0.25f;
    
    Vector3 Vec;
    // Start is called before the first frame update
    // 


    void Start()  
    {  
          
    }  
  
    // Update is called once per frame  
    void Update()  
    {  
  
        Vec = transform.localPosition;  
        Vec.y += Input.GetAxis("Jump") * Time.deltaTime * 20;  
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 20;  
        Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 20;  
        transform.localPosition = Vec;  
    }  
} 