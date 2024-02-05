using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateMove : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite MovingLeftSprite;
        private Sprite MovingRightSprite;
        private Sprite MovingUpSprite;
        private Sprite MovingDownSprite;
        private Sprite currentSprite; // will reference one of the above sprites


        public PlayerStateMove(Game1 game, Player player)
        {
            this.game = game;
            this.player = player;
            MovingLeftSprite = new Sprite(game.ContentSpritesheetLink);
            MovingRightSprite = new Sprite(game.ContentSpritesheetLink);
            MovingUpSprite = new Sprite(game.ContentSpritesheetLink);
            MovingDownSprite = new Sprite(game.ContentSpritesheetLink);
            // TODO: set frame data of MovingLeftSprite, spriteMovingRightSprite, MovingUpSprite, and MovingDownSprite
            currentSprite = MovingRightSprite; // just a default value
        }

        public void Update(GameTime gameTime, IController keyboard)
        {
            if (keyboard.isPlayerMoveLeftPress() == true)
            {
                currentSprite  = MovingLeftSprite;
                player.Position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (keyboard.isPlayerMoveRightPress() == true)
            {
                currentSprite = MovingRightSprite;
                player.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if(keyboard.isPlayerMoveUpPress() == true)
            {
                currentSprite = MovingUpSprite;
                player.Position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if( keyboard.isPlayerMoveDownPress() == true)
            {
                currentSprite = MovingDownSprite;
                player.Position.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                player.State = new PlayerStateIdle(game, player);
            }
            
            // TODO: return to idle state if no movement keys are pressed
            // something like:
            /* Temperary comment
            if (no movement keys are pressed)
            {
                player.State = new PlayerStateIdle(game, player);
            }

            // TODO: go to attack state if attack button is pressed
            // something like:
            if (attack button pressed)
            {
                player.State = new PlayerStateAttack(game, player);
            }
            */

            // TODO: move according to movement direction
            UpdateCurrentSprite();
            currentSprite.Update(game, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.SetPosition(player.Position.X, player.Position.Y);
            Debug.WriteLine("it's moving!!!");
            currentSprite.Draw(spriteBatch);
            
        }

        /* sets currentSprite based on the player's velocity */
            private void UpdateCurrentSprite()
        {
            if (player.Velocity.Y < 0) currentSprite = MovingUpSprite;
            if (player.Velocity.Y > 0) currentSprite = MovingDownSprite;
            if (player.Velocity.X < 0) currentSprite = MovingLeftSprite;
            if (player.Velocity.X > 0) currentSprite = MovingRightSprite;
        }
    }
}
