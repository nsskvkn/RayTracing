using System;

namespace RayTracer
{
    public class Sphere : IHitable
    {
        public Vec3 Center;
        public double Radius;

        public Sphere(Vec3 C, double R)
        {
            Center = C;
            Radius = R;
        }
        public bool Hit(Ray ray, double mint, double maxt, out HitRecord hitReс)
        {
            hitReс = new HitRecord();

            Vec3 offset = ray.Origin.Subtract(Center);

            double a = Vec3.Dot(ray.Direction, ray.Direction);
            double b = Vec3.Dot(offset, ray.Direction);
            double c = Vec3.Dot(offset, offset) - Radius * Radius;

            double discriminant = b * b - a * c;
            if (discriminant < 0.0)
                return false;

            double sqrtD = Math.Sqrt(discriminant);

            double root = (-b - sqrtD) / a;
            if (root < mint || root > maxt)
            {
                root = (-b + sqrtD) / a;
                if (root < mint || root > maxt)
                    return false;
            }


            hitReс.t = root;
            hitReс.Point = ray.GetDistanc(root);
            Vec3 centerToHit = hitReс.Point.Subtract(Center);
            Vec3 Normal = centerToHit.Divide(Radius);
            hitReс.Normal = Normal;

            return true;
        }
    }
}