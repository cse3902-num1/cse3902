using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateItem : IPlayerState
    {
        private Player player;
        private IItem item;
        private Dictionary<Direction, ISprite> sprites;
        private GameContent content;

        public PlayerStateItem(GameContent content, Player player, IItem item)
        {
            Debug.WriteLine("[info] player entered item state");
            this.content = content;
            this.player = player;
            this.item = item;

            sprites = new Dictionary<Direction, ISprite>() {
                {
                    Direction.Left,
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(107, 11, 15, 15)
                    })
                },
                {
                    Direction.Right,
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(124, 11, 15, 15)
                    })
                },
                {
                    Direction.Up,
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(141, 11, 15, 15)
                    })
                },
                {
                    Direction.Down,
                    new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                        new Rectangle(124, 11, 15, 15)
                    })
                },
            };

            this.item.Use(player);
        }
        public void Update(GameTime gameTime, IController controller)
        {
            /* TODO: change to idle state if itemUsageSprite animation is done */

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
