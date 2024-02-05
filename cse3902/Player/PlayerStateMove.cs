using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateMove : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite movingLeftSprite;
        private Sprite movingRightSprite;
        private Sprite movingUpSprite;
        private Sprite movingDownSprite;
        private Sprite currentSprite; // will reference one of the above sprites


        public PlayerStateMove(Game1 game, Player player)
        {
            Debug.WriteLine("[info] player entered move state");
            this.game = game;
            this.player = player;
            movingLeftSprite = new Sprite(game.ContentSpritesheetLink);
            movingRightSprite = new Sprite(game.ContentSpritesheetLink);
            movingUpSprite = new Sprite(game.ContentSpritesheetLink);
            movingDownSprite = new Sprite(game.ContentSpritesheetLink);
            // TODO: set frame data of MovingLeftSprite, spriteMovingRightSprite, MovingUpSprite, and MovingDownSprite
            currentSprite = movingRightSprite; // just a default value
        }

        public void Update(GameTime gameTime, IController controller)
        {
            /* move player if any movement key is pressed */
            if (controller.isPlayerMoveLeftPress() == true)
            {
                currentSprite  = movingLeftSprite;
                player.Position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (controller.isPlayerMoveRightPress() == true)
            {
                currentSprite = movingRightSprite;
                player.Position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if(controller.isPlayerMoveUpPress() == true)
            {
                currentSprite = movingUpSprite;
                player.Position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if( controller.isPlayerMoveDownPress() == true)
            {
                currentSprite = movingDownSprite;
                player.Position.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            /* change to idle state if no movement keys are pressed */
            else
            {
                player.State = new PlayerStateIdle(game, player);
            }

            currentSprite.Update(game, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.SetPosition(player.Position.X, player.Position.Y);
            currentSprite.Draw(spriteBatch);
        }
    }
}
