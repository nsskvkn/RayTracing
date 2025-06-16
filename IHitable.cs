using System;

namespace RayTracer
{
    public interface IHitable
    {
        bool Hit(Ray ray, double mint, double maxt, out HitRecord hitReс);
    }
}