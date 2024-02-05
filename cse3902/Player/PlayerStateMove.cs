using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class PlayerStateMove : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite spriteMoveLeft;
        private Sprite spriteMoveRight;
        private Sprite spriteMoveUp;
        private Sprite spriteMoveDown;
        private Sprite currentSprite; // will reference one of the above sprites

        public PlayerStateMove(Game1 game, Player player)
        {
            this.player = player;
            spriteMoveLeft = new Sprite(game.ContentSpritesheetLink, game.Content);
            spriteMoveRight = new Sprite(game.ContentSpritesheetLink, game.Content);
            spriteMoveUp = new Sprite(game.ContentSpritesheetLink, game.Content);
            spriteMoveDown = new Sprite(game.ContentSpritesheetLink, game.Content);
            // TODO: set frame data of spriteMoveLeft, spriteMoveRight, spriteMoveUp, and spriteMoveDown
            currentSprite = spriteMoveRight; // just a default value
        }

        public void Update(GameTime gameTime)
        {
            // TODO: return to idle state if no movement keys are pressed
            // something like:
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

            // TODO: move according to movement direction
            UpdateCurrentSprite();
            currentSprite.Update(game, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.SetPosition(player.Position.X, player.Position.Y);
            currentSprite.Draw(spriteBatch);
        }

        /* sets currentSprite based on the player's velocity */
        private void UpdateCurrentSprite()
        {
            if (player.Velocity.Y < 0) currentSprite = spriteMoveUp;
            if (player.Velocity.Y > 0) currentSprite = spriteMoveDown;
            if (player.Velocity.X < 0) currentSprite = spriteMoveLeft;
            if (player.Velocity.X > 0) currentSprite = spriteMoveRight;
        }
    }
}
