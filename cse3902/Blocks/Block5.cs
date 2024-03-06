using System.Collections.Generic;
using cse3902.Objects;
using Microsoft.Xna.Framework;

namespace cse3902;

public class Block5 : BasicBlock
{
    public Block5(GameContent content)
    {
        sprite = new Sprite(
            content.TilesSheet,
            new List<Rectangle>() {
                new Rectangle(19, 28, 16, 16)
            },
            new Vector2(8, 8)
        );
        collider = new BoxCollider(Position, Size, ColliderType);
    }
}