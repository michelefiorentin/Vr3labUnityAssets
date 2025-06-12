using System;
/// <summary>
/// Copyright Michele Fiorentino michele.fiorentino@poliba.it
/// Nautical base classses fo th ebroadcaster
/// </summary>
public class WindEventArgs : EventArgs
{
    //Angle value always positive
    private float _speed = 0; // private variable 
    public float Speed 
    {
        get
        {
            return _speed;
        }
set
        {
            _speed = Math.Abs(value); // make it positive
                    
        }
    } 


    //public float Angle { get; set; } = 0f;

    //Internal Angle Representation - value always positive, in degrees 360 reported in range 0-359
    //All angle Inputs are converted in internal represenation 
    private float _angle = 0; // private variable 
    // angle interally is [0-359[
    public float Angle
    {
        get
        {
            return _angle;
        }
        set
        {
            _angle = value % 360f;

            // bring negative angles to positive
            if (value < 0)
            {
                _angle = _angle + 360;
              
            }
            if (_angle == 360) _angle = 0; // maybe better way doing it!
        }
    } 

    public string SpeedUnit { get; set; } = "Knt";
    public string AngleUnit { get; set; } = "°";

    public string Dump() { string my; my = "Wind: " + Speed.ToString("f2") + SpeedUnit + " angle:" + Angle.ToString("f2") + AngleUnit; return my; }
}
