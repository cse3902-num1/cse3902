using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Games
{
    public class GamePlayState : IGameState
    {
        private GameContent gameContent;
        private Game1 game;
        private Level level;
        public GamePlayState(GameContent gamecontent, Game1 game)
        {
            this.gameContent = gamecontent;
            this.game = game;
            level = new Level(gamecontent);
            // 
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            level.Update(gameTime, controllers);
            /* reset level if R is pressed */
            if (controllers.Any(c => c.isResetPressed()))
            {
                level = new Level(gameContent);
            }

        }
    }
}
