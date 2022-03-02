using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using AprendendoMonogame_1.Scripts.General;
using AprendendoMonogame_1.Scripts.Prefabs;

namespace AprendendoMonogame_1.Scripts.Objects
{
    public class Player : Object2D
    {
        // Controller related
        public Input Input;
        public MovementController movementController;

        public enum PrefabControllerTypes
        {
            None,
            EightDirectionsTopDown,
            DirectionBasedTopDown,
        }

        public PrefabControllerTypes PrefabControllerType = PrefabControllerTypes.None;

        // Atributes
        public float Speed = 100f;

        public float RotationVelocity = 3f;
        public float LinearVelocity = 4f;

        public override void Update(GameTime gameTime)
        {
            if (movementController == null)
            {
                switch (PrefabControllerType) {
                    case PrefabControllerTypes.None:
                        movementController = new MovementController();
                        break;
                    case PrefabControllerTypes.EightDirectionsTopDown:
                        movementController = new EightDirectionsTopDown(this, Input, Speed);
                        break;
                    case PrefabControllerTypes.DirectionBasedTopDown:
                        movementController = new DirectionBasedTopDown(this, Input, Speed, RotationVelocity, LinearVelocity);
                        break;
                }
            }
            movementController.Move(gameTime);

            base.Update(gameTime);
        }
    }
}
