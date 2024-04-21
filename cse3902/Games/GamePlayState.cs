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
        private GameContent gameContent;
        private Game1 game;
        private Level level;
        private Hud hud;
        private bool isPaused = false;

        /* room transition animation variables */
        private bool isTransitioningRooms = false;
        private Vector2 cameraPosition = new Vector2(0, 0);
        private Vector2 initialCameraPosition = new Vector2(0, 0);
        private Vector2 targetCameraPosition = new Vector2(0, 0);
        private const float TRANSITION_LENGTH = 1.0f; /* seconds */
        Stopwatch transitionTimer = new Stopwatch();

        public GamePlayState(GameContent gamecontent, Game1 game)
        {
            this.gameContent = gamecontent;
            this.game = game;
            level = new Level(gamecontent);
            hud = new Hud(gameContent,level);

            EventBus.StartingRoomTransition += OnStartingRoomTransition;
            EventBus.EndingRoomTransition += OnEndingRoomTransition;
        }
        public void Draw(Camera camera)
        {
            if (level.player is not null) {
                // camera.Position = level.player.Position;
                // camera.Position = level.player.CurrentRoom.Position + new Vector2(Room.ROOM_WIDTH / 2, Room.ROOM_HEIGHT / 2);
            }

            camera.Position = cameraPosition;

            // camera.Position = new Vector2(0, 0);
            camera.BeginDraw();

            level.Draw(camera.spriteBatch);

            hud.Position = camera.Position - new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2);
            hud.Draw(camera.spriteBatch);

            camera.EndDraw();
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            if(controllers.Any(c => c.isPausePressed()))
            {
                isPaused = !isPaused;
            }

            if (isPaused) return;

            if (isTransitioningRooms) {
                /* lerp camera towards target position */
                float t = (float) transitionTimer.Elapsed.TotalSeconds / TRANSITION_LENGTH;
                if (t >= 1) EventBus.EndingRoomTransition();
                cameraPosition = Vector2.Lerp(initialCameraPosition, targetCameraPosition, t);
                Debug.WriteLine(t);

                return;
            }

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

            if (level.player is not null) {
                // cameraPosition = level.player.CurrentRoom.Position + new Vector2(Room.ROOM_WIDTH / 2, Room.ROOM_HEIGHT / 2);
                cameraPosition = level.player.Position;
            }

        }
        
        public void OnStartingRoomTransition(Room roomFrom, Room roomTo)
        {
            isTransitioningRooms = true;
            initialCameraPosition = cameraPosition;
            targetCameraPosition = roomTo.Position + new Vector2(Room.ROOM_WIDTH / 2, Room.ROOM_HEIGHT / 2);
            transitionTimer.Reset();
            transitionTimer.Start();
            Debug.WriteLine("STARTING ROOM TRANSITION");
        }

        public void OnEndingRoomTransition()
        {
            isTransitioningRooms = false;
            transitionTimer.Stop();
            Debug.WriteLine("ENDING ROOM TRANSITION");
        }
    }
}
