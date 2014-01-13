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
    public abstract class AnimatedSprite
    {
        //fields
        private PyramidPanic game;
        private Rectangle sourceRectangle, destinationRectangle;
        private float timer = 0f;

        
        //properties
        


        //constructor
        public AnimatedSprite(PyramidPanic game)
        {
        this.game = game;
        this.destinationRectangle = new Rectangle(140, 240, 32, 32);
        this.sourceRectangle = new Rectangle(0, 0, 32, 32);

    
        }

        public void Update(GameTime gameTime) 
        {
            if (this.timer > 10 / 60f)
            {
                if (this.sourceRectangle.X < 96)
                {
                    this.sourceRectangle.X += 32;

                }
                else
                {
                    this.sourceRectangle.X = 0;

                }
                this.timer = 0f;
            }

            this.timer += 1 / 60f;
        
        
        }

        //draw
        public void Draw(GameTime gameTime, Texture2D texture) {
            this.game.Spritebatch.Draw(texture,
                                            this.destinationRectangle,
                                            this.sourceRectangle,
                                            Color.White,
                                            0f,
                                            Vector2.Zero,
                                            SpriteEffects.None,
                                            0f);
        
        }
    }
}
