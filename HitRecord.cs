using System;
namespace RayTracer
{
    public struct HitRecord
    {
        public double T;
        public Vec3 Point;
        public Vec3 Normal;
    }
}
