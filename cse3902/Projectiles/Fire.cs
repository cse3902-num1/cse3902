using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using cse3902.RoomClasses;

namespace cse3902.Projectiles;

public class Fire : BasicDirectionalProjectile
{
    private Vector2 initialPosition;
    private const float maxDistance = 200f;
    private GameContent content;
    private Sprite sprite;

    public Fire(GameContent content, Room room, Vector2 position, Vector2 velocity) : base(room, position, velocity)
    {
        sprite = new Sprite(content.weapon2,
            new List<Rectangle>()
            {
                new Rectangle(0, 30, 15, 15),
                new Rectangle(15, 30 , 15, 15)
            },
            new Vector2(7.5f, 7.5f)
        );

        initialPosition = position;
        upSprite = sprite;
        downSprite = sprite;
        leftSprite = sprite;
        rightSprite = sprite;
        this.content = content;
        this.Hitbox = new BoxCollider(position, new Vector2(15, 15), new Vector2(7.5f, 7.5f), ColliderType.PROJECTILE);
    }
    private void Die()
    {
        IsDead = true;
        /* TODO: "spawn" the particle effect in the level */
    }
    public override void Update(GameTime gameTime, List<IController> controllers)
    {

        base.Update(gameTime, controllers);

        if (Vector2.Distance(initialPosition, Position) > maxDistance)
        {
            Die();
        }
    }


}
