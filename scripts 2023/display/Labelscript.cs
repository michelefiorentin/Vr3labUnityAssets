/*
IMPORTANT NOTE: uses legacy input system
Copyright Michele Fiorentino, Fabio Vangi, Mine Dastan 2023
Politecnico di Bari
Brief: This is a signle script for dispalyin a 2D label 
Enjoy! MIT license
Usage: 
1) add to any object and set param 
2) (otional ) change labelvalue in script (it's public) 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labelscript : MonoBehaviour
{
    public int label_value = 0;
    public string label_text = "Label";
    public Font myFont;
    public Color myfontcolor = Color.red;
    public int font_size = 50;
    public Rect label_rect;

    // privates
    private GUIStyle customStyle;
    
    void Start()
    {
        customStyle = new GUIStyle();
        // eventually use this ( to be tested)
        //myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
    }

    // This is called like update, so value is update
    private void OnGUI()
    {
        customStyle.fontSize = font_size;
        customStyle.normal.textColor = myfontcolor;
        customStyle.font = myFont;
        GUI.Label(label_rect, label_text + label_value, customStyle);
    }

}
