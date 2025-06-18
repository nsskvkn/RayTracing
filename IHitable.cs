using System;

namespace RayTracer
{
    public interface IHitable
    {
        bool Hit(Ray ray, double tMin, double tMax, out HitRecord rec);
    }
}