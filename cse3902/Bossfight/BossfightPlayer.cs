using System.Collections.Generic;
using System.Linq;
using cse3902.PlayerClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BossfightPlayer {
    public bool IsDead = false;
    public Vector2 Position;
    public float Radius;
    public int Health = 3;
    public int MaxHealth = 3;

    private Sprite sprite;

    public BossfightLevel Level;
    private GameContent content;

    public BossfightPlayer(GameContent content, BossfightLevel level, Vector2 position) {
        this.content = content;
        this.Level = level;
        this.Position = position;
        this.Radius = 4f;

        this.sprite = new Sprite(
            content.SpritesheetLinkWalk,
            new List<Rectangle>() {
                PlayerConstant.PlayerIdleUp
            },
            new Vector2(8, 8)
        );
    }

    public void Update(GameTime gameTime, List<IController> controllers) {
        if (Health <= 0) IsDead = true;

        if (IsDead) return;

        sprite.Update(gameTime, controllers);

        Vector2 movement = new Vector2(0, 0);
        bool isMoved = false;
        if (controllers.Any(c => c.isPlayerMoveLeftPressed()))  { movement.X -= 1; isMoved = true; }
        if (controllers.Any(c => c.isPlayerMoveRightPressed())) { movement.X += 1; isMoved = true; }
        if (controllers.Any(c => c.isPlayerMoveUpPressed()))    { movement.Y -= 1; isMoved = true; }
        if (controllers.Any(c => c.isPlayerMoveDownPressed()))  { movement.Y += 1; isMoved = true; }
        if (isMoved) {
            movement.Normalize();
            movement *= 200;

            Position += movement * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }

    public void Draw(SpriteBatch spriteBatch) {
        if (IsDead) return;

        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }
}