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
        private Explorer explorer;
        private Vector2 velocity;

        //constructor
        public ExplorerWalkRight(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            this.velocity = new Vector2(this.explorer.Speed, 0f);
           
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {
            this.explorer.Position += this.velocity;

            if (this.explorer.Position.X > 640-16) 
            {
                this.explorer.Position -= this.velocity;
                this.explorer.State = this.explorer.ExplorerIdleWalk;
                this.explorer.ExplorerIdleWalk.Effect = SpriteEffects.FlipVertically;
                this.explorer.ExplorerIdleWalk.Rotation = 0f;
                
               
            }

            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                this.explorer.ExplorerIdle.Initialize();
                this.effect = SpriteEffects.FlipVertically;
            }


            this.explorer.Position += this.velocity;
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
