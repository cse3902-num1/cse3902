using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private IController controller;

    private Level level;

    private GameContent gameContent;
    
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

        level = new Level(gameContent);
    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        /* TODO: replace level with fresh copy if reset key is pressed */

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
