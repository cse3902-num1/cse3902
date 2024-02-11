using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    public Texture2D ContentSpritesheetLink;

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private IController controller;

    private Player player;
    
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

        ContentSpritesheetLink = Content.Load<Texture2D>("spritesheet_link");

        player = new Player(this);
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
