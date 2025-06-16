using System;

namespace RayTracer
{
    public class Vec3
    {
        public double X, Y, Z;

        public Vec3() {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vec3(double x, double y, double z) {
            X = x;
            Y = y;
            Z = z;
        }

        public Vec3 Add(Vec3 other)
        {
            return new Vec3(this.X + other.X, this.Y + other.Y, this.Z + other.Z);
        }

        public Vec3 Subtract(Vec3 other)
        {
            return new Vec3(this.X - other.X, this.Y - other.Y, this.Z - other.Z);
        }

        public Vec3 Multiply(Vec3 other)
        {
            return new Vec3(this.X * other.X, this.Y * other.Y, this.Z * other.Z);
        }

        public Vec3 Multiply(double number)
        {
            return new Vec3(this.X * number, this.Y * number, this.Z * number);
        }
        public Vec3 Divide(double number)
        {
            return new Vec3(this.X / number, this.Y / number, this.Z / number);
        }

        public double Length()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }

        public Vec3 Unit()
        {
            double len = this.Length();
            return this.Divide(len);
        }

        public static double Dot(Vec3 a, Vec3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
    }
}
