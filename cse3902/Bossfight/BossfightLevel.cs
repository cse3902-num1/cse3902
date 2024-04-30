using System;
using System.Collections.Generic;
using System.Linq;
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

    public const float WORLD_WIDTH = 868;
    public const float WORLD_HEIGHT = 828;

    public BossfightLevel(GameContent content, Game1 game) {
        this.content = content;
        this.game = game;

        boss = new Boss(content, this, new Vector2(0, -350));
        player = new BossfightPlayer(content, this, new Vector2(0, 4));
        projectiles = new List<IBossfightProjectile>();
    }

    public void SpawnProjectile(IBossfightProjectile projectile) {
        projectiles.Add(projectile);
    }

    public void Update(GameTime gameTime, List<IController> controllers) {

        player.Update(gameTime, controllers);
        boss.Update(gameTime, controllers);
        projectiles = projectiles.Where(p => !p.IsDead).ToList();
        projectiles.ForEach(p => p.Update(gameTime, controllers));

        /* make sure player can't leave the area */
        Vector2 playerPosition = player.Position;
        playerPosition.X = Math.Clamp(playerPosition.X, -WORLD_WIDTH/2, WORLD_WIDTH/2);
        playerPosition.Y = Math.Clamp(playerPosition.Y, -WORLD_HEIGHT/2, WORLD_HEIGHT/2);
        player.Position = playerPosition;
    }

    public void Draw(Camera camera) {
        game.GraphicsDevice.Clear(Color.White);

        camera.Position = new Vector2(0, 0);

        camera.BeginDraw();


        player.Draw(camera.spriteBatch);
        projectiles.ForEach(p => p.Draw(camera.spriteBatch));
        boss.Draw(camera.spriteBatch);

        camera.EndDraw();
    }
}