using System.Collections.Generic;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BossfightLevel
{
    public BossfightPlayer player;
    public Boss boss;
    public List<IBossfightProjectile> projectiles;

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