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

        public bool Hit(Ray ray, double mint, double maxt, out HitRecord hitReс)
        {
            hitReс = new HitRecord();
            bool isAny = false;
            double hitDistanc = maxt;

            foreach (IHitable item in Objects)
            {
                HitRecord tempRecord;

                if (item.Hit(ray, mint, maxt, out tempRecord))
                {
                    isAny = true;
                    hitDistanc = tempRecord.t;
                    hitReс = tempRecord;
                }
            }
                return isAny;
            }
        }
    }