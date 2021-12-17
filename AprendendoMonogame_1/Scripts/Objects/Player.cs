using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using AprendendoMonogame_1.Scripts.General;
using System;

namespace AprendendoMonogame_1.Scripts.Objects
{
    public class Player : Object2D
    {
        // Controller related
        public Input Input;

        // Atributes
        public float Speed = 100f;

        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;

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

            // Basic Movement (Traditional top view eight movement)
            //if (Keyboard.GetState().IsKeyDown(Input.Up))
            //{
            //    // Up
            //    Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //if (Keyboard.GetState().IsKeyDown(Input.Down))
            //{
            //    // Down
            //    Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //if (Keyboard.GetState().IsKeyDown(Input.Left))
            //{
            //    // Left
            //    Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}
            //if (Keyboard.GetState().IsKeyDown(Input.Right))
            //{
            //    // Right
            //    Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //}

            // Rotation
            if(Keyboard.GetState().IsKeyDown(Input.RotateLeft))
            {
                Rotation -= MathHelper.ToRadians(RotationVelocity);
            }
            else if(Keyboard.GetState().IsKeyDown(Input.RotateRight))
            {
                Rotation += MathHelper.ToRadians(RotationVelocity);
            }

            // Basic Movement (Traditional asteroid game movement)
            var direction = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));

            if(Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Position += direction * LinearVelocity;
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
            else if (ContainType == ContainTypes.Warp)
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
