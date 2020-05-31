using UnityEngine;
using Zenject;
using UI.GameWin;

namespace Player.Code
{
    public class PlayerCollision : MonoBehaviour
    {
        private PlayerFacade _playerFacade;
        private PlayerGrounded _playerGrounded;

        private PlayerModel _playerModel;

        /*public PlayerCollision(PlayerModel playerM) {
            _playerModel = playerM;
        }*/

        [Inject]
        public void Construct(
            PlayerGrounded playerGrounded,
            PlayerFacade playerFacade,
            PlayerModel playerM)
        {
            _playerGrounded = playerGrounded;
            _playerFacade = playerFacade;
            _playerModel = playerM;
        }

        [Inject] readonly SignalBus _signalBus;

        private void OnCollisionEnter2D(Collision2D other)
        {
            _playerGrounded.PlayerHitFloor(other);

            if (other.collider.CompareTag("Miner"))
            {
                _playerFacade.HasWon = true;
                Debug.Log("Win!");
                _playerModel.IsDead = true;
                _signalBus.Fire(new GameWinSignal(true));
            }
        }
    }
}