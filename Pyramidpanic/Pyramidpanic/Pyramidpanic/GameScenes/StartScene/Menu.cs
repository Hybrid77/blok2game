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
   public class Menu
    {
       //Fields
       // Maak enumeration voor de buttons die op ons scherm te zien zijn.
       private enum Buttons { Start, Load, Help, Scores, Quit }


       //maak een variable van het type Buttons geef hen de waarden Button.Start
       private Buttons buttonsActive = Buttons.Start;



       //maak een variable (reference) van het typen Image
       private Image start;
       private Image load;
       private Image scores;
       private Image help;
       private Image quit;

       //maak een variable (reference) van het typen PyramidPanic
       private PyramidPanic game;

       //maak een list van img objecten


       private Color activeColor = Color.Gold;

       //maak een variable button list van het typen List<Image>
       private List<Image> buttonList;


       //Constructor
       public Menu(PyramidPanic game){
           this.game = game;
           this.Initialize();
       }

       public void Initialize() {
           this.LoadContent();
       
       }


       public void LoadContent() {
           //maak een instantie aan van de List<Image> type en stop deze in de variable this.buttonList.

           this.buttonList = new List<Image>();
           this.buttonList.Add(this.start = new Image(this.game, @"StartScene\Button_start", new Vector2 (20f, 433f)));
           this.buttonList.Add(this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(147f, 433f)));
           this.buttonList.Add(this.help = new Image(this.game, @"StartScene\Button_help", new Vector2(274f, 433f)));
           this.buttonList.Add(this.scores = new Image(this.game, @"StartScene\Button_scores", new Vector2(401f, 433f)));
           this.buttonList.Add(this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(530f, 433f)));

           
       }

       //update
       public void Update(GameTime gameTime) {

           if (Input.EdgeDetectKeyDown(Keys.Right) && buttonsActive < Buttons.Quit)
           {

               this.buttonsActive++;
               
               
                   
           }

           if (Input.EdgeDetectKeyDown(Keys.Left) && buttonsActive > Buttons.Start)
           {

               this.buttonsActive--;
           }
           /*we doorlopen het this.buttonList object (type List<Image>) this.buttonList met een fore-each instructie
            * en we roepen voor ieder Image-Object de property Color op en geven de
            * waarde Color.white.
            */

           foreach (Image image in this.buttonList) {

               image.Color = Color.White;
           }

           switch (this.buttonsActive)
           {

               case Buttons.Start:
                  /* if (Input.EdgeDetectKeyDown(Keys.Enter))
                   {

                       this.game.IState = this.game.PlayScene;

                   }
                   else { 
                   
                   }*/
                   //de Ternary operator
                   //variable = () ? waarde als waar : waarde als niet waar;
                   this.game.IState = (Input.EdgeDetectKeyDown(Keys.Enter)) 
                       ? (IState)this.game.PlayScene : this.game.StartScene;
                   this.start.Color = this.activeColor;
               break;

               case Buttons.Load:
                    this.load.Color = this.activeColor;
               break;

               case Buttons.Help:
               if (Input.EdgeDetectKeyDown(Keys.Enter))
               {

                   this.game.IState = this.game.HelpScene;

               }
                    this.help.Color = this.activeColor;
               break;

               case Buttons.Scores:
                    this.scores.Color = this.activeColor;
               break;

               case Buttons.Quit:
                    this.quit.Color = this.activeColor;
               break;
           }
       }



       //Draw
       public void Draw(GameTime gameTime)
       {
           this.start.Draw(gameTime);
           this.load.Draw(gameTime);
           this.help.Draw(gameTime);
           this.scores.Draw(gameTime);
           this.quit.Draw(gameTime);
       }



    }
}
