using cse3902.RoomClasses;
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
    public class GamePlayState : IGameState
    {
        private GameContent gameContent;
        private Game1 game;
        private Level level;
        private Hud hud;
        private bool isPaused = false;
        public GamePlayState(GameContent gamecontent, Game1 game)
        {
            this.gameContent = gamecontent;
            this.game = game;
            level = new Level(gamecontent);
            hud = new Hud(gameContent,level);
        }
        public void Draw(Camera camera)
        {
            if (level.player is not null) {
                // camera.Position = level.player.Position;
                camera.Position = level.player.CurrentRoom.Position + new Vector2(Room.ROOM_WIDTH / 2, Room.ROOM_HEIGHT / 2);
            }
            // camera.Position = new Vector2(0, 0);
            camera.BeginDraw();
            level.Draw(camera.spriteBatch);
            hud.Draw(camera.spriteBatch);
            camera.EndDraw();
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {

            if (!isPaused)
            {
                level.Update(gameTime, controllers);
                /* reset level if R is pressed */
                if (controllers.Any(c => c.isResetPressed()))
                {
                    level = new Level(gameContent);
                }

                hud.Update(gameTime, controllers);
                if (level.player.Inventory.Triforce == 1)
                {
                    Game1.State = new GameWinState(gameContent, game);
                }

            }
            if(controllers.Any(c => c.isPausePressed()))
            {
                isPaused = !isPaused;
            }
        }
        
    }
}
