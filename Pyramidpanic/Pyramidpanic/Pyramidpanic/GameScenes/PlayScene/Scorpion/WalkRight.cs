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
    
    
    public class WalkRight : AnimatedSprite, IEntityState
    {
        //fields
        //hier kijgt de scorpion class de naam scorpion
        private Scorpion scorpion;
        //hier word de vector2 als velocity aangegeven.
        private Vector2 velocity;

        //constructor
        public WalkRight(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            //hier word aangegeven dat de scorpion niet word omgedraait
            this.effect = SpriteEffects.None;
            //dit geeft de positie van de scorpion aan en de breedte en lengte 
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X,
                                                      (int)this.scorpion.Position.Y,
                                                       32,
                                                       32);
            //hier word de loop snelheid aangegeven van de beetle
            this.velocity = new Vector2(0f, this.scorpion.Speed);
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {
            //als de posietie van de scorpion groter is dan 640 - 17px dan:
            if (this.scorpion.Position.X > 640-17) 
            {
                //word de state van de scorpionx verandert naar walkleft
                this.scorpion.State = new WalkLeft(this.scorpion);
                //hier word de initialize method aangeroepen van de walkleft class
                this.scorpion.WalkLeft.Initialize();
            }

            //dit zorgt er voor dat de scorpion naar rechts beweegt
            this.scorpion.Position += this.velocity;
            //dit zegt dat de destination rectangle x
            //gelijk staat aan de positie van de scorpion op de x as.
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            //dit zegt dat de destination rectangle y
            //gelijk staat aan de positie van de scorpion op de y as.
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            base.Update(gameTime);
        }
        
        
        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
