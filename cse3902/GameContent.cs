﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using cse3902.Projectiles;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Reflection.Metadata;


namespace cse3902
{
    public class GameContent
    {
        private ContentManager content;

        public Texture2D LinkSpritesheet;
        public Texture2D NewLinkSpritesheet;

        public Texture2D TilesSheet;
        public Texture2D ItemSheet;
        public Texture2D mergedSheet;

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
        public Texture2D SpritesheetLinkWalkDamaged;
        public Texture2D SpriteSheetLinkAdditionItems;
        public Texture2D SpriteSheetFlipped;
        public Texture2D gameStartTriangle;

        public Texture2D enemies;
        public Texture2D enemiesSheet;
        public Texture2D skeleton;
        public Texture2D goriya;
        public Texture2D oldman;
        public Texture2D boggus;

        public Texture2D blueBoomerang;
        public Texture2D weapon;
        public Texture2D weapon2;
        public Texture2D redBackground;
        public Texture2D rooms;
        public Texture2D walls;
        public Texture2D topDoors;
        public Texture2D rightDoors;
        public Texture2D bottomDoors;
        public Texture2D leftDoors;
        public Texture2D hud;
        public Texture2D BlackScreen;
        public SpriteFont font;

        public Song bgmusic;
        public Song BossMusic;
        public Song MenuMusic;
        public SoundEffect sword;
        public SoundEffect itemPickUp;
        public SoundEffect linkDamage;
        public SoundEffect linkDead;
        public SoundEffect enemyDamage;
        public SoundEffect enemyDead;
        public SoundEffect arrowBoomerang;
        public SoundEffect bombDrop;
        public SoundEffect bombBlowUp;
        public SoundEffect fireball;
        public SoundEffect newFireball;
        public SoundEffect Victory;
        public SoundEffect GameOver;
        
        

        private Texture2D LoadTexture2D(String name)
        {
            return content.Load<Texture2D>(name);
        }
        private SoundEffect LoadSoundEffect(String name)
        {
           
            return content.Load<SoundEffect>(name);
        }
        public GameContent(ContentManager content) 
        {
            this.content = content;
            font = content.Load<SpriteFont>("font_arial");
            gameStartTriangle = LoadTexture2D("gameStartTriangle");
            LinkSpritesheet = LoadTexture2D("spritesheet_link");
            BlackScreen = LoadTexture2D("blackScreen");
            NewLinkSpritesheet = LoadTexture2D("spritesheet");
            mergedSheet = LoadTexture2D("merged");
            TilesSheet = LoadTexture2D("Tileset");
            ItemSheet = LoadTexture2D("Items");
            hud = LoadTexture2D("hud");
            boggus = LoadTexture2D("Boss");
            redBackground = LoadTexture2D("Red_Color");
            SpriteSheetFlipped = LoadTexture2D("flipped");
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
            SpritesheetLinkWalkDamaged = LoadTexture2D("spritesheet_link_walk_damaged");
            
            enemies = LoadTexture2D("enemies");
            enemiesSheet = LoadTexture2D("enemiesSheet");
            skeleton = LoadTexture2D("skeleton");
            goriya = LoadTexture2D("spritesheet_goriya_walk");
            oldman = LoadTexture2D("oldMan");
            blueBoomerang = LoadTexture2D("BlueBoomerang");
            weapon = LoadTexture2D("Weapon");
            weapon2 = LoadTexture2D("Weapon2");

            rooms = LoadTexture2D("rooms");
            walls = LoadTexture2D("walls");
            topDoors = LoadTexture2D("topDoors");
            bottomDoors = LoadTexture2D("bottomDoors");
            leftDoors = LoadTexture2D("leftDoors");
            rightDoors = LoadTexture2D("rightDoors");

            bgmusic = content.Load<Song>(@"Sound/Dungeon");
            BossMusic = content.Load<Song>(@"Sound/Boss");
            MenuMusic = content.Load<Song>(@"Sound/MainTheme");
            sword = LoadSoundEffect(@"Sound/LOZ_Sword_Slash");
            itemPickUp = LoadSoundEffect(@"Sound/LOZ_Get_Item");
            linkDamage = LoadSoundEffect(@"Sound/LOZ_Link_Hurt");
            linkDead = LoadSoundEffect(@"Sound/LOZ_Link_Die");
            enemyDamage = LoadSoundEffect(@"Sound/LOZ_Enemy_Hit");
            enemyDead = LoadSoundEffect(@"Sound/LOZ_Enemy_Die");
            arrowBoomerang = LoadSoundEffect(@"Sound/LOZ_Arrow_Boomerang");
            bombDrop = LoadSoundEffect(@"Sound/LOZ_Bomb_Drop");
            bombBlowUp = LoadSoundEffect(@"Sound/LOZ_Bomb_Blow");
            fireball = LoadSoundEffect(@"Sound/LOZ_Fireball");
            newFireball = LoadSoundEffect(@"Sound/LOZ_Enemy_NewFireBall");
            GameOver = LoadSoundEffect(@"Sound/GameOver");
            Victory = LoadSoundEffect(@"Sound/VictorySound");
        }
    }
}
