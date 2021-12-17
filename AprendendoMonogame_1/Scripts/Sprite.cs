using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace AprendendoMonegame_1.Scripts
{
    public class Sprite
    {
        // Identification related
        public string Alias;

        // Texture related
        public Texture2D Texture;
        public Vector2 Scale = Vector2.One;
        public Pivot PivotPoint;
        public Color ColorBlend = Color.White;

        // Transform related
        public Vector2 Position = Vector2.Zero;
        public float Speed = 0f;

        // Colision and Physics
        public enum ContainTypes
        {
            None,
            Contain,
            Warp
        }
        public ContainTypes ContainType = ContainTypes.None;

        // Controller related
        public Input Input;

        public Sprite(Texture2D _texture)
        {
            Texture = _texture;
            PivotPoint = new Pivot(new Vector2(_texture.Width, _texture.Height));
        }
        public Sprite(Texture2D _texture, Vector2 customPivot)
        {
            Texture = _texture;
            PivotPoint = new Pivot(new Vector2(_texture.Width, _texture.Height), customPivot);
        }

        public void Update(GameTime gameTime)
        {
            Move(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            if(Input == null)
            {
                return;
            }


            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                // Up
                Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                // Down
                Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                // Left
                Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                // Right
                Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (ContainType == ContainTypes.Contain)
            {
                // Checking the X
                if (Position.X > Game1._graphics.PreferredBackBufferWidth - Texture.Width * Scale.X / 2)
                    Position.X = Game1._graphics.PreferredBackBufferWidth - Texture.Width * Scale.X / 2;
                else if (Position.X < Texture.Width * Scale.X / 2)
                    Position.X = Texture.Width * Scale.X / 2;

                // Checking the Y
                if (Position.Y > Game1._graphics.PreferredBackBufferHeight - Texture.Height * Scale.Y / 2)
                    Position.Y = Game1._graphics.PreferredBackBufferHeight - Texture.Height * Scale.Y / 2;
                else if (Position.Y < Texture.Height * Scale.Y / 2)
                    Position.Y = Texture.Height * Scale.Y / 2;
            }
            else if(ContainType == ContainTypes.Warp)
            {
                // Checking the X
                if (Position.X > Game1._graphics.PreferredBackBufferWidth - Texture.Width * Scale.X / 2)
                    Position.X = Texture.Width * Scale.X / 2;
                else if (Position.X < Texture.Width * Scale.X / 2)
                    Position.X = Game1._graphics.PreferredBackBufferWidth - Texture.Width * Scale.X / 2;

                // Checking the Y
                if (Position.Y > Game1._graphics.PreferredBackBufferHeight - Texture.Height * Scale.Y / 2)
                    Position.Y = Texture.Height * Scale.Y / 2;
                else if (Position.Y < Texture.Height * Scale.Y / 2)
                    Position.Y = Game1._graphics.PreferredBackBufferHeight - Texture.Height * Scale.Y / 2;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, ColorBlend, 0f, PivotPoint.Center, Scale, SpriteEffects.None, 0f);
        }
    }
}
