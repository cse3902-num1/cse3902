using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace cse3902.Projectiles;

public class GreenArrow : BasicDirectionalProjectile
{
    private Vector2 initialPosition;
    private const float maxDistance = 400f;
    private GameContent content;
    

    public GreenArrow(GameContent content, Vector2 position, Vector2 velocity) : base(position, velocity)
    {
        leftSprite = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(0, 0, 15, 15) }, new Vector2(7.5f, 7.5f));
        rightSprite = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(10, 185, 15, 15) }, new Vector2(7.5f, 7.5f));
        upSprite = new Sprite(content.weapon, new List<Rectangle>() { new Rectangle(1, 185, 7, 15) }, new Vector2(3.5f, 7.5f));
        downSprite = new Sprite(content.weapon2, new List<Rectangle>() { new Rectangle(15, 0, 15, 15) }, new Vector2(7.5f, 7.5f));
        
        initialPosition = position;

        this.content = content;
    }

    private void Die()
    {
        IsDead = true;
        IParticleEffect fx = new ArrowExplode(content, Position);
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
