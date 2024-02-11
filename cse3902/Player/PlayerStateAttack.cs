using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902
{
    public class PlayerStateAttack : IPlayerState
    {
        private Player player;
        private Dictionary<Direction, Sprite> sprites;
        private GameContent content;
        public PlayerStateAttack(GameContent content, Player player)
        {
            Debug.WriteLine("[info] player entered attack state");
            this.content = content;
            this.player = player;

            sprites = new Dictionary<Direction, Sprite>() {
                {Direction.Left, new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                    new Rectangle(1, 77, 27, 16),
                    new Rectangle(18, 77, 27, 16),
                    new Rectangle(46, 77, 27, 16),
                    new Rectangle(70, 77, 27, 16),
                })},

                {Direction.Right, new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                    new Rectangle(1, 77, 27, 16),
                    new Rectangle(18, 77, 27, 16),
                    new Rectangle(46, 77, 27, 16),
                    new Rectangle(70, 77, 27, 16),
                })},

                {Direction.Up, new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                    new Rectangle(1, 97, 16, 28),
                    new Rectangle(18, 97, 16, 28),
                    new Rectangle(35, 97, 16, 28),
                    new Rectangle(52, 97, 16, 28),
                })},

                {Direction.Down, new Sprite(content.LinkSpritesheet, new List<Rectangle>() {
                    new Rectangle(1, 47, 16, 27),
                    new Rectangle(18, 47, 16, 27),
                    new Rectangle(35, 47, 16, 27),
                    new Rectangle(52, 47, 16, 27),
                })}
            };
        }

        public void Update(GameTime gameTime, IController controller)
        {
            /* go to idle state if attack animation is done */
            if (sprites[player.Facing].Frame == 3)
            {
                player.State = new PlayerStateIdle(content, player);
            }

            sprites[player.Facing].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
        }
    }
}