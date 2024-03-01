using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902
{
    public class PlayerStateIdle : IPlayerState
    {
        private Player player;
        private Dictionary<Direction, ISprite> sprites;
        private GameContent content;

        public PlayerStateIdle(GameContent content, Player player)
        {
            Debug.WriteLine("[info] player entered idle state");
            this.content = content;
            this.player = player;

            sprites = new Dictionary<Direction, ISprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 0 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 1 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 2 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
                {
                    Direction.Down,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 3 * 16, 16, 16)
                    }, new Vector2(8, 8))
                },
            };
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            /* enter move state if any movement keys are pressed */
            if (controllers.Any(c => c.isPlayerMoveLeftPressed())
                || controllers.Any(c => c.isPlayerMoveUpPressed())
                || controllers.Any(c => c.isPlayerMoveDownPressed())
                || controllers.Any(c => c.isPlayerMoveRightPressed()))
            {
                player.State = new PlayerStateMove(content, player);
            }

            /* enter attack state if attack key is pressed */
            else if (controllers.Any(c => c.isPlayerAttackJustPressed()))
            {
                player.State = new PlayerStateAttack(content, player);
            }

            /* enter item state if any item use keys are pressed */
            /* TODO: finish once items classes are created */
            IInventoryItem item = null;
            if      (controllers.Any(c => c.isPlayerUseItem1JustPressed())) item = new BlueBombInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseItem2JustPressed())) item = new MagicalBoomerangInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseItem3JustPressed())) item = new BlueBowInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseItem4JustPressed())) item = new FireballInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseItem5JustPressed())) item = new FireInventoryItem();
            else if (controllers.Any(c => c.isPlayerUseItem6JustPressed())) item = new GreenBoomerangInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseItem7JustPressed())) item = new GreenBowInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseItem8JustPressed())) item = new PurpleCystleInventoryItem();
            else if (controllers.Any(c => c.isPlayerUseItem9JustPressed())) item = new YellowBoomerangInventoryItem(content);
            if (item != null)
            {
                player.State = new PlayerStateItem(content, player, item);
            }
        
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
