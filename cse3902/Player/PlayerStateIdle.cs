using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

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

        public void Update(GameTime gameTime, KeyboardController controller)
        {
            /* enter move state if any movement keys are pressed */
            if (controller.isPlayerMoveLeftPressed()
                || controller.isPlayerMoveUpPressed()
                || controller.isPlayerMoveDownPressed()
                || controller.isPlayerMoveRightPressed())
            {
                player.State = new PlayerStateMove(content, player);
            }

            /* enter attack state if attack key is pressed */
            else if (controller.isPlayerAttackJustPressed())
            {
                player.State = new PlayerStateAttack(content, player);
            }

            /* enter item state if any item use keys are pressed */
            /* TODO: finish once items classes are created */
            IInventoryItem item = null;
            if      (controller.isPlayerUseItem1JustPressed()) item = new BlueBombInventoryItem(content);
            else if (controller.isPlayerUseItem2JustPressed()) item = new MagicalBoomerangInventoryItem(content);
            else if (controller.isPlayerUseItem3JustPressed()) item = new BlueBowInventoryItem(content);
            else if (controller.isPlayerUseItem4JustPressed()) item = new FireballInventoryItem(content);
            else if (controller.isPlayerUseItem5JustPressed()) item = new FireInventoryItem();
            else if (controller.isPlayerUseItem6JustPressed()) item = new GreenBoomerangInventoryItem(content);
            else if (controller.isPlayerUseItem7JustPressed()) item = new GreenBowInventoryItem(content);
            else if (controller.isPlayerUseItem8JustPressed()) item = new PurpleCystleInventoryItem();
            else if (controller.isPlayerUseItem9JustPressed()) item = new YellowBoomerangInventoryItem(content);
            if (item != null)
            {
                player.State = new PlayerStateItem(content, player, item);
            }
        
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
