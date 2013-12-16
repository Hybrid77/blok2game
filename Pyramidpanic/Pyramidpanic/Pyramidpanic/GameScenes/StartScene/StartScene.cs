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
    public class StartScene: IState //: IState voert de interface IState in.
    {
        //Fields van de class StartScene
        private PyramidPanic game;


        private Image background, title;

        //maak een variable (reference) aan van de Menu class genaamt menu
        private Menu menu;


        //de constructor ( heeft de zelfde naam als de class)
        //de constructor krijgt een object game mee van het type PyramidPanic
    public StartScene(PyramidPanic game){

        this.game = game;

        //roept de initialize method aan.
        this.Initialize();
    
    }


    //Initialize method. Deze methode instaleert ( geeft de start waarden aan de variabelen)
    //void wilt zeggen dat er niets teruggegeven word.

    public void Initialize()
    {
    
        //roept de loadcontent aan.
        this.LoadConent();
    
    }

        //LoadConent methode. Deze methode maakt nieuwe objecten aan van de verschilende
        //classes
    public void LoadConent() { 
    
        //nu maken we een object/instantie van de class image.
        this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);
        this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 33f));
        this.menu = new Menu(this.game);

    }

        // Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        //en update alle variabelen, methods enz....
    public void Update(GameTime gameTime) {


        this.menu.Update(gameTime);
  /*  if(Input.EdgeDetectKeyDown(Keys.Z) || (Input.EdgeDetectMousePressLeft())){
   *    this.game.IState = this.game.PlayScene;
   * }

   * if (Input.EdgeDetectKeyDown(Keys.X))
   * {
   *     this.game.IState = this.game.HelpScene;
   * } */




    }
    //Draw methode. Deze methode word normaal 60 maal perseconde aangeroepen en
        //tekent de textures op het canvas
    public void Draw(GameTime gameTime) {

        this.game.GraphicsDevice.Clear(Color.Blue);


        //roept de draw method aan van het BACKGROUND object
        this.background.Draw(gameTime);

        //roept de draw method aan van het TITLE object
        this.title.Draw(gameTime);
        
        //roept de draw method aan van het MENU object
        this.menu.Draw(gameTime);
    }


    }
}
