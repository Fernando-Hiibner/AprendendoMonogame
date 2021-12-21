using Microsoft.Xna.Framework;

using System;

namespace AprendendoMonogame_1.Scripts.General
{
    public class Object2D : Sprite
    {
        // Identification related
        public string Alias = "UNNAMED OBJECT";

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
    }
}
