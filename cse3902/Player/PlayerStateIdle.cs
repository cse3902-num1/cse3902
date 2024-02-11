using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace cse3902
{
    public class PlayerStateIdle : IPlayerState
    {
        
        private Player player;
        private Sprite idleSprite;
        private Spritesheet spritesheet;

        public PlayerStateIdle(Spritesheet sprite, Player player)
        {
            Debug.WriteLine("[info] player entered idle state");
            spritesheet = sprite;
            this.player = player;
            idleSprite = new Sprite(sprite.ContentSpritesheetLink);
            // TODO: set frame data of idleSprite
        }

        public void Update(GameTime gameTime, IController controller)
        {
            /* enter move state if any movement keys are pressed */
            if (controller.isPlayerMoveLeftPress() == true || controller.isPlayerMoveUpPress() == true ||
                controller.isPlayerMoveDownPress() ==true || controller.isPlayerMoveRightPress() == true)
            {
                player.State = new PlayerStateMove(spritesheet, player);
            }

            /* enter attack state if attack key is pressed */
            else if (controller.isPlayerAttackPress())
            {
                player.State = new PlayerStateAttack(spritesheet, player);
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
            idleSprite.Update(spritesheet, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            idleSprite.SetPosition(player.Position.X, player.Position.Y);
            idleSprite.Draw(spriteBatch);
        }
    }
}
