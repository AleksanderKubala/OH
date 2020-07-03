using System;

namespace Asset.OnlyHuman.Characters
{
    public class PlayerController : EntityController
    {
        #region Events

        private EventHandler PlayerMovementCalled;

        #endregion

        #region UnityLoop

        // Start is called before the first frame update
        void Start()
        {
            //CharacterBody.RegisterBodypart(GetComponentsInChildren<IBodypart>());
        }

        #endregion

        #region Methods

        void OnMouseDown()
        {
            PlayerMovementCalled?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}

