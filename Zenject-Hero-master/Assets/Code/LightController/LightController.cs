﻿using System.Collections.Generic;
using Explodables.CaveIn.Contracts;
using FlipScreen.Code;
using NPCs.Enemies.Contracts;
using NPCs.Miner.Code;
using Player.Code;
using UnityEngine;
using Weapons.Laser.Code;
using Zenject;

namespace Code.LightController
{
    public class LightController : MonoBehaviour
    {
        private readonly List<Vector2> _obscuredScreens = new List<Vector2>();

        [Inject] private readonly PlayerFacade _playerFacade = null;

        private void Update()
        {
            SetPlayerShaderForCurrentScreen();
        }

        public void TurnOffLightInCurrentScreen()
        {
            Vector2 currentScreenPos = GetComponentInParent
                <FlipScreenManager>().transform.position;
            
            if (!_obscuredScreens.Contains(currentScreenPos))
            {
                _obscuredScreens.Add(currentScreenPos);
            }
            
            ObscureGameObjects(currentScreenPos);
        }

        private void ObscureGameObjects(Vector2 currentScreenPos)
        {
            var collider2Ds = GetAllColliders(currentScreenPos);

            foreach (var c in collider2Ds)
            {
                var spriteRenderer = c.gameObject.GetComponentInChildren<SpriteRenderer>();
                Obscure(spriteRenderer);
            }
        }

        private IEnumerable<Collider2D> GetAllColliders(Vector2 flipScreenPosition)
        {
            var boxOffset = new Vector2(0, 3);
            var boxCenterPos = flipScreenPosition + boxOffset;

            const float horizontalUnits = 12f;
            const float verticalUnits = 5f;
            var boxSize = new Vector2(horizontalUnits, verticalUnits);

            var collidingObjects = Physics2D.OverlapBoxAll(boxCenterPos, boxSize, 0);
            
            return collidingObjects;
        }

        private void SetPlayerShaderForCurrentScreen()
        {
            var playerSprite = _playerFacade.GetComponentInChildren<SpriteRenderer>();
                
            if (_obscuredScreens.Contains(
                GetComponentInParent<FlipScreenManager>().transform.position))
            {
                Obscure(playerSprite);
            }
            else
            {
                playerSprite.material.color = Color.white;
                playerSprite.material.shader = Shader.Find("Sprites/Default");
            }
        }
        
        private void Obscure(SpriteRenderer sprite)
        {
            if (sprite == null) return;

            if (sprite.gameObject.GetComponentInParent<PlayerFacade>() ||
                sprite.gameObject.GetComponentInParent<Killable>() ||
                sprite.gameObject.GetComponentInParent<Lamp.Code.Lamp>() ||
                sprite.gameObject.GetComponentInParent<Explodable>() ||
                sprite.gameObject.GetComponentInParent<Miner>())
            {
                sprite.material.shader = Shader.Find("GUI/Text Shader");
                sprite.material.color = Color.blue;
            }
            else
            {
                if (sprite.gameObject.GetComponentInParent<Laser>()) return;
                
                sprite.material.shader = Shader.Find("GUI/Text Shader");
                sprite.color = Color.black;
            }
        }
    }
}
