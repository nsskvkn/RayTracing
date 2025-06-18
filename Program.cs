using System;
using System.IO;
using System.Numerics;

namespace RayTracer
{
    public class Program
    {
        private const double Colors = 256;

        static void Main(string[] args)
        {
            int nx = 200;
            int ny = 100;
            var camera = new Camera();
            var sphere = new Sphere(new Vec3(0, 0, -1), 0.5);
            var sb = new StringBuilder();

            sb.AppendLine("P3");
            sb.AppendLine($"{nx} {ny}");
            sb.AppendLine("255");

            for (int j = ny - 1; j >= 0; j--)
            {
                for (int i = 0; i < nx; i++)
                {
                    double u = (double)i / (nx - 1);
                    double v = (double)j / (ny - 1);

                    var ray = camera.GetRay(u, v);
                    var color = RayColor(ray, sphere);

                    int red = (int)(color.X * Colors);
                    int green = (int)(color.Y * Colors);
                    int blue = (int)(color.Z * Colors);

                    sb.AppendLine($"{red} {green} {blue}");
                }
            }

            File.WriteAllText("output1.ppm", sb.ToString());
        }

        static Vec3 RayColor(Ray ray, Sphere sphere)
        {
            if (sphere.Hit(ray, 0.001, double.MaxValue, out HitRecord rec))
            {
                return new Vec3(0.5 * (rec.Normal.X + 1.0), 0.5 * (rec.Normal.Y + 1.0),0.5 * (rec.Normal.Z + 1.0) );
            }

            var unitDir = ray.Direction.Unit();
            double t = 0.5 * (unitDir.Y + 1.0);
            return new Vec3( (1.0 - t) * 1.0 + t * 0.5,(1.0 - t) * 1.0 + t * 0.7,(1.0 - t) * 1.0);
        }
    }
}

