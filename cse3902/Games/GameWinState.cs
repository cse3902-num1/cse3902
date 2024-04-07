using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Games
{
    public class GameWinState : IGameState
    {
        private GameContent gameContent;
        private Game1 game;
        private ISprite sprite;
        private string winGame = "You Win the game!";
        private string startOver = "press r to startOver or press q to quit";
        
        public GameWinState(GameContent gamecontent, Game1 game) 
        {
            this.gameContent = gamecontent;
            this.game = game;
            sprite = new Sprite(gamecontent.BlackScreen, new List<Rectangle>() {
                        new Rectangle()
                    });
            Constant.textPosMidScreen = new Vector2(Constant.TextPosMidScreenX, Constant.TextPosMidScreenY);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, winGame, Constant.textPosMidScreen, Color.Red, 0f, new Vector2(55, 10), 6, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Game1.font, startOver, Constant.textPosMidScreen, Color.DarkRed, 0f, new Vector2(105, -20), 3, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (controllers.Any(c => c.isResetPressed()) == true)
            {
                Game1.State = new GameStartState(gameContent, game);
            }

            sprite.Update(gameTime, controllers);
            
    
        }
    }
}
