using System;
using System.Collections.Generic;
using System.Diagnostics;
using cse3902.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public abstract class BasicParticleEffect : IParticleEffect
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}

    protected ISprite sprite; /* set in constructor */

    public BasicParticleEffect(Vector2 position)
    {
        Position = position;
        IsDead = false;
    }

    public virtual void Update(GameTime gameTime, List<IController> controllers)
    {
        sprite.Update(gameTime, controllers);

        if (sprite.IsAnimationDone())
        {
            IsDead = true;
        }
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        sprite.Position = Position;
        sprite.Draw(spriteBatch);
    }
}