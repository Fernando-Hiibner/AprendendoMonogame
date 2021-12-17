using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using AprendendoMonogame_1.Scripts.General;

namespace AprendendoMonogame_1.Scripts.Objects
{
    public class Player : Object2D
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

            if (ContainType == Object2D.ContainTypes.Contain)
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
            else if (ContainType == Object2D.ContainTypes.Warp)
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
    }
}
