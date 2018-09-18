namespace AmeisenMovement.Structs
{
    public struct Vector4
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double R { get; set; }

        public Vector4(double x, double y, double z, double r)
        {
            X = x;
            Y = y;
            Z = z;
            R = r;
        }

        public Vector4(Vector4 inputPosition)
        {
            X = inputPosition.X;
            Y = inputPosition.Y;
            Z = inputPosition.Z;
            R = inputPosition.R;
        }
    }
}
