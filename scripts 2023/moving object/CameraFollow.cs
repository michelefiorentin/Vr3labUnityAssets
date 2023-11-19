
/// <summary>
/// Copyright 2023 Michele Fiorentino  - Politecnico di Bari
/// Attach to Canera (or other objects)  and it will follow 
/// 19-11-23 creation 
/// </summary>

using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public bool followlocation = true;
    public Vector3 locationOffset;
    public bool followrotations =true;
    public Vector3 rotationOffset;

    void FixedUpdate()
    {
        if (followlocation)
        { 
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        }

        if (followrotations)
        {
            Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
        }
    }
}