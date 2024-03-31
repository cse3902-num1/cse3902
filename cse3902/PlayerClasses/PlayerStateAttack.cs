using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.PlayerClasses
{
    public class PlayerStateAttack : IPlayerState
    {
        private Player player;
        private Dictionary<Direction, Sprite> sprites;
        private GameContent content;
        public PlayerStateAttack(GameContent content, Player player)
        {
            this.content = content;
            this.player = player;

            sprites = new Dictionary<Direction, Sprite>() {
                {Direction.Left, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 0 * 28, 27, 28),
                    new Rectangle(1 * 27, 0 * 28, 27, 28),
                    new Rectangle(2 * 27, 0 * 28, 27, 28),
                    new Rectangle(3 * 27, 0 * 28, 27, 28),
                }, new Vector2(18, 8))},

                {Direction.Right, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 1 * 28, 27, 28),
                    new Rectangle(1 * 27, 1 * 28, 27, 28),
                    new Rectangle(2 * 27, 1 * 28, 27, 28),
                    new Rectangle(3 * 27, 1 * 28, 27, 28),
                }, new Vector2(8, 8))},

                {Direction.Up, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 2 * 28, 27, 28),
                    new Rectangle(1 * 27, 2 * 28, 27, 28),
                    new Rectangle(2 * 27, 2 * 28, 27, 28),
                    new Rectangle(3 * 27, 2 * 28, 27, 28),
                }, new Vector2(8, 20))},

                {Direction.Down, new Sprite(content.SpritesheetLinkAttackWoodSword, new List<Rectangle>() {
                    new Rectangle(0 * 27, 3 * 28, 27, 28),
                    new Rectangle(1 * 27, 3 * 28, 27, 28),
                    new Rectangle(2 * 27, 3 * 28, 27, 28),
                    new Rectangle(3 * 27, 3 * 28, 27, 28),
                }, new Vector2(8, 8))}
            };
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            /* go to idle state if attack animation is done */
            if (sprites[player.Facing].IsAnimationDone())
            {
                player.State = new PlayerStateIdle(content, player);
            }




            sprites[player.Facing].Update(gameTime, controllers);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
             
        }
    }
}