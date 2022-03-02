// XNA Namespaces
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

// Others Namespaces
using System.Collections.Generic;

// Project Namespaces
using AprendendoMonogame_1.Scripts.General;
using AprendendoMonogame_1.Scripts.Objects;

namespace AprendendoMonogame_1
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        // Default Contents
        public static Defaults DefaultTextures;

        private List<Object2D> instanceManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Contents
            DefaultTextures = new Defaults()
            {
                Square = Content.Load<Texture2D>("Sprites/Defaults/DefaultSquare"),
                Circle = Content.Load<Texture2D>("Sprites/Defaults/DefaultCircle"),
                Triangle = Content.Load<Texture2D>("Sprites/Defaults/DefaultTriangle"),
            };

            // Instantiate items
            instanceManager = new List<Object2D>()
            {
                new Player()
                {
                    Alias = "Player 1",

                    Speed = 200f,
                    PrefabControllerType = Player.PrefabControllerTypes.DirectionBasedTopDown,
                    
                    ContainType = Object2D.ContainTypes.Contain,

                    Texture = DefaultTextures.Triangle,
                    ColorBlend = Color.Red,

                    Input = new Input()
                    {
                        // Movement
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D,

                        // Rotation
                        RotateLeft = Keys.Q,
                        RotateRight = Keys.E,
                    }
                },
                new Player()
                {
                    Alias = "Player 2",

                    Speed = 100f,
                    PrefabControllerType = Player.PrefabControllerTypes.EightDirectionsTopDown,

                    ContainType = Object2D.ContainTypes.Warp,

                    Texture = DefaultTextures.Circle,
                    ColorBlend = Color.Green,

                    Input = new Input()
                    {
                        // Movement
                        Up = Keys.I,
                        Down = Keys.K,
                        Left = Keys.J,
                        Right = Keys.L,

                        // Rotation
                        RotateLeft = Keys.U,
                        RotateRight = Keys.O,
                    }
                },
            };

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (Object2D obj in instanceManager)
            {
                obj.Update(gameTime);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (Object2D obj in instanceManager)
            {
                obj.Draw();
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
