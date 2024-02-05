using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class PlayerStateAttack : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite attackSprite;
        public PlayerStateAttack(Game1 game, Player player)
        {
            Debug.WriteLine("[info] player entered attack state");
            this.game = game;
            this.player = player;
            attackSprite = new Sprite(game.ContentSpritesheetLink);
            // TODO: set frame data of attackSprite
        }

        public void Update(GameTime gameTime, IController controller)
        {

            // TODO: return to idle state if attackSprite animation is done
            // something like:
            /* Temperary comment
            if (attackSprite.isDone())
            {
                player.State = new PlayerStateIdle(game, player);
            }
           comment end  */
            attackSprite.Update(game, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            attackSprite.SetPosition(player.Position.X, player.Position.Y);
            attackSprite.Draw(spriteBatch);
        }
    }
}