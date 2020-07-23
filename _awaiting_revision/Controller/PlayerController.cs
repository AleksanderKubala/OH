using System;
using OHLogic.Body;
using OHLogic.Movement;

namespace Asset.OnlyHuman.Characters
{
    public class PlayerController : EntityController
    {
        private EventHandler PlayerMovementCalled;

        void Start()
        {
            CharacterBody.RegisterBodypart(GetComponentsInChildren<IBodypart>());
            PlayerMovementCalled += movementController.GetState<AutomatedMovement>().OnPlayerMovementCalled;
            PlayerMovementCalled?.Invoke(this, EventArgs.Empty);
        }

        void OnMouseDown()
        {
            PlayerMovementCalled?.Invoke(this, EventArgs.Empty);
        }
    }
}

