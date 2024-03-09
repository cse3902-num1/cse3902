using cse3902.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using cse3902.RoomClasses;

namespace cse3902.Projectiles;

public class Fire : IProjectile
{
    public bool IsDead {set;get;}
    public Vector2 Position {set;get;}
    public Vector2 Velocity {set;get;}
    public bool isEnermyProjectile { get; set; }

    private Sprite sprite;
    private Room room;

    public Fire(GameContent content, Room room, Vector2 position)
    {
        sprite = new Sprite(content.weapon2,
            new List<Rectangle>()
            {
                new Rectangle(0, 30, 15, 15),
                new Rectangle(15, 30 , 15, 15)
            },
            new Vector2(7.5f, 7.5f)
        );

        Position = position;
        Velocity = new Vector2(0, 0);
        IsDead = false;
        this.room = room;
    }

    public void Update(GameTime gameTime, List<IController> controllers)
    {
        sprite.Position = Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        sprite.Update(gameTime, controllers);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch);
    }

}
