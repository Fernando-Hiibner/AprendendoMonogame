using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AprendendoMonogame_1.Scripts.General
{
    public class Sprite
    {
        // Transform related
        public Vector2 Position = Vector2.Zero;
        public float Rotation = 0f;

        // Texture related
        public Texture2D Texture;
        public Vector2 Scale = Vector2.One;
        public Pivot PivotPoint;
        public Color ColorBlend = Color.White;

        public Sprite()
        {
            Texture = Game1.DefaultTextures.Square;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height));
        }
        public Sprite(Texture2D _texture)
        {
            Texture = _texture;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height));
        }
        public Sprite(Vector2 customPivot)
        {
            Texture = Game1.DefaultTextures.Square;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height), customPivot);
        }
        public Sprite(Texture2D _texture, Vector2 customPivot)
        {
            Texture = _texture;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height), customPivot);
        }

        public void Draw()
        {
            Game1._spriteBatch.Draw(Texture, Position, null, ColorBlend, Rotation, PivotPoint.Center, Scale, SpriteEffects.None, 0f);
        }
    }
}
