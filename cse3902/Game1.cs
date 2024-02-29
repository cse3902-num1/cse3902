﻿using cse3902.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cse3902.Objects;
using cse3902.Enemy;

namespace cse3902;



public class Game1 : Game
{
    /* loaded game content accessible by anyone with a reference to this Game1 */
    

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    public KeyboardController controller;
    private GameContent gameContent;
    
    private Level level;

    private Texture2D room;
    
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        controller = new KeyboardController();
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = 768; // Change this to your desired width
        graphics.PreferredBackBufferHeight = 528; // Change this to your desired height
        graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        gameContent = new GameContent(Content);

        room = gameContent.rooms;
       
        level = new Level(gameContent, controller);
    }

    protected override void Update(GameTime gameTime)
    {
        controller.Update(gameTime);

        /* reset level if R is pressed */
        if (controller.isResetPressed())
        {
            level = new Level(gameContent, controller);
        }

        /* quit game if Q is pressed */
        if (controller.isQuitPressed())
        {
            Exit();
        }

        level.Update(gameTime, controller);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Lavender);

        /* enable nearest-neighbor texture filtering */
        SamplerState s = new SamplerState();
        s.Filter = TextureFilter.Point;

        spriteBatch.Begin(samplerState: s);
        /*
        int screenWidth = GraphicsDevice.Viewport.Width;
        int screenHeight = GraphicsDevice.Viewport.Height;
        int roomWidth = 256 * 3; // Considering the scale factor of 3.0f
        int roomHeight = 176 * 3; // Considering the scale factor of 3.0f
        Vector2 position = new Vector2((screenWidth - roomWidth) / 2, (screenHeight - roomHeight) / 2);*/

        /* Draw the room texture *//*
        spriteBatch.Draw(room,
            position,
            new Rectangle(258, 886, 256, 176),
            Color.White,
            0.0f,
            Vector2.Zero,
            3.0f,
            SpriteEffects.None,
            1.0f);
        */

        level.Draw(spriteBatch);
       
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
