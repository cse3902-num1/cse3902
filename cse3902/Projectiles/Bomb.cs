using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.RoomClasses;

namespace cse3902.Projectiles;

public class Bomb : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}
    private ISprite sprite;
    private Stopwatch explodeTimer = new Stopwatch();
    private GameContent content;
    private Room room;
    
    public Bomb(GameContent content, Room room, Vector2 position)
    {
        sprite = new Sprite(content.weapon, 
            new List<Rectangle>()
            {
                new Rectangle(129, 185, 7, 15)
            },
            new Vector2(3.5f, 7.5f)
        );

        Position = position;
        explodeTimer.Start();

        this.content = content;
        this.room = room;
    }

    private void Die()
    {
        IsDead = true;
        IParticleEffect fx = new BombExplode(content, Position);
        /* TODO: "spawn" the particle effect in the level */
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        sprite.Update(gameTime, controllers);

        if (explodeTimer.ElapsedMilliseconds >= 1500)
        {
            Die();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }


}
