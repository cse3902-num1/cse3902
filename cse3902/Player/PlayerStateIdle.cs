using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class PlayerStateIdle : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite idleSprite;

        public PlayerStateIdle(Game1 game, Player player)
        {
            this.player = player;
            idleSprite = new Sprite(game.ContentSpritesheetLink, game.Content);
            // TODO: set frame data of idleSprite
        }

        public void Update(GameTime gameTime)
        {
            // TODO: go to movement state if attack button is pressed
            // something like:
            if (any movement keys are pressed)
            {
                player.State = new PlayerStateMove(game, player);
            }

            // TODO: go to attack state if attack button is pressed
            // something like:
            if (attack button pressed)
            {
                player.State = new PlayerStateAttack(game, player);
            }

            /* play idle sprite animation */
            idleSprite.Update(game, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            idleSprite.SetPosition(player.Position.X, player.Position.Y);
            idleSprite.Draw(spriteBatch);
        }
    }
}
