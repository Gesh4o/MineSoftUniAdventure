using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

// IAddChild, ContentPropertyAttribute
namespace Microsoft._3DTools
{
    public class TrackballDecorator : Viewport3DDecorator
    {
        public TrackballDecorator()
        {
            // the transform that will be applied to the viewport 3d's camera
            this._transform = new Transform3DGroup();
            this._transform.Children.Add(this._scale);
            this._transform.Children.Add(new RotateTransform3D(this._rotation));

            // used so that we always get events while activity occurs within
            // the viewport3D
            this._eventSource = new Border();
            this._eventSource.Background = Brushes.Transparent;

            this.PreViewportChildren.Add(this._eventSource);
        }

        /// <summary>
        ///     A transform to move the camera or scene to the trackball's
        ///     current orientation and scale.
        /// </summary>
        public Transform3D Transform
        {
            get { return this._transform; }
        }

        #region Event Handling

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            this._previousPosition2D = e.GetPosition(this);
            this._previousPosition3D = this.ProjectToTrackball(this.ActualWidth, this.ActualHeight, this._previousPosition2D);
            if (Mouse.Captured == null)
            {
                Mouse.Capture(this, CaptureMode.Element);
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.IsMouseCaptured)
            {
                Mouse.Capture(this, CaptureMode.None);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.IsMouseCaptured)
            {
                Point currentPosition = e.GetPosition(this);

                // avoid any zero axis conditions
                if (currentPosition == this._previousPosition2D) return;

                // Prefer tracking to zooming if both buttons are pressed.
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.Track(currentPosition);
                }
                else if (e.RightButton == MouseButtonState.Pressed)
                {
                    this.Zoom(currentPosition);
                }

                this._previousPosition2D = currentPosition;

                Viewport3D viewport3D = this.Viewport3D;
                if (viewport3D != null)
                {
                    if (viewport3D.Camera != null)
                    {
                        if (viewport3D.Camera.IsFrozen)
                        {
                            viewport3D.Camera = viewport3D.Camera.Clone();
                        }

                        if (viewport3D.Camera.Transform != this._transform)
                        {
                            viewport3D.Camera.Transform = this._transform;
                        }
                    }
                }
            }
        }

        #endregion Event Handling

        private void Track(Point currentPosition)
        {
            Vector3D currentPosition3D = this.ProjectToTrackball(this.ActualWidth, this.ActualHeight, currentPosition);

            Vector3D axis = Vector3D.CrossProduct(this._previousPosition3D, currentPosition3D);
            double angle = Vector3D.AngleBetween(this._previousPosition3D, currentPosition3D);

            // quaterion will throw if this happens - sometimes we can get 3D positions that
            // are very similar, so we avoid the throw by doing this check and just ignoring
            // the event 
            if (axis.Length == 0) return;

            Quaternion delta = new Quaternion(axis, -angle);

            // Get the current orientantion from the RotateTransform3D
            AxisAngleRotation3D r = this._rotation;
            Quaternion q = new Quaternion(this._rotation.Axis, this._rotation.Angle);

            // Compose the delta with the previous orientation
            q *= delta;

            // Write the new orientation back to the Rotation3D
            this._rotation.Axis = q.Axis;
            this._rotation.Angle = q.Angle;

            this._previousPosition3D = currentPosition3D;
        }

        private Vector3D ProjectToTrackball(double width, double height, Point point)
        {
            double x = point.X / (width / 2);    // Scale so bounds map to [0,0] - [2,2]
            double y = point.Y / (height / 2);

            x = x - 1;                           // Translate 0,0 to the center
            y = 1 - y;                           // Flip so +Y is up instead of down

            double z2 = 1 - x * x - y * y;       // z^2 = 1 - x^2 - y^2
            double z = z2 > 0 ? Math.Sqrt(z2) : 0;

            return new Vector3D(x, y, z);
        }

        private void Zoom(Point currentPosition)
        {
            double yDelta = currentPosition.Y - this._previousPosition2D.Y;
            
            double scale = Math.Exp(yDelta / 100);    // e^(yDelta/100) is fairly arbitrary.

            this._scale.ScaleX *= scale;
            this._scale.ScaleY *= scale;
            this._scale.ScaleZ *= scale;
        }

        // --------------------------------------------------------------------
        // Private data
        // --------------------------------------------------------------------
        private Point _previousPosition2D;
        private Vector3D _previousPosition3D = new Vector3D(0, 0, 1);

        private Transform3DGroup _transform;
        private ScaleTransform3D _scale = new ScaleTransform3D();
        private AxisAngleRotation3D _rotation = new AxisAngleRotation3D();

        private Border _eventSource;        
    }
}
