using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Ray
    {
        public Vec3 Origin;
        public Vec3 Direction;

        public Ray(Vec3 o, Vec3 d)
        {
            Origin = o;
            Direction = d;
        }

        public Vec3 GetDistanc(double t)
        {
            return Origin.Add(Direction.Multiply(t));
        }
    }
}
