using System;
using System.Windows.Media.Media3D;

namespace Surfaces
{
    public sealed class Circle : Surface
    {
        private static PropertyHolder<double, Circle> RadiusProperty =
            new PropertyHolder<double, Circle>("Radius", 1.0, OnGeometryChanged);

        public double Radius
        {
            get { return RadiusProperty.Get(this); }
            set { RadiusProperty.Set(this, value); }
        }

        private static PropertyHolder<Point3D, Circle> PositionProperty =
            new PropertyHolder<Point3D, Circle>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

        public Point3D Position
        {
            get { return PositionProperty.Get(this); }
            set { PositionProperty.Set(this, value); }
        }

        private double _radius;
        private Point3D _position;

        private Point3D PointForAngle(double angle)
        {
            return new Point3D(this._position.X + this._radius*Math.Cos(angle), this._position.Y + this._radius*Math.Sin(angle), this._position.Z);
        }

        protected override Geometry3D CreateMesh()
        {
            this._radius = this.Radius;
            this._position = this.Position;

            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D prevPoint = this.PointForAngle(0);
            Vector3D normal = new Vector3D(0, 0, 1);

            const int div = 180;
            for (int i = 1; i <= div; ++i)
            {
                double angle = 2 * Math.PI / div * i;
                Point3D newPoint = this.PointForAngle(angle);
                mesh.Positions.Add(prevPoint);
                mesh.Positions.Add(this._position);
                mesh.Positions.Add(newPoint);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                prevPoint = newPoint;
            }

            mesh.Freeze();
            return mesh;
        }
    }
}
