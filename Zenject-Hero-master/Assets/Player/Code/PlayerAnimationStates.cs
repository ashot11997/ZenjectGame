﻿using System;
using UnityEngine;

namespace Player.Code
{
    public class PlayerAnimationStates
    {
        public enum State
        {
            Spawn,
            PlayerReady,
            Idle,
            Fly,
            Run,
            Die
        }

        private readonly Animator _animator;

        private readonly PlayerModel _playerModel;

        public PlayerAnimationStates(Animator animator)
        {
            _animator = animator;
        }

        public void SetAnimator(State state)
        {
            ResetAnimationStates();

            switch (state)
            {
                case State.Spawn:
                    _animator.SetBool("IsSpawning", true);
                    break;

                case State.PlayerReady:
                    _animator.SetBool("IsPlayerReady", true);
                    break;

                case State.Idle:
                    _animator.SetBool("IsIdle", true);
                    break;

                case State.Fly:
                    _animator.SetBool("IsFlying", true);
                    break;

                case State.Run:
                    _animator.SetBool("IsRunning", true);
                    break;

                case State.Die:
                    _animator.SetBool("IsDead", true);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void ResetAnimationStates()
        {
            _animator.SetBool("IsSpawning", false);
            _animator.SetBool("IsIdle", false);
            _animator.SetBool("IsFlying", false);
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsDead", false);
        }
    }
}