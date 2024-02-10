using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateItem : IPlayerState
    {
        private Game1 game;
        private Player player;
        private IItem item;
        private Sprite itemUsageSprite;


        public PlayerStateItem(Game1 game, Player player, IItem item)
        {
            Debug.WriteLine("[info] player entered item state");
            this.game = game;
            this.player = player;
            this.item = item;
            itemUsageSprite = new Sprite(game.ContentSpritesheetLink, new List<Rectangle>() {
                new Rectangle(107, 11, 15, 15),
                new Rectangle(124, 11, 15, 15),
                new Rectangle(141, 11, 15, 15)
            });
            // TODO: set frame data of itemUsageSprite

            this.item.Use(player);
        }
        public void Update(GameTime gameTime, IController controller)
        {
            /* TODO: change to idle state if itemUsageSprite animation is done */

            /* TODO: depending on how we implement items, we might need to update them */
            // item.Update();

            /* play idle sprite animation */
            itemUsageSprite.Update(game, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            itemUsageSprite.SetPosition(player.Position.X, player.Position.Y);
            itemUsageSprite.Draw(spriteBatch);
        }
    }
}
