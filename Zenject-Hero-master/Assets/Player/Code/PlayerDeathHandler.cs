using Code;
using UI.GameOver;
using UI.Lives.Code;
using Zenject;

namespace Player.Code
{
    public class PlayerDeathHandler
    {
        private readonly LivesCounter _livesCounter;
        private readonly PlayerAnimationStates _playerAnimationStates;
        private readonly PlayerModel _playerModel;

        [Inject] private readonly SignalBus _signalBus = null;

        public PlayerDeathHandler(
            PlayerModel playerModel,
            LivesCounter livesCounter,
            PlayerAnimationStates playerAnimationStates)
        {
            _playerModel = playerModel;
            _livesCounter = livesCounter;
            _playerAnimationStates = playerAnimationStates;
        }

        public void ReSpawn()
        {
            _playerModel.IsDead = false;
        }

        public void Die()
        {
            
            _livesCounter.SubtractLive();
            if (_livesCounter.LivesLeft <= 0)
            {
                _signalBus.Fire(new GameOverSignal(true));
                _playerModel.IsDead = true;
                _playerAnimationStates.SetAnimator(PlayerAnimationStates.State.Die);
            }
            else
            {
                ReSpawn();
            }
        }
    }
}