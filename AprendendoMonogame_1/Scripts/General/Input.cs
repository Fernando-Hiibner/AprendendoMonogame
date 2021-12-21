using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AprendendoMonogame_1.Scripts.General
{
    public class Input
    {
        // Basic movement
        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Left { get; set; }
        public Keys Right { get; set; }

        // Rotation
        public Keys RotateLeft { get; set; }
        public Keys RotateRight { get; set; }
    }
}
