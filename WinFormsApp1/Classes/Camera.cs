
namespace WinFormsApp1.Classes
{
    public abstract class Camera : IDevice
    {
    
        public string Brand { get; set; }
        public string Name { get; set; }
        public bool Viewfinder { get;  set; }

        public string TurnOn() => $"The camera {Brand} is on";
       
        public string TurnOff() => $"Camera {Brand} off";
        public abstract string TakePhoto();

    }
}
