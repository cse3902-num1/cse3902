using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateItem : IPlayerState
    {
        private Player player;
        private IInventoryItem item;
        private Dictionary<Direction, Sprite> sprites;
        private GameContent content;

        public PlayerStateItem(GameContent content, Player player, IInventoryItem item)
        {
            Debug.WriteLine("[info] player entered item state");
            this.content = content;
            this.player = player;
            this.item = item;

            sprites = new Dictionary<Direction, Sprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        new Rectangle(0 * 16, 0 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        new Rectangle(0 * 16, 1 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        new Rectangle(0 * 16, 2 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Down,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        new Rectangle(0 * 16, 3 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
            };

            /* TODO: use the item */
            player.UseItem(item);
        }
        public void Update(GameTime gameTime, IController controller)
        {
            /* TODO: change to idle state if itemUsageSprite animation is done */
            if (sprites[player.Facing].Frame == 0)
            {
                player.State = new PlayerStateIdle(content, player);
            }

            /* TODO: depending on how we implement items, we might need to update them */
            // item.Update();

            /* play idle sprite animation */
            sprites[player.Facing].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
        }
    }
}
