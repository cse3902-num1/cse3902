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
        private Spritesheet spritesheet;
        public PlayerStateAttack(Spritesheet sprite, Player player)
        {
            Debug.WriteLine("[info] player entered attack state");
            this.spritesheet = sprite;
            this.player = player;
            attackSprite = new Sprite(sprite.ContentSpritesheetLink);
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
            attackSprite.Update(spritesheet, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            attackSprite.SetPosition(player.Position.X, player.Position.Y);
            attackSprite.Draw(spriteBatch);
        }
    }
}