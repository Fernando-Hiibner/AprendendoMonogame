using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AprendendoMonogame_1.Scripts.General
{
    public class Sprite
    {
        // Texture related
        public Texture2D Texture;
        public Vector2 Scale = Vector2.One;
        public Pivot PivotPoint;
        public Color ColorBlend = Color.White;

        public Sprite()
        {
            Texture = Game1.DefaultSquareTexture;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height));
        }
        public Sprite(Texture2D _texture)
        {
            Texture = _texture;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height));
        }
        public Sprite(Vector2 customPivot)
        {
            Texture = Game1.DefaultSquareTexture;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height), customPivot);
        }
        public Sprite(Texture2D _texture, Vector2 customPivot)
        {
            Texture = _texture;
            PivotPoint = new Pivot(new Vector2(Texture.Width, Texture.Height), customPivot);
        }

        public void Draw(Vector2 Position)
        {
            Game1._spriteBatch.Draw(Texture, Position, null, ColorBlend, 0f, PivotPoint.Center, Scale, SpriteEffects.None, 0f);
        }
    }
}
