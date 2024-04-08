using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Games
{
    public class GameOverState : IGameState
    {
        private GameContent gameContent;
        private Game1 game;
        private ISprite sprite;
        private Vector2 textPos;
        private string gameOver = "Game Over";
        private string startOver = "press r to startOver or press q to quit";
        private static readonly Vector2 GameOverTextOrigin = new Vector2(30, 10);
        private static readonly Vector2 StartOverTextOrigin = new Vector2(100, -20);
        private const float GameOverTextScale = 6;
        private const float StartOverTextScale = 3;
        private const int TextOffsetX = -50;

        public GameOverState(GameContent gamecontent, Game1 game) {
            this.gameContent = gamecontent;
            this.game = game;
            sprite = new Sprite(gamecontent.BlackScreen, new List<Rectangle>() {
                        new Rectangle()
                    });
            textPos = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 50, Game1.graphics.PreferredBackBufferHeight / 2);
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, gameOver, textPos, Color.Red,0f,new Vector2(30,10),6, SpriteEffects.None, 0f);
            spriteBatch.DrawString(Game1.font, startOver, textPos, Color.DarkRed, 0f, new Vector2(100, -20), 3, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
        
                
                sprite.Update(gameTime, controllers);

            // add text font
                if (controllers.Any(c => c.isResetPressed()) == true)
                {
                    Game1.State = new GameStartState(gameContent, game);
                }
            //



        }
    }
}
