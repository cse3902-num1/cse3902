using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class PlayerStateMove : IPlayerState
    {
        private Player player;
        private ISprite spriteMoveLeft = new Sprite();
        private ISprite spriteMoveRight = new Sprite();
        private ISprite spriteMoveUp = new Sprite();
        private ISprite spriteMoveDown = new Sprite();
        private ISprite currentSprite; // will reference one of the above sprites

        public PlayerStateMove(Player player)
        {
            this.player = player;
            // TODO: set texture and frame data of spriteMoveLeft, spriteMoveRight, spriteMoveUp, and spriteMoveDown
            currentSprite = spriteMoveRight; // just a default value
        }

        public void Update(GameTime gameTime)
        {
            // TODO: return to idle state if no movement keys are pressed
            // TODO: move according to movement direction
            UpdateCurrentSprite();
            currentSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Position = player.Position;
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
