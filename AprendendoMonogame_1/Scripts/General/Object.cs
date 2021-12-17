using Microsoft.Xna.Framework;

using System;

namespace AprendendoMonogame_1.Scripts.General
{
    public class Object
    {
        // Identification related
        public string Alias = "UNNAMED OBJECT";

        // Texture related
        public Sprite Sprite = new Sprite();

        // Transform related
        public Vector2 Position = Vector2.Zero;

        // Colision and Physics
        public enum ContainTypes
        {
            None,
            Contain,
            Warp
        }
        public ContainTypes ContainType = ContainTypes.None;

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {
            Sprite.Draw(Position);
        }
    }
}
