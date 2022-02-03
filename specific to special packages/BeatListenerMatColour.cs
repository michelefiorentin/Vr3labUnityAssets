using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INSTRUCTIONS:
// This script shoul dbe used with the asset package  Audio Visualize Anything
// https://assetstore.unity.com/packages/tools/audio/audio-visualize-anything-190384
// Instryctions
//1: create geom with meshrendere 
//2: create and assign a material  this will be the starting color and at volume output 0 
//3: set targetColorAtVolume1 this will be the starting color and at volume output 1 (alpha is interpolated too!
//4: go to teh object containing the AudioVisualizeManager and subscrive the object with the OnVolumechange
//5: Set AudioVisualizeManager and play with output values. A good start it's use a Algorith: normalized Volume (-1 to 1)
//  Play also with outputs multiplier slider till you get your expected results

public class BeatListenerMatColour : MonoBehaviour
{
    #region Variables
    [Header("Settings")]
    [Tooltip("Color at Volume 1- using lerp between initial color and this color ")]
    public Color targetColorAtVolume1 = new Color();

    private Color startcol = new Color();
     private Color tempcol = new Color();
    Renderer objrenderer;
    #endregion

    private void Start()
    {
        objrenderer = GetComponent<Renderer>();
        startcol = objrenderer.material.color;
    }


    public void ListenToVolumeChange()
    {
        if (!gameObject.activeSelf)
            return;

        //tempcol = startcol * AudioVisualizeManager.Output_Volume; // this increase light in color(deprected as used lerp)
        // NOTE: here the new color is created, check colors fuctions  https://docs.unity3d.com/ScriptReference/Color.html
        tempcol = Color.Lerp(startcol, targetColorAtVolume1, AudioVisualizeManager.Output_Volume);

        // set the material in color field
        objrenderer.material.SetColor("_Color", tempcol);

     }
}
