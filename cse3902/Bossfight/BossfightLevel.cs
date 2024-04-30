using System.Collections.Generic;
using cse3902.Games;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BossfightLevel
{
    public Boss boss;
    public BossfightPlayer player;
    public List<IBossfightProjectile> projectiles;

    private GameContent content;
    private Game1 game;
    public Rectangle worldBounds;
    public BossfightLevel(GameContent content, Game1 game) {
        this.content = content;
        this.game = game;

        // Set world boundaries based on screen dimensions
        this.worldBounds = new Rectangle(0, 0, 868, 828);


        boss = new Boss(content, this, new Vector2(100, 20));

        player = new BossfightPlayer(content, this, new Vector2(0, worldBounds.Bottom));
        projectiles = new List<IBossfightProjectile>();
    }

    public void Update(GameTime gameTime, List<IController> controllers) {
        player.Update(gameTime, controllers);
        boss.Update(gameTime, controllers);
        projectiles.ForEach(p => p.Update(gameTime, controllers));
        player.Position = Vector2.Clamp(player.Position, new Vector2(worldBounds.Left, worldBounds.Top), new Vector2(worldBounds.Right, worldBounds.Bottom));
        boss.Position = Vector2.Clamp(boss.Position, new Vector2(worldBounds.Left, worldBounds.Top), new Vector2(worldBounds.Right, worldBounds.Bottom));

    }

    public void Draw(Camera camera) {
        game.GraphicsDevice.Clear(Color.White);

        Vector2 screenCenter = new Vector2(worldBounds.Width / 2, worldBounds.Height / 2);

        camera.Position = screenCenter;

        camera.BeginDraw();

        projectiles.ForEach(p => p.Draw(camera.spriteBatch));
        player.Draw(camera.spriteBatch);
        boss.Draw(camera.spriteBatch);

        camera.EndDraw();
    }
}