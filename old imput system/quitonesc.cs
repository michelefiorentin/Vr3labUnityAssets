/*
 * IMPORTANT NOTE: uses legacy input system
Copyright Michele Fiorentino 2021 - Politecnico di Bari
Brief: This is a signle script for avoiding student to program.
Enjoy! MIT license
Usage: Close application when user press esc (not default behavious)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitonesc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
