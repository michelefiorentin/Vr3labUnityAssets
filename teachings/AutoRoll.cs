// Autoroll v1 

using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class AutoRoll : MonoBehaviour
    {


        public float amplitude = 45f;
        public Vector3 myaxis ;
        public float angularspeed = 1f;
        public float tempBoatAngle;
        private float oldangle;

        private void Start()
        {
            tempBoatAngle = 0;
            oldangle = 0;
            myaxis = new Vector3(1, 0, 0);
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
