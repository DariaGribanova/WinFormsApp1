using System;


namespace WinFormsApp1.Classes
{
    public class DigitalCamera : Camera
    {
        public DigitalCamera()
        {
           
        }
        public int MemorySize { get; set; }
        public int MegaPixels { get; set; }
        public override string TakePhoto() => "Photo taken with a digital camera";

        public string SetZoom(double zoom) => $"Zoom {zoom} set";
        public string SetShutterSpeed(int shutterSpeed) => $"ShutterSpeed {shutterSpeed} set";
    }
    
}
