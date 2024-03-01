using System.Collections.Generic;
using cse3902.Objects;
using Microsoft.Xna.Framework;

namespace cse3902;

public class Block4 : BasicBlock
{
    public Block4(GameContent content)
    {
        sprite = new Sprite(
            content.TilesSheet,
            new List<Rectangle>() {
                new Rectangle(53, 11, 16, 16)
            },
            new Vector2(8, 8)
        );
    }
}