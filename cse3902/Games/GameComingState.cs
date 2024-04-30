using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cse3902.Games
{
    public class GameComingState : IGameState
    {
        private GameContent gameContent;
        private Game1 game;
        private ISprite sprite;
        private Vector2 textPos;
        private string gameOver = "Boggus is coming!!!";

        private Stopwatch boggusComingTimer = new Stopwatch();
        public GameComingState(GameContent gamecontent, Game1 game)
        {
            this.gameContent = gamecontent;
            this.game = game;
            sprite = new Sprite(gamecontent.BlackScreen, new List<Rectangle>() {
                        new Rectangle()
                    });
            textPos = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - 50, Game1.graphics.PreferredBackBufferHeight / 2);
            boggusComingTimer.Start();
        }
        public void Draw(Camera camera)
        {
            Vector2 centerPos = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2);
            camera.Position = centerPos;
            camera.BeginDraw();
            sprite.Draw(camera.spriteBatch);
            camera.spriteBatch.DrawString(Game1.font, gameOver, textPos, Color.Red, 0f, new Vector2(60, 10), 6, SpriteEffects.None, 0f);
            camera.EndDraw();
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            sprite.Update(gameTime, controllers);
            if(boggusComingTimer.ElapsedMilliseconds >= 1500)
            {
                Game1.State = new GameBossfightState(gameContent,game);
            }
            
        }
    }
}
