

namespace WinFormsApp1.Classes
{
    internal class Polaroid : Camera
    {
        public Polaroid()
        {

        }
        public int DevelopmentTime { get; set; }
        public string BodyMaterial { get; set; }
        public override string TakePhoto() => "Photo taken with a polaroid";

        public string InsertCartridges(int count) => $"{count} cartridges have been inserted";
        public string TurnOnFlash() => "Flash on";
    }
}
