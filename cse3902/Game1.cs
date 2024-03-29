using cse3902.RoomClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cse3902.Objects;
using cse3902.Enemy;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace cse3902;



public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private List<IController> controllers;
    private GameContent gameContent;
    //public static Room currRoom;
    private Level level;

    public Camera camera;
    
    public Game1()
    {
        EventBus.LoggingMessage("Hello, world!");
        EventBus.LoggingMessage += log;
        EventBus.LoggingMessage("Hello, world 2!");
        EventBus.LoggingMessage -= log;
        EventBus.LoggingMessage("Hello, world 3!");

        EventBus.PlayerDying += onPlayerDying;

        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        controllers = new List<IController>() {
            new KeyboardController(),
            new MouseController(),
        };
    }

    protected override void Initialize()
    {
        this.IsMouseVisible = true;
        graphics.PreferredBackBufferWidth = 768; // Change this to your desired width
        graphics.PreferredBackBufferHeight = 528; // Change this to your desired height
        graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // spriteBatch = new SpriteBatch(GraphicsDevice);
        camera = new Camera(new SpriteBatch(GraphicsDevice), new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

        gameContent = new GameContent(Content);


        level = new Level(gameContent);
    }

    protected override void Update(GameTime gameTime)
    {
        controllers.ForEach(c => c.Update(gameTime));

        /* reset level if R is pressed */
        if (controllers.Any(c => c.isResetPressed()))
        {
            level = new Level(gameContent);
        }

        /* quit game if Q is pressed */
        if (controllers.Any(c => c.isQuitPressed()))
        {
            Exit();
        }

        level.Update(gameTime, controllers);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Lavender);

        // /* enable nearest-neighbor texture filtering */
        // SamplerState s = new SamplerState();
        // s.Filter = TextureFilter.Point;

        // if (level.player is not null) {
        //     spriteBatch.Begin(samplerState: s, transformMatrix: Matrix.CreateTranslation(new Vector3(
        //         -level.player.Position.X + graphics.PreferredBackBufferWidth / 2f,
        //         -level.player.Position.Y + graphics.PreferredBackBufferHeight / 2f,
        //         0
        //     )));
        // } else {
        //     spriteBatch.Begin(samplerState: s);
        // }

        if (level.player is not null) {
            camera.Position = level.player.Position;
        }

        camera.BeginDraw();

        level.Draw(camera.spriteBatch);
       
        camera.EndDraw();

        base.Draw(gameTime);
    }

    private void log(string msg) {
        Debug.WriteLine(msg);
    }

    private void onPlayerDying(IPlayer player) {
        throw new NotImplementedException();
    }
}
