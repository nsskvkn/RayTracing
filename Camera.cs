namespace RayTracer
{
    public class Camera
    {
        private Vec3 origin;
        private Vec3 lowerLeftCorner;
        private Vec3 horizontal;
        private Vec3 vertical;

        public Camera()
        {
            origin = new Vec3(0, 0, 0);
            lowerLeftCorner = new Vec3(-2, -1, -1);
            horizontal = new Vec3(4, 0, 0);
            vertical = new Vec3(0, 2, 0);
        }

        public Ray GetRay(double u, double v)
        {
            Vec3 direction = lowerLeftCorner.Add(horizontal.Multiply(u)).Add(vertical.Multiply(v)).Sub(origin);
            direction = direction.Unit();

            Ray ray = new Ray(origin, direction);
            return ray;
        }
    }
}
