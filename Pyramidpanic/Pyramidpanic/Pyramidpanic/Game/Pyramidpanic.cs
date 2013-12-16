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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {   

        //fields.
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        #region StartScene var.
        // Dit maakt een variable aan die verwijst naar de StartScene
        private StartScene startScene; 
        #endregion

        #region PlayScene var.
        // Dit maakt een variable aan die verwijst naar de StartScene
        private PlayScene playScene; 
        #endregion

        #region HelpScene var.
        // Dit maakt een variable aan die verwijst naar de StartScene
        private HelpScene helpScene; 
        #endregion

        #region GameOverScene var.
        // Dit maakt een variable aan die verwijst naar de GameOverScene
        private GameOverScene gameOverScene; 
        #endregion

        #region LoadScene var.
        // Dit maakt een variable aan die verwijst naar de GameOverScene
        private LoadScene loadScene;
        #endregion

        #region ScoreScene var.
        // Dit maakt een variable aan die verwijst naar de GameOverScene
        private ScoreScene scoreScene;
        #endregion

        #region IState var.
        //maak een variable iState aan van het typen interface IState.
        private IState iState; 
        #endregion

        #region Properties van de Scenes en de IState.
        //properties
        //maakt de interface variable iState beschikbaar buiten de class door middel van 
        // een property IState.
        public IState IState
        {

            get { return this.iState; }
            set { this.iState = value; }

        }
#endregion

        public SpriteBatch Spritebatch
        {

            get { return this.spriteBatch; }
            set { this.spriteBatch = value; }
        
        }

        //properties
        //maakt de interface variable startScene beschikbaar buiten de class door middel van 
        // een property StartScene
        public StartScene StartScene
        {

            get { return this.startScene; }

        }

        

        //properties
        //maakt de interface variable playScene beschikbaar buiten de class door middel van 
        // een property PlayScene
        public PlayScene PlayScene
        {

            get { return this.playScene; }

        }

        //properties
        //maakt de interface variable helpScene beschikbaar buiten de class door middel van 
        // een property HelpScene
        public HelpScene HelpScene
        {

            get { return this.helpScene; }

        }

        //properties
        //maakt de interface variable gameOverScene beschikbaar buiten de class door middel van 
        // een property GameOverScene
        public GameOverScene GameOverScene
        {

            get { return this.gameOverScene; }

        }

        //properties
        //maakt de interface variable loadScene beschikbaar buiten de class door middel van 
        // een property LoadScene
        public LoadScene LoadScene
        {

            get { return this.loadScene; }

        }


        //properties
        //maakt de interface variable loadScene beschikbaar buiten de class door middel van 
        // een property LoadScene
        public ScoreScene ScoreScene
        {

            get { return this.scoreScene; }

        }


          
        //dit is de constructor.
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Window.Title = "Pyramid Panic v1.1.7";

            #region Window Mesurements.
		//verandert de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

            //verandert de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            //past de nieuwe hoogte en breedte van het canvas
            this.graphics.ApplyChanges();
	#endregion;
            
            
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            #region The Spritebatch
            // een spritebatch is nodig voor het tekenen van textures op het canvas.
            spriteBatch = new SpriteBatch(GraphicsDevice); 
            #endregion


            #region Object that calls the class "StartScene".
            // We maken nu het object/ instantie aan van het type startscreen.
            //Dit doe je door:
            // de constructor aan te roepen van de StartScene class.
            this.startScene = new StartScene(this); 
            #endregion

            #region Object that calls the class "PlayScene".
            // We maken nu het object/ instantie aan van het type playscreen.
            //Dit doe je door:
            // de constructor aan te roepen van de PlayScene class.
            this.playScene = new PlayScene(this); 
            #endregion

            #region Object that calls the class "HelpScene".
            // We maken nu het object/ instantie aan van het type helpscreen.
            //Dit doe je door:
            // de constructor aan te roepen van de HelpScene class.
            this.helpScene = new HelpScene(this); 
            #endregion

            #region Object that calls the class "GameOverScene".
            // We maken nu het object/ instantie aan van het type gameoverscreen.
            //Dit doe je door:
            // de constructor aan te roepen van de GameOverScene class.
            this.gameOverScene = new GameOverScene(this); 
            #endregion

            #region Object that calls the class "LoadScene".
            // We maken nu het object/ instantie aan van het type loadscreen.
            //Dit doe je door:
            // de constructor aan te roepen van de LoadScene class.
            this.loadScene = new LoadScene(this);
            #endregion

            #region Object that calls the class "ScoreScene".
            // We maken nu het object/ instantie aan van het type loadscreen.
            //Dit doe je door:
            // de constructor aan te roepen van de LoadScene class.
            this.scoreScene = new ScoreScene(this);
            #endregion

            //hier staat welke Scene word aangeroepen.
            this.iState = this.StartScene;
           
        }

       
        protected override void UnloadContent()
        {
           
        }

       
        protected override void Update(GameTime gameTime)
        {
            IsMouseVisible = true;
            //zorgt dat het spel stopt waneer je op de back-button clickt.
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || 
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();         

            Input.Update();
            
            //Dit vervangt wat hier boven staat.
            this.iState.Update(gameTime);

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        { 
            //geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            
            //voor een sprite batch instantie iets kan tekenen moet de begin() methode
            //aangeroepen worden van de spritebatch class.
            this.spriteBatch.Begin();

            #region This calls the DrawMethod of startscene.
            //roep de draw method aan van startscene.
            //this.startScene.Draw(gameTime); 
            #endregion

            #region This calls the DrawMethod of playscene.
            //roep de draw method aan van playscene.
            //this.playScene.Draw(gameTime); 
            #endregion

            #region This calls the DrawMethod of helpscene.
            //roep de draw method aan van helpscene.
            //this.helpScene.Draw(gameTime); 
            #endregion

            #region This calls the DrawMethod of gameoverscene.
            //roep de draw method aan van gameoverscene.
            this.gameOverScene.Draw(gameTime); 
            #endregion

            #region This calls the DrawMethod of loadscene.
            //roep de draw method aan van loadscene.
            this.loadScene.Draw(gameTime);
            #endregion

            #region This calls the DrawMethod of scorescene.
            //roep de draw method aan van scorescene.
            this.scoreScene.Draw(gameTime);
            #endregion

            this.iState.Draw(gameTime);


            // nadat de spritebatch.draw() is aangeroepen moet de end() methode van de 
            //spritebatch class worden aangeroepen
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
