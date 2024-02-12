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

        private bool wasAttackPressed = true;
        private bool wasItem1Pressed = true;
        private bool wasItem2Pressed = true;
        private bool wasItem3Pressed = true;

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
                    })
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 1 * 16, 16, 16)
                    })
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 2 * 16, 16, 16)
                    })
                },
                {
                    Direction.Down,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 3 * 16, 16, 16)
                    })
                },
            };
        }

        public void Update(GameTime gameTime, IController controller)
        {
            /* enter move state if any movement keys are pressed */
            if (controller.isPlayerMoveLeftPress() == true || controller.isPlayerMoveUpPress() == true ||
                controller.isPlayerMoveDownPress() ==true || controller.isPlayerMoveRightPress() == true)
            {
                player.State = new PlayerStateMove(content, player);
            }

            /* enter attack state if attack key is pressed */
            else if (!wasAttackPressed && controller.isPlayerAttackPress())
            {
                player.State = new PlayerStateAttack(content, player);
            }

            /* enter item state if any item use keys are pressed */
            /* TODO: finish once items classes are created */
            if (!wasItem1Pressed && controller.isItem1Press())
            {
                player.State = new PlayerStateItem(content, player, null);
                // player.State = new PlayerStateItem(game, player, new ExampleItem());
            }
            else if (!wasItem2Pressed && controller.isItem2Press())
            {
                player.State = new PlayerStateItem(content, player, null);
                // player.State = new PlayerStateItem(game, player, new ExampleItem());
            }
            else if (!wasItem3Pressed && controller.isItem3Press())
            {
                player.State = new PlayerStateItem(content, player, null);
                // player.State = new PlayerStateItem(game, player, new ExampleItem());
            }

            wasAttackPressed = controller.isPlayerAttackPress();
            wasItem1Pressed = controller.isItem1Press();
            wasItem2Pressed = controller.isItem2Press();
            wasItem3Pressed = controller.isItem3Press();
        
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
