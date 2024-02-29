using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace cse3902;

public interface ISprite : IGameObject
{
    public void SetPosition(float x, float y);
    public bool IsAnimationDone();
}
