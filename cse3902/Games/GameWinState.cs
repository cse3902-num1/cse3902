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
        private static float WinGameTextScale = 6;
        private static float StartOverTextScale = 3;
        public static string winGame = "You Win the game!";
        public static string startOver = "press r to startOver or press q to quit";
        
        public GameWinState(GameContent gamecontent, Game1 game) 
        {
            this.gameContent = gamecontent;
            this.game = game;
            sprite = new Sprite(gamecontent.BlackScreen, new List<Rectangle>() {
                        new Rectangle()
                    });
            Constant.textPosMidScreen = new Vector2(Constant.TextPosMidScreenX, Constant.TextPosMidScreenY);
            SoundManager.Manager.Victory();
        }
        public void Draw(Camera camera)
        {
            Vector2 centerPos = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2);
            camera.Position = centerPos;
            camera.BeginDraw();
            sprite.Draw(camera.spriteBatch);
            camera.spriteBatch.DrawString(Game1.font, winGame, Constant.textPosMidScreen, Color.Red, 0f, Constant.WinGameTextOrigin, WinGameTextScale, SpriteEffects.None, 0f);
            camera.spriteBatch.DrawString(Game1.font, startOver, Constant.textPosMidScreen, Color.DarkRed, 0f, Constant.StartOverTextOrigin, StartOverTextScale, SpriteEffects.None, 0f);
            camera.EndDraw();
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
