﻿using System;
using Explodables.CaveIn.Contracts;
using NPCs.Enemies.Contracts;
using Player.Code;
using UnityEngine;
using Zenject;

namespace Weapons.Laser.Code
{
    public class Laser : MonoBehaviour
    {
        private PlayerFacade _player;

        private Settings _settings;
        private SpriteRenderer _spriteRenderer;

        public bool IsFiring { private get; set; }

        [Inject]
        public void Construct(
            Settings settings,
            PlayerFacade player)
        {
            _settings = settings;
            _player = player;
        }

        private void Start()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        private void Update()
        {
            UpdateLaser();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsFiring) return;

            var killableGo = other.GetComponent<Killable>();
            if (killableGo != null) killableGo.ReceiveDamage(_settings.Damage);

            var explodableGo = other.GetComponent<Explodable>();
            if (explodableGo != null) explodableGo.ReceiveDamage(_settings.Damage);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!IsFiring) return;

            var killableGo = other.GetComponent<Killable>();
            if (killableGo != null) killableGo.ReceiveDamage(_settings.Damage);

            var explodableGo = other.GetComponent<Explodable>();
            if (explodableGo != null) explodableGo.ReceiveDamage(_settings.Damage);
        }

        private void UpdateLaser()
        {
            transform.rotation = _player.IsFacingLeft ? new Quaternion(0, 180f, 0, 0) : new Quaternion(0, 0, 0, 0);
            transform.position = _player.Position;
            _spriteRenderer.enabled = IsFiring;
        }

        [Serializable]
        public class Settings
        {
            public int Damage;
        }
    }
}