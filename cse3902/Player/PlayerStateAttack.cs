using System.Collections.Generic;
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
        private GameContent content;
        public PlayerStateAttack(GameContent content, Player player)
        {
            Debug.WriteLine("[info] player entered attack state");
            this.content = content;
            this.player = player;
            attackSprite = new Sprite(content.ContentSpritesheetLink, new List<Rectangle>() {
                new Rectangle(107, 11, 15, 15)
            });
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
            attackSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            attackSprite.SetPosition(player.Position.X, player.Position.Y);
            attackSprite.Draw(spriteBatch);
        }
    }
}