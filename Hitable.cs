using System;
using System.Collections.Generic;

namespace RayTracer
{
    public class Hitable : IHitable
    {
        public List<IHitable> Objects;

        public Hitable()
        {
            Objects = new List<IHitable>();
        }

        public void Add(IHitable obj)
        {
            Objects.Add(obj);
        }

        public bool Hit(Ray ray, double tMin, double tMax, out HitRecord hitRec)
        {
            hitRec = new HitRecord();
            bool hitAnything = false;
            double closestSoFar = tMax;

            foreach (IHitable obj in Objects)
            {
                HitRecord tempRec;
                if (obj.Hit(ray, tMin, closestSoFar, out tempRec))
                {
                    hitAnything = true;
                    closestSoFar = tempRec.T;
                    hitRec = tempRec;
                }
            }

            return hitAnything;
        }
    }
}
