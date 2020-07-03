using Asset.OnlyHuman.Characters;
using UnityEngine;

namespace Assets.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _player;

        public static PlayerController Player => Instance._player;
        public static GameManager Instance { get; private set; }

        void Awake()
        {
            Instance = this;
        }
    }
}

