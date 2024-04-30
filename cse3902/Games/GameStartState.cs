using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        private string welcomeString = "Welcome to Legend of Zelda";
        private string adventureModeString = "Advanture Mode";
        private string nightMareModeString = "Nightmare Mode";
        private ISprite gameStartTriangle1;
        private ISprite gameStartTriangle2;
        private Vector2 welcomeTextPos;
        private Vector2 adventureTextPos;
        private Vector2 nightMareTextPos;
        private const int TextOffsetX = 180; 
        private const float TextScale = 3;
        public GameStartState(GameContent gamecontent, Game1 game) 
        {
            this.gameContent = gamecontent;
            this.game = game;
            sprite = new Sprite(gamecontent.BlackScreen, new List<Rectangle>() {
                        new Rectangle(),

                    }
                    );
            gameStartTriangle1 = new Sprite(gamecontent.gameStartTriangle, new List<Rectangle>()
                    {
                        new Rectangle(0,0,16,16)
                    },5.0f);
            gameStartTriangle2 = new Sprite(gamecontent.gameStartTriangle, new List<Rectangle>()
                    {
                        new Rectangle(0,0,16,16)
                    }, 5.0f);

            welcomeTextPos = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2 - TextOffsetX, Game1.graphics.PreferredBackBufferHeight / 4);
            adventureTextPos = new Vector2(300, 440);
            nightMareTextPos = new Vector2(300, 640);
            SoundManager.Manager.MenuBGM();
        }
        public void Draw(Camera camera)
        {
            Vector2 centerPos = new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2);
            camera.Position = centerPos;
            camera.BeginDraw();
            sprite.Draw(camera.spriteBatch);
            gameStartTriangle1.Draw(camera.spriteBatch);
            gameStartTriangle2.Draw(camera.spriteBatch);
            camera.spriteBatch.DrawString(Game1.font, welcomeString, welcomeTextPos, Color.Red, 0f, Constant.TextOrigin, TextScale, SpriteEffects.None, 0f);
            camera.spriteBatch.DrawString(Game1.font, adventureModeString,adventureTextPos,Color.DarkRed,0f,Constant.TextOrigin,TextScale,SpriteEffects.None, 0f);
            camera.spriteBatch.DrawString(Game1.font, nightMareModeString, nightMareTextPos, Color.DarkRed, 0f, Constant.TextOrigin, TextScale, SpriteEffects.None, 0f);
            camera.EndDraw();
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            gameStartTriangle1.Position = new Vector2(80, 400);
            gameStartTriangle2.Position = new Vector2(80, 600);
            // Calculate the bounding rectangles for the text options
            Vector2 adventureTextSize = Game1.font.MeasureString(adventureModeString) * TextScale;
            Vector2 actualAdventureTextPos = adventureTextPos - Constant.TextOrigin * TextScale;

            Rectangle adventureTextRect = new Rectangle(actualAdventureTextPos.ToPoint(), adventureTextSize.ToPoint());

            Vector2 nightMareTextSize = Game1.font.MeasureString(nightMareModeString) * TextScale;
            Vector2 actualNightMareTextPos = nightMareTextPos - Constant.TextOrigin * TextScale; // Adjusting for the text origin
            Rectangle nightMareTextRect = new Rectangle(actualNightMareTextPos.ToPoint(), nightMareTextSize.ToPoint());

            // Get the current mouse state and position
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);

            // Check if the mouse is over the adventure mode text
            if (adventureTextRect.Contains(mousePosition) && controllers.Any(c => c.isLeftClick()))
            {
                // The mouse is over the adventure mode text and the left button was clicked
                // Transition to the adventure mode gameplay state
                Game1.State = new GamePlayState(gameContent, game);
                Game1.isNightmare = false;
            }

            // Check if the mouse is over the nightmare mode text
            else if (nightMareTextRect.Contains(mousePosition) && controllers.Any(c => c.isLeftClick()))
            {
                // The mouse is over the nightmare mode text and the left button was clicked
                // Transition to the nightmare mode gameplay state
                Game1.isNightmare = true;
                Game1.State = new GamePlayState(gameContent, game);
                
            }
        }
    }
}
