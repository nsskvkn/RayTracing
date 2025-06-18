using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Lambertian : IMaterial
    {
        public Vec3 AlbedoColor;
        private static Random randomGen = new Random();

        public Lambertian(Vec3 albedoColor)
        {
            AlbedoColor = albedoColor;
        }

        public bool Scatter(Ray rIn, HitRecord rec, out Vec3 attenuation, out Ray scattered)
        {
            Vec3 target = rec.Point
                .Add(rec.Normal)
                .Add(RandomInUnitSphere());

            scattered = new Ray(rec.Point, target.Sub(rec.Point));
            attenuation = AlbedoColor;
            return true;
        }

        private Vec3 RandomInUnitSphere()
        {
            Vec3 point;
            do
            {
                double x = 2.0 * randomGen.NextDouble() - 1.0;
                double y = 2.0 * randomGen.NextDouble() - 1.0;
                double z = 2.0 * randomGen.NextDouble() - 1.0;
                point = new Vec3(x, y, z);
            }
            while (point.Dot(point) >= 1.0);
            return point;
        }
    }
}
