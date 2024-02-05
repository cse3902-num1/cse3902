using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902
{
    public class PlayerStateIdle : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite idleSprite;
    

        public PlayerStateIdle(Game1 game, Player player)
        {
            this.game = game;
            this.player = player;
            idleSprite = new Sprite(game.ContentSpritesheetLink);
            // TODO: set frame data of idleSprite
        }
        public void Update(GameTime gameTime, IController keyboard)
        {
            if (keyboard.isPlayerMoveLeftPress() == true || keyboard.isPlayerMoveUpPress() == true ||
                keyboard.isPlayerMoveDownPress() ==true || keyboard.isPlayerMoveRightPress() == true)
            {
                player.State = new PlayerStateMove(game, player);
            }
            else if (keyboard.isPlayerAttackPress())
            {
                player.State = new PlayerStateAttack(game, player);
            }
        
                /* play idle sprite animation */
                idleSprite.Update(game, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            idleSprite.SetPosition(player.Position.X, player.Position.Y);
           
            idleSprite.Draw(spriteBatch);
           
        }
    }
}
