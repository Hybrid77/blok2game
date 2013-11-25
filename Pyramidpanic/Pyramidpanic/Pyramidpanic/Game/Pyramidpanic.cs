//met using kan je een microsoft xna codebibliotheek toevoegen gebruiken in je class.
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

namespace PyramidPanic
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {   

        //fields.
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        

        //dit is de constructor.
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Pyramid Panic v1.1.7";

            //verandert de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

            //verandert de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            //past de nieuwe hoogte en breedte van het canvas
            this.graphics.ApplyChanges();
            
            
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // een spritebatch is nodig voor het tekenen van textures op het canvas.
            spriteBatch = new SpriteBatch(GraphicsDevice);

           
        }

       
        protected override void UnloadContent()
        {
           
        }

       
        protected override void Update(GameTime gameTime)
        {
            //zorgt dat het spel stopt waneer je op de back-button clickt.
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || 
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();

           

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        { 
            //geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            base.Draw(gameTime);
        }
    }
}
