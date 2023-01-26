/// <summary>
/// Translation and rotation the attached object 
/// Rolls (like a boat) the attached object 
///
/// Authors
/// 7-9-2021 - script by michele Fiorentino, Vr3lab, Politecnico di Bari
/// 
/// 
/// USAGE: makes the attached obkect roll
/// Todo
/// unificate with teh An
/// </summary>


using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class AutoRoll : MonoBehaviour
    {

        [Tooltip("Angular Amplitude of oscillation")]
        public float amplitude = 45f;
        [Tooltip("Oscillation axe of oscillation")]
        public Vector3 myaxis = new Vector3(1, 0, 0);
        [Tooltip("oscillation speed")]
        public float angularspeed = 1f;
        [Tooltip("Current Angle -Debug-")]
        public float tempBoatAngle;
        private float oldangle;

        private void Start()
        {
            tempBoatAngle = 0;
            oldangle = 0;
        }


        private void FixedUpdate()
        {
            oldangle = tempBoatAngle;
            tempBoatAngle = amplitude * (float) Math.Sin  ((double) angularspeed * (double)Time.time);
            transform.rotation = Quaternion.AngleAxis(tempBoatAngle, myaxis);

            //transform.Translate(moveUnitsPerSecond.value * deltaTime, moveUnitsPerSecond.space);
            transform.Rotate(myaxis, tempBoatAngle - oldangle);

        }
    }
}
