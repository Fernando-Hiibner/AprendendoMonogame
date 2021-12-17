using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using AprendendoMonogame_1.Scripts.General;

namespace AprendendoMonogame_1.Scripts.Primitives
{
    public class Square : Object2D
    {
        public Square()
        {
            Texture = Game1.DefaultTextures.Square;
        }
    }

    public class Circle : Object2D
    {
        public Circle()
        {
            Texture = Game1.DefaultTextures.Circle;
        }
    }

    public class Triangle : Object2D
    {
        public Triangle()
        {
            Texture = Game1.DefaultTextures.Triangle;
        }
    }
}
