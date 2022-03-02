using static AprendendoMonogame_1.Scripts.General.Object2D;

namespace AprendendoMonogame_1.Scripts.General
{
    public class Contain
    {
        private Object2D Master;

        public int textureWidth = 0;
        public int textureHeight = 0;

        public float scaleX = 1f;
        public float scaleY = 1f;

        public Contain(Object2D master)
        {
            Master = master;

            if (Master.Texture != null)
            {
                textureWidth = Master.Texture.Width;
                textureHeight = Master.Texture.Height;
            }

            if (Master.Scale != null)
            {
                scaleX = Master.Scale.X;
                scaleY = Master.Scale.Y;
            }
        }

        public void Update()
        {
            if (Master.ContainType == ContainTypes.Contain)
            {
                // Checking the X
                if (Master.Position.X > Game1._graphics.PreferredBackBufferWidth - textureWidth * scaleX / 2)
                    Master.Position.X = Game1._graphics.PreferredBackBufferWidth - textureWidth * scaleX / 2;
                else if (Master.Position.X < textureWidth * scaleX / 2)
                    Master.Position.X = textureWidth * scaleX / 2;

                // Checking the Y
                if (Master.Position.Y > Game1._graphics.PreferredBackBufferHeight - textureHeight * scaleY / 2)
                    Master.Position.Y = Game1._graphics.PreferredBackBufferHeight - textureHeight * scaleY / 2;
                else if (Master.Position.Y < textureHeight * scaleY / 2)
                    Master.Position.Y = textureHeight * scaleY / 2;
            }
            else if (Master.ContainType == ContainTypes.Warp)
            {
                // Checking the X
                if (Master.Position.X > Game1._graphics.PreferredBackBufferWidth - textureWidth * scaleX / 2)
                    Master.Position.X = textureWidth * scaleX / 2;
                else if (Master.Position.X < textureWidth * scaleX / 2)
                    Master.Position.X = Game1._graphics.PreferredBackBufferWidth - textureWidth * scaleX / 2;

                // Checking the Y
                if (Master.Position.Y > Game1._graphics.PreferredBackBufferHeight - textureHeight * scaleY / 2)
                    Master.Position.Y = textureHeight * scaleY / 2;
                else if (Master.Position.Y < textureHeight * scaleY / 2)
                    Master.Position.Y = Game1._graphics.PreferredBackBufferHeight - textureHeight * scaleY / 2;
            }
        }
    }
}
