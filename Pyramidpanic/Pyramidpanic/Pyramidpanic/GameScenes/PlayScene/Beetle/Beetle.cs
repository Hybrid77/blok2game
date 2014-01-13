﻿//met using kan je een microsoft xna codebibliotheek toevoegen gebruiken in je class.
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
    class Beetle : AnimatedSprite
    {

        //Fields
        private Texture2D texture;
        private PyramidPanic game;
        private Rectangle sourceRectangle, destinationRectangle;

        //Constructor
        public Beetle(PyramidPanic game)
            : base(game)
        {
            this.game = game;
            this.destinationRectangle.X = 500; // X positie
            this.destinationRectangle.Y = 300; // Y positie
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\Beetle\Beetle");
        }


        //Update
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            base.Draw(gameTime, this.texture);
        }
    }
}
