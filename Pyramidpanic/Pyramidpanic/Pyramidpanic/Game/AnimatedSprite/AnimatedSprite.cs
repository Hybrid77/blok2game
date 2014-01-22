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
        private IAnimatedSprite iAnimatedSprite;
        protected Rectangle sourceRectangle, destinationRectangle;
        private float timer = 0f;
        private Vector2 spriteOrigin;
        protected SpriteEffects effect;
        protected int imageNumber = 0;
        protected float rotation = 0f;

        //properties
        


        //constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
        this.iAnimatedSprite = iAnimatedSprite;
        this.effect = SpriteEffects.None;
        this.sourceRectangle = new Rectangle(this.imageNumber, 0, 32, 32);
        this.spriteOrigin = new Vector2(16, 16);
    
        }

        public void Update(GameTime gameTime) 
        {
            if (this.timer > 5 / 60f)
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
        public void Draw(GameTime gameTime) {
            this.iAnimatedSprite.Game.Spritebatch.Draw(this.iAnimatedSprite.Texture,
                                            this.destinationRectangle,
                                            this.sourceRectangle,
                                            Color.White,
                                            this.rotation,
                                            this.spriteOrigin,
                                            this.effect,
                                            0f);
        
        }
    }
}
