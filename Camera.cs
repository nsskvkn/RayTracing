using System;

namespace RayTracer
{
    public class Camera
    {
        private Vec3 Origin;
        private Vec3 LowerLeftCorner;
        private Vec3 Horizontal;
        private Vec3 Vertical;

        public Camera()
        {
            double aspectRatio = 21 / 9;
            double viewportHeight = 2;
            double viewportWidth = aspectRatio * viewportHeight;
            double focalLength = 1;

            Origin = new Vec3(0, 0, 0);
            Horizontal = new Vec3(viewportWidth, 0, 0);
            Vertical = new Vec3(0, viewportHeight, 0);

            Vec3 H = Horizontal.Divide(2);
            Vec3 V = Vertical.Divide(2);
            Vec3 focus = new Vec3(0, 0, focalLength);

            Vec3 leftEdge = Origin.Subtract(H);
            Vec3 lowerLeftNoFocus = leftEdge.Subtract(V);
            LowerLeftCorner = lowerLeftNoFocus.Subtract(focus);

        }

        public Ray GetRay(double u, double v)
        {
            Vec3 uHoriz = Horizontal.Multiply(u);
            Vec3 vVert = Vertical.Multiply(v);
            Vec3 horizontalOffset = LowerLeftCorner.Add(uHoriz);
            Vec3 fullOffset = horizontalOffset.Add(vVert);
            Vec3 rayDirect = fullOffset.Subtract(Origin);

            Ray ray = new Ray(origin, direction);
        }

    }
}