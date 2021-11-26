/// Movetool with new Inputsystem 
/// Michele Fiorentino 2021 V" 
///  arroes and mk keys position
///  ad -ex -wz rotations


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movetoolNI : MonoBehaviour
{
    [Tooltip("Increment for translation")]
    public float m_trans_increment = 0.1f;
    [Tooltip("Increment for rotation")]
    public float m_rot_increment = 10f;
    // Update is called once per frame
    void Update()
    {

        // maybe a bug not under anykey

        if (Keyboard.current.upArrowKey.wasPressedThisFrame) // up
        {
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            transform.position += transform.forward * m_trans_increment;
        }

        if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            transform.position -= transform.forward * m_trans_increment;
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            transform.position += transform.right * m_trans_increment;

        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            transform.position -= transform.right * m_trans_increment;

        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            transform.position += transform.up * m_trans_increment;

        }

        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            transform.position -= transform.up * m_trans_increment;

        }

        if (Keyboard.current.anyKey.wasPressedThisFrame) // anykey guard
        {
 
            // rotations
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                transform.Rotate(-Vector3.left * m_rot_increment, Space.Self);
            }

            if (Keyboard.current.sKey.wasPressedThisFrame)
            {

                transform.Rotate(Vector3.left * m_rot_increment, Space.Self);
            }

            // rotations
            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                transform.Rotate(-Vector3.up * m_rot_increment, Space.Self);
            }

            if (Keyboard.current.zKey.wasPressedThisFrame)
            {

                transform.Rotate(Vector3.up * m_rot_increment, Space.Self);
            }

            // rotations
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                transform.Rotate(-Vector3.forward * m_rot_increment, Space.Self);
            }

            if (Keyboard.current.xKey.wasPressedThisFrame)
            {

                transform.Rotate(Vector3.forward * m_rot_increment, Space.Self);
            }
        }// end enykey
    }
}