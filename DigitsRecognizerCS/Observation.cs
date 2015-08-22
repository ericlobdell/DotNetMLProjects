namespace DigitsRecognizerCS
{
    class Observation
    {
        public string Label { get; set; }
        public int[] Pixels { get; set; }

        public Observation( string label, int[] pixels )
        {
            Label = label;
            Pixels = pixels;
        }
    }
}
