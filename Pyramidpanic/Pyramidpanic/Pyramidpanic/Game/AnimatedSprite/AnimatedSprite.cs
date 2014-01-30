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
        //hier krijgt de IAnimatedSprite de naam iAnimatedSprite
        private IAnimatedSprite iAnimatedSprite;
        // hier worden bijde rectangles gedefineed
        //de zource en de destination rectangle
        protected Rectangle sourceRectangle, destinationRectangle;
        //hier word er gezegt dat de timer een float is en dat de start waarde 0 is
        private float timer = 0f;
        //hier krijgt de vector 2 de naam pivot
        private Vector2 pivot;
        //hier krijgt de SpriteEffects de naam effect
        protected SpriteEffects effect;
        //hier is het ene protected variable en niet private
        //zodat het overal gebruikt kan worden.
        protected int imageNumber = 0;
        //het zelfde gebeurt hier.
        protected float rotation = 0f;

        //properties
        //geen propperties


        //constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
        
        this.iAnimatedSprite = iAnimatedSprite;
        //hier krijgt effect de waarde van none.
        this.effect = SpriteEffects.None;
        // hier krijgt de sourcerectangle de plek aan waar die moet beginnen 
        //en ook de waarde van de lengte en breedte van de foto.
        this.sourceRectangle = new Rectangle(this.imageNumber, 0, 32, 32);
        //hier word pivot de waarde van het middel punt gegeven met andere woorden origin.
        this.pivot = new Vector2(16f, 16f);
    
        }

        public void Update(GameTime gameTime) 
        {
            //als this.time groter is can 5/60f dan:
            if (this.timer > 5 / 60f)
            {
                //als de source rectangle van de x kleiner is dan 96 dan:
                if (this.sourceRectangle.X < 96)
                {
                    //kom 32 px bij de standaart waarde van de rectangle erbij.
                    this.sourceRectangle.X += 32;

                }
                else
                {
                    //als het groter word dan 96 dan word de x weer 0
                    this.sourceRectangle.X = 0;

                }
                //de timer word dan weer 0 gezet
                this.timer = 0f;
            }

            //de timer krijgt er steeds 1 bij
            this.timer += 1 / 60f;
        
        
        }

        //draw
        public void Draw(GameTime gameTime) {
            //hier staat de sprite batch van alle classes die kunnen bewegen in de game
            //(scorpion, beetle en explorer)
            //de texture word uit de I animated class gepakt
            //de sourcerectangle en destination tectangle worden uit deze class gebruikt
            //de kleur is wit
            //de rotation word ook uit deze class gehaalt
            //de pivot of terwijl sprite origin word ook uit deze class gehaalt (16f,16f)
            //de effect word ook uit deze class gehaalt

            this.iAnimatedSprite.Game.Spritebatch.Draw(this.iAnimatedSprite.Texture,
                                            this.destinationRectangle,
                                            this.sourceRectangle,
                                            Color.White,
                                            this.rotation,
                                            this.pivot,
                                            this.effect,
                                            0f);
        
        }
    }
}
