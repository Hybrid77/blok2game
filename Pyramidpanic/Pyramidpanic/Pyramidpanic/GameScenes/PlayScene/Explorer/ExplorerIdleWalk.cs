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
    
    
    public class ExplorerIdleWalk : AnimatedSprite, IEntityState
    {
        //fields
        private Explorer explorer;
        private Vector2 velocity;
       
        

        //properties
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }
        public float Rotation
        {
            set { this.rotation = value; }
        }


        //constructor
        public ExplorerIdleWalk(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle(0, 0, 32, 32);
            this.velocity = new Vector2(0f, 0f);
            this.effect = SpriteEffects.FlipVertically;
            
        }


        public void Initialize()
        {
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {
            if (Input.EdgeDetectKeyUp(Keys.Right)) 
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                this.explorer.ExplorerIdle.Rotation = 0f;
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipVertically;
                
            }
            else if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                this.explorer.ExplorerIdleWalk.Rotation = 0f;
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipHorizontally;
                
            }

            else if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                this.explorer.ExplorerWalkDown.Initialize();
                this.explorer.ExplorerIdleWalk.rotation = (float)Math.PI / 2;
                this.effect = SpriteEffects.FlipVertically;
            }
            else if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.ExplorerIdle;
                this.explorer.ExplorerWalkUp.Initialize();
                this.explorer.ExplorerIdleWalk.rotation = (float)Math.PI / 2;
                this.effect = SpriteEffects.FlipVertically;
            }
            this.explorer.Position += this.velocity;
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            //zorgd voor de animatie (roept de update method aan van de
            //animated class
            base.Update(gameTime);
        }
        
        
        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
