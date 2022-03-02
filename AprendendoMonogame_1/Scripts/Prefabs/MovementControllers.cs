using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using AprendendoMonogame_1.Scripts.General;

namespace AprendendoMonogame_1.Scripts.Prefabs
{

    public class MovementController
    {
        // This class hole purpose is to encapsulate all MovementController classes in one type
        public virtual void Move(GameTime gameTime)
        {

        }
    }
    /// <summary>
    /// Way more traditional Up, Right, Left, Right, and 45º Diagonals Style
    /// </summary>
    public class EightDirectionsTopDown : MovementController
    {
        private Object2D Master;

        public Input Input = new Input()
        {
            // Movement
            Up = Keys.W,
            Down = Keys.S,
            Left = Keys.A,
            Right = Keys.D,
        };
        public float Speed = 100f;
        public EightDirectionsTopDown(Object2D master, Input input, float speed)
        {
            Speed = speed;
            Input = input;
            Master = master;
        }

        public override void Move(GameTime gameTime)
        {
            if (Input == null)
            {
                return;
            }

            // Basic Movement (Traditional top view eight movement)
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                // Up
                Master.Position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                // Down
                Master.Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                // Left
                Master.Position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                // Right
                Master.Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }

    /// <summary>
    /// Like Asteroid Game
    /// </summary>
    public class DirectionBasedTopDown : MovementController
    {
        private Object2D Master;

        public Input Input = new Input()
        {
            // Movement
            Up = Keys.W,

            // Rotation
            RotateLeft = Keys.Q,
            RotateRight = Keys.E,
        };
        public float Speed = 100f;
        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;

        public DirectionBasedTopDown(Object2D master)
        {
            Master = master;
        }
        public DirectionBasedTopDown(Object2D master, Input input)
        {
            Master = master;
            Input = input;
        }
        public DirectionBasedTopDown(Object2D master, Input input, float speed)
        {
            Master = master;
            Input = input;
            Speed = speed;
        }
        public DirectionBasedTopDown(Object2D master, Input input, float speed, float rotationVelocity, float linearVelocity)
        {
            Master = master;
            Input = input;
            Speed = speed;
            RotationVelocity = rotationVelocity;
            LinearVelocity = linearVelocity;
        }

        public override void Move(GameTime gameTime)
        {
            if(Input == null)
            {
                return;
            }
            // Rotation
            if (Keyboard.GetState().IsKeyDown(Input.RotateLeft))
            {
                Master.Rotation -= MathHelper.ToRadians(RotationVelocity);
            }
            else if (Keyboard.GetState().IsKeyDown(Input.RotateRight))
            {
                Master.Rotation += MathHelper.ToRadians(RotationVelocity);
            }

            // Basic Movement (Traditional asteroid game movement)
            var direction = new Vector2((float)Math.Cos(Master.Rotation), (float)Math.Sin(Master.Rotation));

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Master.Position += direction * LinearVelocity;
            }
        }
    }
}
