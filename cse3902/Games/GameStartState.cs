using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Games
{
    public class GameStartState : IGameState
    {
        private GameContent gameContent;
        private Game1 game;
        private ISprite sprite;
        private string startGame = "Right Click to Start";
        private Vector2 textPos;
        public GameStartState(GameContent gamecontent, Game1 game) 
        {
            this.gameContent = gamecontent;
            this.game = game;
            sprite = new Sprite(gamecontent.BlackScreen, new List<Rectangle>() {
                        new Rectangle()
                    });
            textPos = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 50, Game1.graphics.PreferredBackBufferHeight / 2);
            // 
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, startGame, textPos, Color.Red, 0f, new Vector2(45, 10), 4, SpriteEffects.None, 0f);
            
            
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if (controllers.Any(c => c.isRightClick()) == true)
            {
                Game1.State = new GamePlayState(gameContent, game);
            }
        }
    }
}
