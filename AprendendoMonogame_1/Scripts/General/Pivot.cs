using Microsoft.Xna.Framework;

// This class will handle 2D pivot points
namespace AprendendoMonogame_1.Scripts.General
{
    public class Pivot
    {
        private Vector2 _topLeft = Vector2.Zero; // Equivalent to: new Vector2(0, 0);
        private Vector2 _topRight = new Vector2(1, 0);
        private Vector2 _bottomLeft = new Vector2(0, 1);
        private Vector2 _bottomRight = Vector2.One; // Equivalent to: new Vector2(1, 1);
        private Vector2 _center = new Vector2(0.5f, 0.5f);

        public Vector2 Dimensions;

        public Vector2 TopLeft
        {
            get
            {
                return _topLeft * Dimensions;
            }
        }
        public Vector2 TopRight
        {
            get
            {
                return _topRight * Dimensions;
            }
        }
        public Vector2 BottomLeft
        {
            get
            {
                return _bottomLeft * Dimensions;
            }
        }
        public Vector2 BottomRight
        {
            get
            {
                return _bottomRight * Dimensions;
            }
        }
        public Vector2 Center
        {
            get
            {
                return _center * Dimensions;
            }
        }

        public Vector2 Custom = Vector2.Zero;


        public Pivot(Vector2 dimensions)
        {
            Dimensions = dimensions;
        }

        public Pivot(Vector2 dimensions, Vector2 customPoint)
        {
            Dimensions = dimensions;
            Custom = customPoint;
        }
    }
}
