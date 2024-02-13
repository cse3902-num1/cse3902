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

        _enemy = new List<IEnemy>
        {
            new Skeleton(gameContent),
            new Dragon(gameContent),
            new Gel(gameContent),
            new Keese(gameContent),
            new Goriya(gameContent),
        };
        enemyIdx = 0;

        player = new Player(gameContent);

    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        if (controller.isEnemyPressP() && !previousKbState.IsKeyDown(Keys.P))
        { 
            enemyIdx = (enemyIdx + 1) % _enemy.Count;
        }

        if (controller.isEnemyPressO() && !previousKbState.IsKeyDown(Keys.O))
        {
            enemyIdx--;
            if (enemyIdx < 0) enemyIdx = _enemy.Count - 1;
        }
        previousKbState = controller.keyboardState;
        _enemy[enemyIdx].Update(gameTime);


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

        _enemy[enemyIdx].Draw(spriteBatch);

        player.Draw(spriteBatch);
        
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
