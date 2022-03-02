using Microsoft.Xna.Framework;
using AprendendoMonogame_1.Scripts.General;

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

        public Contain Contain;

        public virtual void Update(GameTime gameTime)
        {
            if(Contain == null)
            {
                Contain = new Contain(this);
            }

            Contain.Update();
        }
    }
}
