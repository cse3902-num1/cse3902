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
        private Player player;
        public GameWinState(GameContent gamecontent, Game1 game) 
        {
            this.gameContent = gamecontent;
            this.game = game; 
            sprite = new Sprite(gamecontent.SpritesheetLinkWalk, new List<Rectangle>() {
                        new Rectangle(0 * 16, 0 * 16, 16, 16)
                    }, new Vector2(8, 8));
            this.player = new Player(gamecontent);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {

            // to do:  pass in Player.Inventory.Keys?
            if (player.Inventory.Keys == 1)
            {
                sprite.Update(gameTime, controllers);
            }
    
        }
    }
}
