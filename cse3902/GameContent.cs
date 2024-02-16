using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace cse3902
{
    public class GameContent
    {
        private ContentManager content;

        public Texture2D LinkSpritesheet;
        public Texture2D NewLinkSpritesheet;

        public Texture2D TilesSheet;
        public Texture2D ItemSheet;

        public Texture2D SpritesheetLinkAttackMagicRodMagicShield;
        public Texture2D SpritesheetLinkAttackMagicRod;
        public Texture2D SpritesheetLinkAttackMagicSwordMagicShield;
        public Texture2D SpritesheetLinkAttackMagicSword;
        public Texture2D SpritesheetLinkAttackWhiteSwordMagicShield;
        public Texture2D SpritesheetLinkAttackWhiteSword;
        public Texture2D SpritesheetLinkAttackWoodSwordMagicShield;
        public Texture2D SpritesheetLinkAttackWoodSword;
        public Texture2D SpritesheetLinkItemPickup;
        public Texture2D SpritesheetLinkUseItem;
        public Texture2D SpritesheetLinkWalkMagicShield;
        public Texture2D SpritesheetLinkWalk;
        public Texture2D SpriteSheetLinkAdditionItems;
        public Texture2D SpriteSheetFlipped;

        public Texture2D enemies;
        public Texture2D enemiesSheet;
        public Texture2D skeleton;
        public Texture2D goriya;

        public Texture2D blueBoomerang;
        public Texture2D weapon;
        public Texture2D weapon2;

        private Texture2D LoadTexture2D(String name)
        {
            return content.Load<Texture2D>(name);
        }

        public GameContent(ContentManager content) 
        {
            this.content = content;

            LinkSpritesheet = LoadTexture2D("spritesheet_link");
            NewLinkSpritesheet = LoadTexture2D("spritesheet");
          
            TilesSheet = content.Load<Texture2D>("Tileset");
            ItemSheet = content.Load<Texture2D>("Items");
            SpriteSheetFlipped = content.Load<Texture2D>("flipped");
            SpriteSheetLinkAdditionItems = content.Load<Texture2D>("spritesheet_link");
            SpritesheetLinkAttackMagicRodMagicShield = LoadTexture2D("spritesheet_link_attack_magicrod_magicshield");
            SpritesheetLinkAttackMagicRod = LoadTexture2D("spritesheet_link_attack_magicrod");
            SpritesheetLinkAttackMagicSwordMagicShield = LoadTexture2D("spritesheet_link_attack_magicsword_magicshield");
            SpritesheetLinkAttackMagicSword = LoadTexture2D("spritesheet_link_attack_magicsword");
            SpritesheetLinkAttackWhiteSwordMagicShield = LoadTexture2D("spritesheet_link_attack_whitesword");
            SpritesheetLinkAttackWhiteSword = LoadTexture2D("spritesheet_link_attack_whitesword");
            SpritesheetLinkAttackWoodSwordMagicShield = LoadTexture2D("spritesheet_link_attack_woodsword");
            SpritesheetLinkAttackWoodSword = LoadTexture2D("spritesheet_link_attack_woodsword");
            SpritesheetLinkItemPickup = LoadTexture2D("spritesheet_link_itempickup");
            SpritesheetLinkUseItem = LoadTexture2D("spritesheet_link_useitem");
            SpritesheetLinkWalkMagicShield = LoadTexture2D("spritesheet_link_walk_magicshield");
            SpritesheetLinkWalk = LoadTexture2D("spritesheet_link_walk");

            enemies = LoadTexture2D("enemies");
            enemiesSheet = LoadTexture2D("enemiesSheet");
            skeleton = LoadTexture2D("skeleton");
            goriya = LoadTexture2D("spritesheet_goriya_walk");

            blueBoomerang = LoadTexture2D("BlueBoomerang");
            weapon = LoadTexture2D("Weapon");
            weapon2 = LoadTexture2D("Weapon2");
        }
    }
}
