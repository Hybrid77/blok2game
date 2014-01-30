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
        //hier word de explorer class als explorer aangegeven
        private Explorer explorer;
        //hier word de vector2 als velocity aangegeven.
        private Vector2 velocity;
        

        //constructor
        public ExplorerWalkUp(Explorer explorer)
            : base(explorer)
        {
            //word de velocity 0 en kan de explorer neit meer bewegen
            this.explorer.Position += this.velocity;
            //de state verandert naar explorer idle walk
            this.explorer.State = this.explorer.ExplorerIdleWalk;
            //de sprite effect word fliphorizontally 
            //zodat de explorer in idlewalk nogsteeds naar links bijlft kijken
            this.explorer.ExplorerIdleWalk.Effect = SpriteEffects.FlipHorizontally;
            //en de rotation krijgt een vaste waarde van nul in exploreridle walk
            this.rotation = (float)Math.PI / 2;
           
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {
            //hier staat als de positie van explorer.position.y kleiner is dan 17px
            if (this.explorer.Position.Y < 0+ 17) 
            {
                //dan is de state van explorer Exploreridlewalk.
                this.explorer.State = this.explorer.ExplorerIdleWalk;
                //hier word de initialize aangeroepen can explorer idle
                this.explorer.ExplorerIdle.Initialize();
               
            }

            //als de pijltjes toets die naar bovenwijst niet ingedrukt is:
            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                //dan is de state van explorer exploreridle
                this.explorer.State = this.explorer.ExplorerIdle;
                //hier word de initialize aangeroepen can explorer idle
                this.explorer.ExplorerIdle.Initialize();
                //hier word de effects van exploreridle gelijk gesteld aan spriteeffects.fliphorizontally
                //dat zorgt ervoor dat de fakkel links blijft
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipHorizontally;
                
            }


            this.explorer.Position -= this.velocity;
            //hier staat dat de destination rextangle van de x
            //gelijkstaat aan de (int) x positie van this.explorer
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            //hier staat dat de destination rextangle van de x
            //gelijkstaat aan de (int) x positie van this.explorer.
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            //hier word de base.update method aangeroepen,
            //en gameTime word er in mee gegeven
            base.Update(gameTime);
        }
        
        
        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
