using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse3902.PlayerClasses
{
    public class PlayerStateIdle : IPlayerState
    {
        private Player player;
        private Dictionary<Direction, ISprite> sprites;
        private GameContent content;
        private Vector2 PlayerIdleOrigin = new Vector2(8, 8);

        public PlayerStateIdle(GameContent content, Player player)
        {
            this.content = content;
            this.player = player;

            sprites = new Dictionary<Direction, ISprite>() {
                {
                    Direction.Left,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerIdleLeft
                    }, PlayerIdleOrigin)
                },
                {
                    Direction.Right,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerIdleRight
                    }, PlayerIdleOrigin)
                },
                {
                    Direction.Up,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerIdleUp
                    }, PlayerIdleOrigin)
                },
                {
                    Direction.Down,
                    new Sprite(content.SpritesheetLinkWalk, new List<Rectangle>() {
                        PlayerConstant.PlayerIdleDown
                    }, PlayerIdleOrigin)
                },
            };
        }

        public void Update(GameTime gameTime, List<IController> controllers)
        {
            /* enter move state if any movement keys are pressed */
            if (controllers.Any(c => c.isPlayerMoveLeftPressed())
                || controllers.Any(c => c.isPlayerMoveUpPressed())
                || controllers.Any(c => c.isPlayerMoveDownPressed())
                || controllers.Any(c => c.isPlayerMoveRightPressed()))
            {
                player.State = new PlayerStateMove(content, player);
            }

            /* enter attack state if attack key is pressed */
            else if (controllers.Any(c => c.isPlayerAttackJustPressed()))
            {
                SoundManager.Manager.swordSound();
                player.State = new PlayerStateAttack(content, player);
            }

            /* enter item state if any item use keys are pressed */
            /* TODO: finish once items classes are created */
            IInventoryItem item = null;
            if      (controllers.Any(c => c.isPlayerUseBombJustPressed())) item = new BlueBombInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseMagicalBoomerangPressed())) item = new MagicalBoomerangInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseBlueBowPressed())) item = new BlueBowInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseFireballPressed())) item = new FireballInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseFirePressed())) item = new FireInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseGreenBoomerangPressed())) item = new GreenBoomerangInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUseGreenBowPressed())) item = new GreenBowInventoryItem(content);
            else if (controllers.Any(c => c.isPlayerUsePurpleCrystalPressed())) item = new PurpleCystleInventoryItem();
            if (item != null)
            {
                if (player.ItemUseCooldown.ElapsedMilliseconds >= Player.ITEM_USE_COOLDOWN) {
                    player.State = new PlayerStateItem(content, player, item);
                }
            }
        
            /* play idle sprite animation */
            sprites[player.Facing].Update(gameTime, controllers);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[player.Facing].SetPosition(player.Position.X, player.Position.Y);
            sprites[player.Facing].Draw(spriteBatch);
        }
    }
}
