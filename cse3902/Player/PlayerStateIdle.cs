using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateIdle : IPlayerState
    {
        
        private Player player;
        private Sprite idleSprite;
        private GameContent content;

        public PlayerStateIdle(GameContent content, Player player)
        {
            Debug.WriteLine("[info] player entered idle state");
            this.content = content;
            this.player = player;
            idleSprite = new Sprite(content.ContentSpritesheetLink, new List<Rectangle>() {
                new Rectangle(1, 11, 15, 15)
            });
            // TODO: set frame data of idleSprite
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
            else if (controller.isPlayerAttackPress())
            {
                player.State = new PlayerStateAttack(content, player);
            }

            /* enter item state if any item use keys are pressed */
            /* TODO: finish once items classes are created */
            if (controller.isItem1Press())
            {
                // player.State = new PlayerStateItem(game, player, new ExampleItem());
            }
            else if (controller.isItem2Press())
            {
                // player.State = new PlayerStateItem(game, player, new ExampleItem());
            }
            else if (controller.isItem3Press())
            {
                // player.State = new PlayerStateItem(game, player, new ExampleItem());
            }
        
            /* play idle sprite animation */
            idleSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            idleSprite.SetPosition(player.Position.X, player.Position.Y);
            idleSprite.Draw(spriteBatch);
        }
    }
}
