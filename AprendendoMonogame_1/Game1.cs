using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

using AprendendoMonegame_1.Scripts;

namespace AprendendoMonegame_1
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        private List<Sprite> instanceManager;

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
            Texture2D defaultTexture = Content.Load<Texture2D>("Sprites/Placeholders/DefaultTexture");


            // Instantiate items
            instanceManager = new List<Sprite>()
            {
                new Sprite(defaultTexture)
                {
                    Alias = "Quadrado Branco",

                    Speed = 200f,
                    ContainType = Sprite.ContainTypes.Contain,

                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D
                    },
                },
                new Sprite(defaultTexture)
                {
                    Alias = "Quadrado Vermelho",

                    ColorBlend = Color.Red,

                    Position = new Vector2(16, 0),
                    Speed = 30f,
                    ContainType = Sprite.ContainTypes.Warp,

                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right
                    },
                },
            };

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(Sprite sprite in instanceManager)
            {
                sprite.Update(gameTime);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (Sprite sprite in instanceManager)
            {
                sprite.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
