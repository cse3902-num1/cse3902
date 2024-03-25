using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.RoomClasses;
using cse3902.Enemy;
using Microsoft.Xna.Framework.Audio;


namespace cse3902.Projectiles;

public class Bomb : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}
    public bool isEnermyProjectile { get; set; }
    public ICollider Hitbox; /* set in constructor */
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
        Hitbox = new BoxCollider(position, new Vector2(7, 15), new Vector2(3.5f, 7.5f), ColliderType.ITEM_PICKUP);
    }

    private void Die()
    {
        SoundEffect bombBlowUp = SoundManager.Manager.bombBlowUpSound();
        bombBlowUp.Play();
        IsDead = true;
        IParticleEffect fx = new BombExplode(content, Position);
        room.ParticleEffects.Add(fx);
        Hitbox.Position = Position;
        foreach (IEnemy e in room.Enemies)
        {
            switch (e)
            {
                case EnemyBase enemyBase:
                    if (Hitbox.IsColliding(enemyBase.Collider))
                    {
                        IsDead = true;
                        e.TakeDmg(1000);

                    }
                    break;
            }
        }
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
