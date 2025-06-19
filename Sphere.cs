using System;

namespace RayTracer
{
    public class Sphere : IHitable
    {
        private Vec3 center;
        private double radius;

        public Sphere(Vec3 center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public bool Hit(Ray ray, double tMin, double tMax, out HitRecord rec)
        {
            rec = new HitRecord();

            Vec3 oc = ray.Origin.Sub(center);
            double a = ray.Direction.Dot(ray.Direction);
            double b = 2 * oc.Dot(ray.Direction);
            double c = oc.Dot(oc) - radius * radius;

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0) return false;

            double sqrtD = Math.Sqrt(discriminant);
            double t = (-b - sqrtD) / (2 * a);
            if (t < tMin ||
                t > tMax)
            {
                t = (-b + sqrtD) / (2 * a);
                if (t < tMin ||
                    t > tMax)
                    return false;
            }

            rec.T = t;
            rec.Point = ray.GetDistanc(t);
            rec.Normal = rec.Point.Sub(center).Divide(radius);
            return true;
        }
    }
}
