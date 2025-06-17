using System;
using System.IO;
using System.Numerics;

namespace RayTracer
{
    public class Program
    {
        private static double Colors = 255;

        public static void Main(string[] args)
        {
            int photWidth = 640;
            int photHeight = 360;
            string output = "output.ppm";

            using (StreamWriter writer = new StreamWriter(output))
            {
                writer.WriteLine("P3");
                writer.WriteLine(photWidth + " " + photHeight);
                writer.WriteLine("255");

                var world = new Hitable();
                world.Add(new Sphere(new Vec3(0, 0, -1), 0.5));
                world.Add(new Sphere(new Vec3(0, -100, -1), 100));

                var camera = new Camera();

                for (int y = photHeight - 1; y >= 0; y--)
                {
                    for (int x = 0; x < photWidth; x++)
                    {
                        double u = (double)x / (photWidth - 1);
                        double v = (double)y / (photHeight - 1);
                        Ray ray = camera.GetRay(u, v);
                        Vec3 color = RayColor(ray, world);
                        WriteColor(writer, color);
                    }
                }
            }

            Console.WriteLine("Рендеринг завершено!!! Переглянути зображення можна в файлах...");
        }

        private static Vec3 RayColor(Ray r, Hitable world)
        {
            HitRecord rec;
            if (world.Hit(r, 0.001, double.MaxValue, out rec))
            {
                Vec3 N = rec.Normal;
                return new Vec3(N.X + 1, N.Y + 1, N.Z + 1).Multiply(0.5);
            }

            Vec3 rayDirection = r.Direction.Unit();
            double t = 0.5 * (rayDirection.Y + 1);
            return new Vec3(1, 1, 1).Multiply(1 - t).Add(new Vec3(0, 0, 1).Multiply(t));
        }


        private static void WriteColor(StreamWriter writer, Vec3 color)
        {
            int red = (int)(color.X * Colors);
            int green = (int)(color.Y * Colors);
            int blue = (int)(color.Z * Colors);

            string rgbLine = red + " " + green + " " + blue;

            writer.WriteLine(rgbLine);
        }

    }
}
