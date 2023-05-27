

namespace WinFormsApp1.Classes
{
    public class AnalogCamera : Camera
    {
        public AnalogCamera()
        {

        }

        public int BatteryLife { get; set; }
        public bool WeatherSealing { get; set; }
        public override string TakePhoto() => "Photo taken with a analog camera";

        public string InsertFilm() => "Film inserted";
        public string Charge(int time, int volts) => $"The camera was charged for {time} minutes from a power of {volts} volts";
    }
}
