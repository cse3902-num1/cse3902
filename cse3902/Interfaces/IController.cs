using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace cse3902;

public interface IController
{

    public void Update(GameTime gameTime);

    /* player keys */
    public bool isPlayerMoveLeftPressed();
    public bool isPlayerMoveRightPressed();
    public bool isPlayerMoveUpPressed();
    public bool isPlayerMoveDownPressed();
    public bool isPlayerAttackJustPressed();
    public bool isPlayerTakeDamageJustPressed();

    /* player item use keys */
    public bool isPlayerUseItem1JustPressed();
    public bool isPlayerUseItem2JustPressed();
    public bool isPlayerUseItem3JustPressed();
    public bool isPlayerUseItem4JustPressed();
    public bool isPlayerUseItem5JustPressed();
    public bool isPlayerUseItem6JustPressed();
    public bool isPlayerUseItem7JustPressed();
    public bool isPlayerUseItem8JustPressed();
    public bool isPlayerUseItem9JustPressed();
    public bool isMutePressed();
    /* enemy keys */
    public bool isEnemyPressO();
    public bool isEnemyPressP();
   

    /* item keys */
    public bool isPreviousItemKeyPress();
    public bool isNextItemKeyPress();

    /* block keys */
    public bool isNextBlockPressed();
    public bool isPreviousBlockPressed();

    /* gameplay keys */
    public bool isResetPressed();
    public bool isQuitPressed();
    public bool isPausePressed();

    /* room controls */
    public bool isLeftClick();
    public bool isRightClick();

    /* display the inventory */
    public bool isInventoryDisplayedPressed();
     public bool isSwitchSlotAPressed();
    public bool isSwitchSlotBPressed();

}
