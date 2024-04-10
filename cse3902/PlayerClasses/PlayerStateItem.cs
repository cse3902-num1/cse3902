using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902.PlayerClasses
{
    public class PlayerStateItem : IPlayerState
    {
        private Player player;
        private IInventoryItem item;
        private Dictionary<Direction, Sprite> sprites;
        private GameContent content;
        private Vector2 playerUseItemOrigin = new Vector2(8, 8);
        public PlayerStateItem(GameContent content, Player player, IInventoryItem item)
        {
            this.content = content;
            this.player = player;
            this.item = item;

            sprites = new Dictionary<Direction, Sprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        PlayerConstant.PlayerUseItemLeft
                    }, playerUseItemOrigin)
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        PlayerConstant.PlayerUseItemRight
                    },playerUseItemOrigin )
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        PlayerConstant.PlayerUseItemUp
                    }, playerUseItemOrigin)
                },
                {
                    Direction.Down,
                    new Sprite(content.SpritesheetLinkUseItem, new List<Rectangle>() {
                        PlayerConstant.PlayerUseItemDown
                    }, playerUseItemOrigin)
                },
            };

            /* TODO: use the item */
            player.UseItem(item);
        }
        public void Update(GameTime gameTime, List<IController> controllers)
        {
            /* TODO: change to idle state if itemUsageSprite animation is done */
            if (sprites[player.Facing].IsAnimationDone())
            {
                player.State = new PlayerStateIdle(content, player);
            }

            /* TODO: depending on how we implement items, we might need to update them */
            // item.Update();

            /* play idle sprite animation */
            sprites[player.Facing].Update(gameTime, controllers);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
        }
    }
}
