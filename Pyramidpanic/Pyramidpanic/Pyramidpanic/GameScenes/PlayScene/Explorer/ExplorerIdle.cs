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
    
    
    public class ExplorerIdle : AnimatedSprite, IEntityState
    {
        //fields
        //hier word de class explorer gedefineerd
        private Explorer explorer;
        //hier word de vector2 gedefineerd en de naam gegeven "velocity"
        private Vector2 velocity;
       
        

        //properties
        //hier word de property van de spriteEffects aangegeven waar in de setter van de effect word aangegeven als value.
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }
        //hier
        public float Rotation
        {
            set { this.rotation = value; }
        }


        //constructor
        public ExplorerIdle(Explorer explorer)
            : base(explorer)
        {
            
            this.explorer = explorer;
            //hier word aangegeven wat de maat van het poppetje is
            this.destinationRectangle = new Rectangle(0, 0, 32, 32);
            //hier word de velocity aangegeven als 0 bij 0 als een float getal
            this.velocity = new Vector2(0f, 0f);
            //hier word de spriteEffects aangeroepen en er word erna aangegeven dat het verticaal word gespiegelt.
            this.effect = SpriteEffects.FlipVertically;
            
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {

            //als de rechtertoets is ingedrukt dan: 
            if (Input.EdgeDetectKeyDown(Keys.Right)) 
            {
                //word de state van de explorer explorerewalkright en
                this.explorer.State = this.explorer.ExplorerWalkRight;
                //word de initialize method aangeroepen van explorerwalkright plus 
                this.explorer.ExplorerWalkRight.Initialize();
                //de rotation can explorer idle word aangegeven als 0
                this.explorer.ExplorerIdle.Rotation = 0;
                //maar de effext is aangegeven als flip vertically zodat de fakel aan de linker kant blijft
                this.effect = SpriteEffects.FlipVertically;
                
            }
            //als de linkertoets is ingedrukt dan: 
            else if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                //word de state van de explorer explorerewalkleft en
                this.explorer.State = this.explorer.ExplorerWalkLeft;
                //word de initialize method aangeroepen van explorerwalkleft plus 
                this.explorer.ExplorerWalkLeft.Initialize();
                //de rotation can explorer idle word aangegeven als 0
                this.explorer.ExplorerIdle.Rotation = 0;
                //maar de effext is aangegeven als flip vertically zodat de fakel aan de linker kant blijft
                this.effect = SpriteEffects.FlipHorizontally;
                
            }
            //als de pijltoets die naar beneden wijst is ingedrukt dan: 
            else if (Input.EdgeDetectKeyDown(Keys.Down))
            {
                //word de state van de explorer explorerewalkdown en
                this.explorer.State = this.explorer.ExplorerWalkDown;
                //word de initialize method aangeroepen van explorerwalkdown plus 
                this.explorer.ExplorerWalkDown.Initialize();
                //de rotation can explorer idle word aangegeven als pi/2
                this.explorer.ExplorerIdle.rotation = (float)Math.PI / 2;
                //maar de effext is aangegeven als flip vertically zodat de fakel aan de linker kant blijft
                this.effect = SpriteEffects.FlipVertically;
            }

            //als de pijltoets die naar beneden wijst is ingedrukt dan: 
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
            //base.Update(gameTime);
        }
        
        
        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
