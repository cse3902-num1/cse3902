using cse3902.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cse3902.Objects;
using cse3902.Enemy;

namespace cse3902;



public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    public KeyboardController controller;
    private GameContent gameContent;

    private Level level;
    
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        controller = new KeyboardController();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        gameContent = new GameContent(Content);

        level = new Level(gameContent, controller);
    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        /* reset level if R is pressed */
        if (controller.isResetPressed())
        {
            level = new Level(gameContent, controller);
        }

        /* quit game if Q is pressed */
        if (controller.isQuitPressed())
        {
            Exit();
        }

        level.Update(gameTime, controller);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Lavender);

        /* enable nearest-neighbor texture filtering */
        SamplerState s = new SamplerState();
        s.Filter = TextureFilter.Point;

        spriteBatch.Begin(samplerState: s);

        level.Draw(spriteBatch);
       
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
