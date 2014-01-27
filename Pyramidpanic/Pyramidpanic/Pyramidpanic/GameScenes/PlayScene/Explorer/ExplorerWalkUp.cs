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
    
    
    public class ExplorerWalkUp : AnimatedSprite, IEntityState
    {
        //fields
        private Explorer explorer;
        private Vector2 velocity;
        

        //constructor
        public ExplorerWalkUp(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            this.velocity = new Vector2(0f, this.explorer.Speed);
            this.rotation = (float)Math.PI / 2;
            this.effect = SpriteEffects.FlipHorizontally;
           
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {

            if (this.explorer.Position.Y < 0+ 17) 
            {
                this.explorer.State = this.explorer.ExplorerIdleWalk;
                this.explorer.ExplorerIdle.Initialize();
               
            }

            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                this.explorer.ExplorerIdle.Initialize();
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipHorizontally;
                
            }


            this.explorer.Position -= this.velocity;
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            base.Update(gameTime);
        }
        
        
        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
