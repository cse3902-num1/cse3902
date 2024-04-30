using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902.Bossfight;

public class BasicBossfightProjectile : IBossfightProjectile
{
    public bool IsDead {set;get;}
    public bool IsEnemy {set;get;}
    public Vector2 Position {get;set;}
    public Vector2 Velocity {get;set;}
    public float Radius {get;set;}
    public Sprite sprite {get;set;}

    public int TTL = 30_000; /* time to live in milliseconds */
    private Stopwatch TTLTimer;

    private GameContent content;
    public BossfightLevel Level {set;get;}

    public BasicBossfightProjectile(GameContent content, BossfightLevel level, Vector2 position, Vector2 velocity, float radius, Sprite sprite) {
        this.content = content;
        this.Level = level;
        this.IsDead = false;
        this.IsEnemy = true;
        this.Position = position;
        this.Velocity = velocity;
        this.Radius = radius;
        this.sprite = sprite;

        TTLTimer = new Stopwatch();
        TTLTimer.Start();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        if (TTLTimer.ElapsedMilliseconds >= TTL) IsDead = true;

        Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        sprite.Update(gameTime, controllers);
    }
}