using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class Player : IPlayer
    {
        private enum PlayerState
        {
            Idle,
            Attack,
            Walk
        }

        private PlayerState currentState;
        private PlayerState previousState;

        private List<IItem> items;
        private int idxItem;

        private Sprite playerSprite; // Reference to the player's sprite

        public Player(ContentManager content)
        {
            currentState = PlayerState.Idle;
            previousState = PlayerState.Idle;

            items = new List<IItem>();
            idxItem = 0;
        }

        public void Update(GameTime gameTime)
        {
            switch (currentState)
            {
                case PlayerState.Idle:
                    UpdateIdleState(gameTime);
                    break;

                case PlayerState.Attack:
                    UpdateAttackState(gameTime);
                    break;

                case PlayerState.Walk:
                    UpdateWalkState(gameTime);
                    break;

                    // Add additional states and corresponding update methods as needed
            }
        }

        public void MoveUp()
        {
            ChangeState(PlayerState.Walk);
            // Update sprite position for movement
            playerSprite.Y -= 1;
        }

        public void MoveDown()
        {
            ChangeState(PlayerState.Walk);
            // Update sprite position for movement
            playerSprite.Y += 1;
        }

        public void MoveLeft()
        {
            ChangeState(PlayerState.Walk);
            // Update sprite position for movement
            playerSprite.X -= 1;
        }

        public void MoveRight()
        {
            ChangeState(PlayerState.Walk);
            // Update sprite position for movement
            playerSprite.X += 1;
        }

        public void Attack()
        {
            ChangeState(PlayerState.Attack);
            // Example: Trigger attack animation or perform other attack-related actions on the sprite
            playerSprite.SetState("attack");
        }

        private void UpdateIdleState(GameTime gameTime)
        {
            // Example: Implement logic for the Idle state
        }

        private void UpdateAttackState(GameTime gameTime)
        {
            // Example: Implement logic for the Attack state
        }

        private void UpdateWalkState(GameTime gameTime)
        {
            // Example: Implement logic for the Walk state
        }

        private void ChangeState(PlayerState newState)
        {
            previousState = currentState;
            currentState = newState;
        }

        public void UseItem()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage()
        {
            throw new NotImplementedException();
        }

        public void BlockCycle()
        {
            throw new NotImplementedException();
        }

        public void ItemCycle()
        {
            throw new NotImplementedException();
        }

        public void CharacterCycle()
        {
            throw new NotImplementedException();
        }
    }
}
