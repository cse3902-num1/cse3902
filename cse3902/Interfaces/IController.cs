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
    public bool isPlayerUseBombJustPressed();
    public bool isPlayerUseMagicalBoomerangPressed();
    public bool isPlayerUseBlueBowPressed();
    public bool isPlayerUseFireballPressed();
    public bool isPlayerUseFirePressed();
    public bool isPlayerUseGreenBoomerangPressed();
    public bool isPlayerUseGreenBowPressed();
    public bool isPlayerUsePurpleCrystalPressed();
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
