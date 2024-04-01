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
        
        public GameOverState(GameContent gamecontent, Game1 game) {
            this.gameContent = gamecontent;
            this.game = game;
            sprite = new Sprite(gamecontent.BlackScreen, new List<Rectangle>() {
                        new Rectangle()
                    });
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
        
                
                sprite.Update(gameTime, controllers);
            // add text font
                if (controllers.Any(c => c.isLeftClick()) == true)
                {
                    Game1.State = new GameStartState(gameContent, game);
                }
            //



        }
    }
}
