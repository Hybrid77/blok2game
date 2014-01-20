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
    
    
    public class ExplorerWalkRight : AnimatedSprite, IEntityState
    {
        //fields
        private Scorpion scorpion;
        private Vector2 velocity;

        //constructor
        public ExplorerWalkRight(Scorpion scorpion)
            : base(scorpion)
        {
            this.scorpion = scorpion;
            this.destinationRectangle = new Rectangle((int)this.scorpion.Position.X, (int)this.scorpion.Position.Y, 32, 32);
            this.velocity = new Vector2(this.scorpion.Speed, 0f);
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
            this.destinationRectangle.Y = (int)this.scorpion.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {

            if (this.scorpion.Position.X > 640-32) 
            {
                this.scorpion.State = new WalkLeft(this.scorpion);
                this.scorpion.WalkLeft.Initialize();
            }
            this.scorpion.Position += this.velocity;
            this.destinationRectangle.X = (int)this.scorpion.Position.X;
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
