using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    public Texture2D ContentSpritesheetLink;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private IController keyboard;

    private Player _player;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
       


        keyboard = new KeyboardController();

    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        /*
        _sprites = new List<IPlayer> {
           new Player(Content)
        };
        */
        
        ContentSpritesheetLink = Content.Load<Texture2D>("spritesheet_link");
        _player = new Player(this);
    }

    private Vector2 GetScreenCenter()
    {
        return new Vector2(
            Window.ClientBounds.Width / 2,
            Window.ClientBounds.Height / 2
        );
    }

    protected override void Update(GameTime gameTime)
    {
        
  
 
        keyboard.Update(gameTime);


        /* collect input states */
    

        _player.Update(gameTime, keyboard);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Lavender);

        /* enable nearest-neighbor texture filtering */
        SamplerState s = new SamplerState();
        s.Filter = TextureFilter.Point;

        _spriteBatch.Begin(samplerState: s);
        _player.Draw(_spriteBatch);
       
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
