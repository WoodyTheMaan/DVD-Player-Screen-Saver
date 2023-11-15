using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DVD_Player_Screen_Saver
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D DVDTex;
        Rectangle DVDRect;
        Vector2 DVDSpeed;
        List<Color> DVDColors;
        Random generator;
        int currentColor;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            DVDSpeed = new Vector2(2, 2);
            generator = new Random();
            DVDRect = new Rectangle(generator.Next(2, 400), generator.Next(2, 400), 150, 100);
            DVDColors = new() {
                Color.AliceBlue, Color.Green,
                Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.White, Color.SaddleBrown
                , Color.Magenta, Color.Purple, Color.Black
            
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            DVDTex = Content.Load<Texture2D>("Actaul DVD");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            DVDRect.X += (int)DVDSpeed.X;
            DVDRect.Y += (int)DVDSpeed.Y;
            if (DVDRect.Right >= _graphics.PreferredBackBufferWidth || DVDRect.Left <= 0)
            {
                
                DVDSpeed.X *= -1;
                int i = currentColor;
                while (i == currentColor)
                    currentColor = generator.Next(0,DVDColors.Count);
            }
            else if (DVDRect.Bottom >= _graphics.PreferredBackBufferHeight || DVDRect.Top <= 0)
            {
                DVDSpeed.Y *= -1;
                int i = currentColor;
                while (i == currentColor)
                    currentColor = generator.Next(0, DVDColors.Count);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(DVDTex,DVDRect, DVDColors[currentColor]);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}