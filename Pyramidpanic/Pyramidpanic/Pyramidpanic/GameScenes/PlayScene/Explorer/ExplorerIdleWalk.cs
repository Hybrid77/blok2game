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
           




            if (this.explorer.Position.X < 640-15) 
            {
               // this.explorer.State = this.explorer.ExplorerWalkLeft;
                //this.explorer.ExplorerWalkLeft.Initialize();
            }

            if (Input.EdgeDetectKeyDown(Keys.Right)) 
            {
                this.explorer.State = this.explorer.ExplorerWalkRight;
                this.explorer.ExplorerWalkRight.Initialize();
                this.explorer.ExplorerIdle.Rotation = 0;
                this.effect = SpriteEffects.FlipVertically;
                
            }
            else if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.ExplorerWalkLeft;
                this.explorer.ExplorerWalkLeft.Initialize();
                this.explorer.ExplorerIdle.Rotation = 0;
                this.effect = SpriteEffects.FlipHorizontally;
                
            }

            else if (Input.EdgeDetectKeyDown(Keys.Down))
            {
                this.explorer.State = this.explorer.ExplorerWalkDown;
                this.explorer.ExplorerWalkDown.Initialize();
                this.explorer.ExplorerIdle.rotation = (float)Math.PI / 2;
                this.effect = SpriteEffects.FlipVertically;
            }
            else if (Input.EdgeDetectKeyDown(Keys.Up))
            {
                this.explorer.State = this.explorer.ExplorerWalkUp;
                this.explorer.ExplorerWalkUp.Initialize();
                this.explorer.ExplorerIdle.rotation = (float)Math.PI / 2;
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
