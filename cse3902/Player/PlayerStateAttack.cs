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
                {Direction.Left, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 0 * 28, 27, 28),
                    new Rectangle(1 * 27, 0 * 28, 27, 28),
                    new Rectangle(2 * 27, 0 * 28, 27, 28),
                    new Rectangle(3 * 27, 0 * 28, 27, 28),
                })},

                {Direction.Right, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 1 * 28, 27, 28),
                    new Rectangle(1 * 27, 1 * 28, 27, 28),
                    new Rectangle(2 * 27, 1 * 28, 27, 28),
                    new Rectangle(3 * 27, 1 * 28, 27, 28),
                })},

                {Direction.Up, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 2 * 28, 27, 28),
                    new Rectangle(1 * 27, 2 * 28, 27, 28),
                    new Rectangle(2 * 27, 2 * 28, 27, 28),
                    new Rectangle(3 * 27, 2 * 28, 27, 28),
                })},

                {Direction.Down, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 3 * 28, 27, 28),
                    new Rectangle(1 * 27, 3 * 28, 27, 28),
                    new Rectangle(2 * 27, 3 * 28, 27, 28),
                    new Rectangle(3 * 27, 3 * 28, 27, 28),
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