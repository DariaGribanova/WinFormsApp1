

namespace WinFormsApp1.Classes
{
    public interface IDevice
    {
        public string Brand { get; set; }
        public string TurnOn();
        public string TurnOff();
    }
}
