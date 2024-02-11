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
    

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private KeyboardController controller;

    private List<IEnemy> _enemy;
    private int enemyIdx;
    private KeyboardState previousKbState;

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

        _enemy = new List<IEnemy>
        {
            new Skeleton(Content),
            new Dragon(Content),
            new Gel(Content),
            new Keese(Content),
            new Goriya(Content),
        };
        enemyIdx = 0;



        
        gameContent = new GameContent(Content);

        player = new Player(gameContent);
    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        if (controller.isEnemyPressP() && !previousKbState.IsKeyDown(Keys.P))
        { 
            foreach (IEnemy enemy in _enemy)
            {
                enemy.IsVisible = false;
            }
            enemyIdx = (enemyIdx + 1) % _enemy.Count;
            _enemy[enemyIdx].IsVisible = true;
        }

        if (controller.isEnemyPressO() && !previousKbState.IsKeyDown(Keys.O))
        {
            foreach (IEnemy enemy in _enemy)
            {
                enemy.IsVisible = false;
            }
            enemyIdx--;
            if (enemyIdx < 0) enemyIdx = _enemy.Count - 1;
            _enemy[enemyIdx].IsVisible = true;
        }
        previousKbState = controller.keyboardState;
        _enemy[enemyIdx].update(gameTime);


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
