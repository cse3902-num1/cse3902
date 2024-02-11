using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private IController controller;

    private Player player;
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

<<<<<<< HEAD
        player = new Player(spriteSheet.ContentSpreadsheetLink);
=======
        player = new Player(gameContent);
>>>>>>> e71e86ce65fd2db3ec0b2b0e88a461454aa24df8
    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        player.Update(gameTime, controller);

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
       
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
