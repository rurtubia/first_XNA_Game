using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FirstXNAGame
{
    
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D texture_1;
        Rectangle rectangle_1;

        Texture2D fire;
        Rectangle rectangle_2;

        private bool isFire = false;
        private int spaceshipPositionX = 20;
        private int spaceshipPositionY = 100;
        //private Vector2 speed;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Creates the spaceship sprite
            texture_1 = Content.Load<Texture2D>("nave");
            rectangle_1 = new Rectangle(spaceshipPositionX, spaceshipPositionY, 100, 100);
            fire = Content.Load<Texture2D>("fire");
            rectangle_2 = new Rectangle((spaceshipPositionX + 42), (spaceshipPositionY+100), 16, 16);

            //speed.X = 3f;
            //speed.Y = 3f;
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            //Moves the sprite around the screen, setting limits to the spaceship movement.
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) { 
                if (rectangle_1.X <= 700) { 
                    rectangle_1.X += 3;
                    spaceshipPositionX = rectangle_1.X;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
                if (rectangle_1.X >= 0)
                {
                    rectangle_1.X -= 3;
                    spaceshipPositionX = rectangle_1.X;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
                if (rectangle_1.Y >= 5) { 
                    rectangle_1.Y -= 3;
                    spaceshipPositionY = rectangle_1.Y;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) { 
                if (rectangle_1.Y <= 370) { 
                    rectangle_1.Y += 3;
                    spaceshipPositionY = rectangle_1.Y;
                }
            }

            //rectangle_1.X = rectangle_1.X + (int)speed.X;
            //rectangle_1.Y = rectangle_1.Y + (int)speed.Y;


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                isFire = true;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            spriteBatch.Draw(texture_1, rectangle_1, Color.White);

            if (isFire)
            {
                spriteBatch.Draw(fire, rectangle_2, Color.White);    
            }
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
