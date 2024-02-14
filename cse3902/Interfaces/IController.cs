using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace cse3902;

public interface IController
{

    public void Update(GameTime gameTime);
    public bool isPlayerMoveLeftPress();
    public bool isPlayerMoveRightPress();
    public bool isPlayerMoveUpPress();
    public bool isPlayerMoveDownPress();
    public bool isPlayerAttackPress();
    public bool isItem1Press();
    public bool isItem2Press();
    public bool isItem3Press();
    public bool isEnemyPressO();
    public bool isEnemyPressP();
    public bool isDamaged();
    public bool isResetPressed();
}
