using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    internal interface IMaterial
    {
        bool Scatter(Ray rIn, HitRecord rec, out Vec3 attenuation, out Ray scattered);
    }
}
