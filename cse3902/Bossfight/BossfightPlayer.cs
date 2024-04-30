using System;
using System.Collections.Generic;
using System.Linq;
using cse3902.PlayerClasses;
using cse3902.Projectiles;
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
    private List<BasicBossfightProjectile> projectiles;
    private double lastShotTime;  // Time since last shot was fired
    private const double ShootingCooldown = 0.5;

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
        projectiles = new List<BasicBossfightProjectile>();
        lastShotTime = -ShootingCooldown;
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

        if (gameTime.TotalGameTime.TotalSeconds - lastShotTime > ShootingCooldown)
        {
            FireProjectile(gameTime);
        }


        // Update projectiles
        foreach (var projectile in projectiles)
        {
            projectile.Update(gameTime, controllers);
        }
        projectiles.RemoveAll(p => p.IsDead);
    }
    private void FireProjectile(GameTime gameTime)
    {
        var newProjectile = new BasicBossfightProjectile(
            content, Level, Position, new Vector2(0, -300), 5, new Sprite(
            content.enemies,
            new List<Rectangle>() { ProjectileConstant.FireBallAnimationSourceRect3 },
            new Vector2(4.5f, 9)
        ));

        newProjectile.IsEnemy = false;
        projectiles.Add(newProjectile);
        lastShotTime = gameTime.TotalGameTime.TotalSeconds;  // Update last shot time
    }
    public void Draw(SpriteBatch spriteBatch) {
        if (IsDead) return;

        sprite.Position = Position;
        sprite.Draw(spriteBatch);
        foreach (var projectile in projectiles)
        {
            projectile.Draw(spriteBatch);
        }
    }
}