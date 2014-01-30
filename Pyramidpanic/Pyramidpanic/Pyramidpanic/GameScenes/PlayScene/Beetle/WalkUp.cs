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
    
    
    public class WalkUp : AnimatedSprite, IEntityState
    {
        //fields
        //hier kijgt de beetle class de naam beetley
        private Beetle beetle;
        //hier word de vector2 als velocity aangegeven.
        private Vector2 velocity;

        //constructor
        public WalkUp(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
            //hier word aangegeven dat de beetle verticaal word omgedraait.
            this.effect = SpriteEffects.FlipVertically;
            //dit geeft de positie van de beetle aan en de breedte en lengte 
            this.destinationRectangle = new Rectangle((int)this.beetle.Position.X,
                                                      (int)this.beetle.Position.Y,
                                                       32,
                                                       32);
            //hier word de loop snelheid aangegeven van de beetle
            this.velocity = new Vector2(0f, this.beetle.Speed);
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.beetle.Position.X;
            this.destinationRectangle.Y = (int)this.beetle.Position.Y;
           
        }

        //update method
        public new void Update(GameTime gameTime) 
        {
            //als de posietie van de beetle kleiner dan 17px is  dan:
            if (this.beetle.Position.Y < 0 + 17) 
            {
                //word de state van de beetle verandert naar walk down
                this.beetle.State = this.beetle.WalkDown;
                //daarna word de initialize aangeroepen van this.beetle.walkdown
                this.beetle.WalkDown.Initialize();
            }
            //de beetle loopt doordat er 1x de velocity er afgehaalt word 
            //zodat de beetle weer omhoog kan lopen
            this.beetle.Position -= this.velocity;
            //dit zegt dat de destination rectangle y
            //gelijk staat aan de positie van de beetle op de y as.
            this.destinationRectangle.X = (int) this.beetle.Position.X;
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
