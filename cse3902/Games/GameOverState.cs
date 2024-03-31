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
        public GameOverState(GameContent gamecontent, Game1 game) {
            this.gameContent = gamecontent;
            this.game = game;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            throw new NotImplementedException();
        }
    }
}
