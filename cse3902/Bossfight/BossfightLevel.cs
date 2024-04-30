using System.Collections.Generic;
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

    public BossfightLevel(GameContent content) {
        this.content = content;

        boss = new Boss(content, this, new Vector2(0, -100));
        player = new BossfightPlayer(content, this, new Vector2(0, 100));
        projectiles = new List<IBossfightProjectile>();
    }

    public void Update(GameTime gameTime, List<IController> controllers) {
        player.Update(gameTime, controllers);
        boss.Update(gameTime, controllers);
        projectiles.ForEach(p => p.Update(gameTime, controllers));
    }

    public void Draw(Camera camera) {
        camera.Position = new Vector2(0, 0);

        camera.BeginDraw();

        projectiles.ForEach(p => p.Draw(camera.spriteBatch));
        player.Draw(camera.spriteBatch);
        boss.Draw(camera.spriteBatch);

        camera.EndDraw();
    }
}