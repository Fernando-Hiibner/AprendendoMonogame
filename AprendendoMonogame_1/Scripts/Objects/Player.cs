using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using AprendendoMonogame_1.Scripts.General;

namespace AprendendoMonogame_1.Scripts.Objects
{
    public class Player : Object
    {
        // Controller related
        public Input Input;

        // Atributes
        public float Speed = 0f;

        public override void Update(GameTime gameTime)
        {
            Move(gameTime);

            base.Update(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            if (Input == null)
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

            if (ContainType == Object.ContainTypes.Contain)
            {
                // Checking the X
                if (Position.X > Game1._graphics.PreferredBackBufferWidth - Sprite.Texture.Width * Sprite.Scale.X / 2)
                    Position.X = Game1._graphics.PreferredBackBufferWidth - Sprite.Texture.Width * Sprite.Scale.X / 2;
                else if (Position.X < Sprite.Texture.Width * Sprite.Scale.X / 2)
                    Position.X = Sprite.Texture.Width * Sprite.Scale.X / 2;

                // Checking the Y
                if (Position.Y > Game1._graphics.PreferredBackBufferHeight - Sprite.Texture.Height * Sprite.Scale.Y / 2)
                    Position.Y = Game1._graphics.PreferredBackBufferHeight - Sprite.Texture.Height * Sprite.Scale.Y / 2;
                else if (Position.Y < Sprite.Texture.Height * Sprite.Scale.Y / 2)
                    Position.Y = Sprite.Texture.Height * Sprite.Scale.Y / 2;
            }
            else if (ContainType == Object.ContainTypes.Warp)
            {
                // Checking the X
                if (Position.X > Game1._graphics.PreferredBackBufferWidth - Sprite.Texture.Width * Sprite.Scale.X / 2)
                    Position.X = Sprite.Texture.Width * Sprite.Scale.X / 2;
                else if (Position.X < Sprite.Texture.Width * Sprite.Scale.X / 2)
                    Position.X = Game1._graphics.PreferredBackBufferWidth - Sprite.Texture.Width * Sprite.Scale.X / 2;

                // Checking the Y
                if (Position.Y > Game1._graphics.PreferredBackBufferHeight - Sprite.Texture.Height * Sprite.Scale.Y / 2)
                    Position.Y = Sprite.Texture.Height * Sprite.Scale.Y / 2;
                else if (Position.Y < Sprite.Texture.Height * Sprite.Scale.Y / 2)
                    Position.Y = Game1._graphics.PreferredBackBufferHeight - Sprite.Texture.Height * Sprite.Scale.Y / 2;
            }
        }
    }
}
