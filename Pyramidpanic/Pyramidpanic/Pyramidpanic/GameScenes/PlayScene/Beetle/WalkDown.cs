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
    //dit is een toestand class (dus moet hij de interface toepassen)
    //deze classe belooft dat hij de methods uit de interface haalt.


    public class WalkDown : AnimatedSprite, IEntityState
    {
        //fields
        private Beetle beetle;
        private Vector2 velocity;

        //constructor
        public WalkDown(Beetle beetle)
            : base(beetle)
        {
            
            this.beetle = beetle;

            this.effect = SpriteEffects.FlipVertically;
            
            this.destinationRectangle = new Rectangle((int)this.beetle.Position.X, 
                                                      (int)this.beetle.Position.Y, 
                                                       32, 
                                                       32);
            this.velocity = new Vector2(0f, this.beetle.Speed);
        }

        public void Initialize() 
        {
            this.destinationRectangle.X = (int) this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
        
        }



        //update method
        public new void Update(GameTime gameTime)
        {
            if (this.beetle.Position.Y > 480 - 17)
            {
                this.beetle.State = new WalkUp(this.beetle);
                this.beetle.WalkUp.Initialize();
            }

            this.beetle.Position += this.velocity;
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
            base.Update(gameTime);
        }


        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
