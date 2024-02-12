using cse3902.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cse3902.Objects;

namespace cse3902;

// Shared data class
public static class GameData
{
    public static int BlockIndex { get; set; }
}

public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    public KeyboardController controller;

    private Player player;
   
    private GameContent gameContent;

    private Block block;
 

    private KeyboardState previousKbState;
    
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
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

        player = new Player(gameContent);

        // Initialize the list of blocks and add a block
        block = new Block(Content, controller);
       
    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        player.Update(gameTime, controller);

        // Update the current block
        block.update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Lavender);

        /* enable nearest-neighbor texture filtering */
        SamplerState s = new SamplerState();
        s.Filter = TextureFilter.Point;

        spriteBatch.Begin(samplerState: s);

        player.Draw(spriteBatch);
        // Draw the current block
        block.draw(spriteBatch);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
