using System;

namespace RayTracer
{
    public class Vec3
    {
        public double X;
        public double Y;
        public double Z;

        public Vec3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vec3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vec3 Add(Vec3 other)
        {
            Vec3 result = new Vec3(this.X + other.X, this.Y + other.Y, this.Z + other.Z);
            return result;
        }

        public Vec3 Sub(Vec3 other)
        {
            Vec3 result = new Vec3(this.X - other.X, this.Y - other.Y, this.Z - other.Z);
            return result;
        }

        public Vec3 Multiply(double t)
        {
            Vec3 result = new Vec3(this.X * t, this.Y * t, this.Z * t);
            return result;
        }

        public Vec3 Divide(double t)
        {
            Vec3 result = new Vec3(this.X / t, this.Y / t, this.Z / t);
            return result;
        }

        public double Dot(Vec3 other)
        {
            return this.X * other.X + this.Y * other.Y + this.Z * other.Z;
        }

        public double Length()
        {
            return Math.Sqrt(this.Dot(this));
        }

        public Vec3 Unit()
        {
            double len = this.Length();
            Vec3 result = this.Divide(len);
            return result;
        }
    }
}
