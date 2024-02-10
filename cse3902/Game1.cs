using cse3902.Interfaces;
using cse3902.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace cse3902;

public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    public Texture2D ContentSpritesheetLink;

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private IController controller;

    private List<IEnemy> _enemy;
    private int enemyIdx;
    private KeyboardState previousKbState;

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

        _enemy = new List<IEnemy>
        {
            new Skeleton(Content),
            new Dragon(Content),
            new Gel(Content),
            new Keese(Content),
            new Goriya(Content),
        };
        enemyIdx = 0;



        ContentSpritesheetLink = Content.Load<Texture2D>("spritesheet_link");
        player = new Player(this);
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState kbState = Keyboard.GetState();

        if (kbState.IsKeyDown(Keys.P) && !previousKbState.IsKeyDown(Keys.P))
        { 
            foreach (IEnemy enemy in _enemy)
            {
                enemy.IsVisible = false;
            }
            enemyIdx = (enemyIdx + 1) % _enemy.Count;
            _enemy[enemyIdx].IsVisible = true;
        }

        if (kbState.IsKeyDown(Keys.O) && !previousKbState.IsKeyDown(Keys.O))
        {
            foreach (IEnemy enemy in _enemy)
            {
                enemy.IsVisible = false;
            }
            enemyIdx--;
            if (enemyIdx < 0) enemyIdx = _enemy.Count - 1;
            _enemy[enemyIdx].IsVisible = true;
        }
        previousKbState = kbState;
        _enemy[enemyIdx].update(gameTime);

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

        foreach (IEnemy enemy in _enemy)
        {
            enemy.draw(spriteBatch);
        }
        player.Draw(spriteBatch);
        
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
