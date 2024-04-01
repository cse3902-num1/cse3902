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
        private Hud hud;
        public GamePlayState(GameContent gamecontent, Game1 game)
        {
            this.gameContent = gamecontent;
            this.game = game;
            level = new Level(gamecontent);
            hud = new Hud(gameContent);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);

            hud.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            level.Update(gameTime, controllers);
            /* reset level if R is pressed */
            if (controllers.Any(c => c.isResetPressed()))
            {
                level = new Level(gameContent);
            }
            
            hud.Update(gameTime, controllers);
            if(level.player.Inventory.Triforce == 1)
            {
                Game1.State = new GameWinState(gameContent, game);
            }
        }
    }
}
