using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using cse3902.Interfaces;
using cse3902.Enemy;
using cse3902.Objects;

namespace cse3902
{
    public class Level
    {
        private Player player;
        private List<IEnemy> enemies;
        private int idxEnemy;
        private List<IItemPickup> items;
        private int idxItem;
        private List<IBlock> blocks;
        private int idxBlock;

        public Level(GameContent content, IController controller)
        {
            player = new Player(content);
            player.Position = new Vector2(100, 100);

            enemies = new List<IEnemy>()
            {
                new Skeleton(content),
                new Dragon(content),
                new Gel(content),
                new Keese(content),
                new Goriya(content),
            };
            idxEnemy = 0;

            items = new List<IItemPickup>
            {
                new FiveRupiesItemPickup(content),
                new FireItemPickUp(content),
                new RupyItemPickup(content),
                new TriforceItemPickup(content),
                new MapItemPickup(content),
                new KeyItemPickup(content),
                new HeartItemPickup(content),
                new HeartContainerItemPickup(content),
                new FairyItemPickup(content),
                new CompassItemPickUp(content),
                new ClockItemPickUp(content),
                new BowItemPickup(content),
                new YellowBoomerangItemPickup(content),
                new BombItemPickup(content),
                new LifePotionItemPickup(content),
                new SecondPotionItemPickup(content),
                new LetterItemPickup(content),
                new FoodItemPickup(content),
                new SwordItemPickup(content),
                new WhiteSwordItemPickup (content),
                new MagicalSwordItemPickup(content),
                new MagicalShieldItemPickup(content),
                new BlueCandleItemPickup(content),
                new RedCandleItemPickup (content),
                new RedRingItemPickup(content),
                new BlueRingItemPickup (content),
                new PowerBraceletItemPickup(content),
                new RecorderItemPickup(content),
                new RaftItemPickup(content),
                new StepLadderItemPickup(content),
                new MagicalRodItemPickup(content),
                new BookOfMagicItemPickup(content),
                new MagicalKeyItemPickup(content),
            };
            idxItem = 0;
            items.ForEach(i => i.Position = new Vector2(300, 200));

            blocks = new List<IBlock>() {
                new Block1(content),
                new Block2(content),
                new Block3(content),
                new Block4(content),
                new Block5(content),
                new Block6(content),
                new Block7(content),
            };
            idxBlock = 0;
            blocks.ForEach(b => b.Position = new Vector2(200, 200));
        }

        public void Update(GameTime gameTime, IController controller)
        {
            if (controller.isEnemyPressP())
            { 
                idxEnemy++;
                idxEnemy %= enemies.Count;
            }
            if (controller.isEnemyPressO())
            {
                idxEnemy--;
                if (idxEnemy < 0) idxEnemy = enemies.Count - 1;
            }

            if (controller.isNextItemKeyPress())
            {
                idxItem++;
                idxItem %= items.Count;
            }

            if(controller.isPreviousItemKeyPress()) 
            {
                idxItem--;
                if (idxItem < 0) idxItem = items.Count - 1;
            }

            if (controller.isNextBlockPressed())
            {
                idxBlock++;
                idxBlock %= blocks.Count;
            }

            if (controller.isPreviousBlockPressed())
            {
                idxBlock--;
                if (idxBlock < 0) idxBlock = blocks.Count - 1;
            }

            player.Update(gameTime, controller);
            enemies[idxEnemy].Update(gameTime, controller);
            items[idxItem].Update(gameTime, controller);
            blocks[idxBlock].Update(gameTime, controller);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            enemies[idxEnemy].Draw(spriteBatch);
            items[idxItem].Draw(spriteBatch);
            blocks[idxBlock].Draw(spriteBatch);
        }
    }
}
