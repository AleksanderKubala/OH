using UnityEngine;

namespace Assets.GameEntity
{
    [CreateAssetMenu(fileName = "Game Entity Id", menuName = "Game Entities/ID")]
    public class GameEntityIdentifier : ScriptableObject
    {
        [SerializeField]
        private GameEntityType _gameEntityType;

        public GameEntityType GameEntityType => _gameEntityType;
    }
}
