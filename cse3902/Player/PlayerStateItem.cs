using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace cse3902
{
    public class PlayerStateItem : IPlayerState
    {
        private Game1 game;
        private Player player;
        private Sprite idleSprite;


        public PlayerStateItem(Game1 game, Player player)
        {
            this.game = game;
            this.player = player;
            idleSprite = new Sprite(game.ContentSpritesheetLink);
            // TODO: set frame data of idleSprite
        }
        public void Update(GameTime gameTime, IController keyboard)
        {
           if(keyboard.isItem1Press() == true)
            {
                // to do: new a Item class: ex: Arrow.
                throw new NotImplementedException();
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
