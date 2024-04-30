using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace cse3902.Games
{
    public class GamePlayState : IGameState
    {
        private Random random = new Random();

        private int camerashake_duration_ms = 0;
        private float camerashake_intensity = 0f;
        private Stopwatch camerashake_timer = new Stopwatch();

        private GameContent gameContent;
        private Game1 game;
        private Level level;
        private Hud hud;
        private bool isPaused = false;
        // initalize level and hud
        public GamePlayState(GameContent gamecontent, Game1 game)
        {
            this.gameContent = gamecontent;
            this.game = game;
            level = new Level(gamecontent);
            hud = new Hud(gameContent,level);

            EventBus.CameraShake += OnCameraShake;
            camerashake_timer.Start();
        }
        // draw level, hud
        public void Draw(Camera camera)
        {
            if (level.player is not null) {
                camera.Position = level.player.Position;
            }

            if (camerashake_timer.ElapsedMilliseconds < camerashake_duration_ms) {
                camera.Position += new Vector2(
                    random.NextSingle() * camerashake_intensity - camerashake_intensity/2,
                    random.NextSingle() * camerashake_intensity - camerashake_intensity/2
                );
            } else {
                camerashake_duration_ms = 0;
                camerashake_timer.Restart();
            }

            camera.BeginDraw();

            level.Draw(camera.spriteBatch);

            hud.Position = camera.Position - new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2);
            hud.Draw(camera.spriteBatch);

            camera.EndDraw();
        }
        /* if p is pressed game will paused, if r is pressed game will reset to current mode
         * if player picked up all the triforce will turn to win state
         */
        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if(controllers.Any(c => c.isPausePressed()))
            {
                isPaused = !isPaused;
            }

            if (isPaused) return;

            level.Update(gameTime, controllers);
            /* reset level if R is pressed */
            if (controllers.Any(c => c.isResetPressed()))
            {
                level = new Level(gameContent);
            }

            hud.Update(gameTime, controllers);
            if (level.player.Inventory.Triforce == 3 || controllers.Any(c => c.isCheatCodeJustPressed()))
            {
                // Game1.State = new GameWinState(gameContent, game);
                Game1.State = new GameBossfightState(gameContent, game);
            }
        }

        public void OnCameraShake(int duration_ms, float intensity) {
            camerashake_duration_ms = duration_ms;
            camerashake_intensity = intensity;
        }
    }
}
