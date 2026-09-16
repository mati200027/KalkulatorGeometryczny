namespace KalkulatorGeometryczny.Models
{
    public class KalkulatorModel
    {
        public string Figura { get; set; } = "";

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double H { get; set; }
        public double R { get; set; }

        public double Pole { get; set; }
        public double Obwod { get; set; }
    }
}