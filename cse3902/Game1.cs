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

    private List<IEnemy> _enemy;
    private List<IItemPickup> item;
    private int enemyIdx;
    private int itemIdx;

    public KeyboardController controller;


    private Player player;
   
    private GameContent gameContent;

    private Block block;
    //private Item item;

    
    
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
        item = new List<IItemPickup>
        {
            new PurpleRupeeItemPickup(gameContent),
            new FireItemPickUp(gameContent),
            new PurpleRupeeItemPickup(gameContent),
            new YellowRupeeItemPickup(gameContent),
            new YellowTriangleItemPickUp(gameContent),
            new PurpleTriangleItemPickUp(gameContent),
            new YellowDragonItemPickUp(gameContent),
            new YellowKeyItemPickUp(gameContent),
            new RedHeartItemPickUp(gameContent),
            new BlueHeartItemPickUp(gameContent),
            new RedHeartContainerItemPickUp(gameContent),
            new FairyTailItemPickUp(gameContent),
            new CompassItemPickUp(gameContent),
            new ClockItemPickUp(gameContent),
            new ArrowItemPickUp(gameContent),
            new YellowBoomerangItemPickup(gameContent),
            new BombItemPickup(gameContent),


        };
        itemIdx = 0; 
        enemyIdx = 0;


        player = new Player(gameContent);


        // Initialize the list of blocks and add a block
        block = new Block(gameContent, controller);
        //item = new Item(gameContent, controller);
       
    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        if (controller.isEnemyPressP())
        { 
            enemyIdx = (enemyIdx + 1) % _enemy.Count;
        }

        if (controller.isEnemyPressO())
        {
            enemyIdx--;
            if (enemyIdx < 0) enemyIdx = _enemy.Count - 1;
        }
        _enemy[enemyIdx].Update(gameTime);
        if (controller.isNextItemKeyPress())
        {
            itemIdx = (itemIdx + 1) % item.Count;
        }

        if(controller.isPreviousItemKeyPress()) 
        {
            itemIdx = (itemIdx - 1 + item.Count) % item.Count;
        }
        item[itemIdx].Update(gameTime);

        player.Update(gameTime, controller);

        // Update the current block
        block.update(gameTime);
        //item.Update(gameTime);

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
        // Draw the current block
        block.draw(spriteBatch);
        item[itemIdx].Draw(spriteBatch);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
