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
    public class Explorer : IAnimatedSprite
    {

        //Fields
        //hier word de texture2d gedfineert en de naam texture word er aan gegeven.
        private Texture2D texture;
        //hier defineer je de game zelf met de naam game ervoor.
        private PyramidPanic game;
        //hier word IEntity state als state gedefineerd.
        private IEntityState state;
        //hierword speed als een int gedefineerd en krijgt de waarde 2
        private int speed = 2;
        //hier is vector2 als position gedefineerd.
        private Vector2 position;
        

        //maakt van iedere toestand (met andere woorden state) een field
        private ExplorerWalkUp explorerWalkUp;
        private ExplorerWalkDown explorerwalkDown;
        private ExplorerWalkLeft explorerWalkLeft;
        private ExplorerWalkRight explorerWalkRight;
        private ExplorerIdle explorerIdle;
        private ExplorerIdleWalk explorerIdleWalk;
        private Rectangle explorerRectangle;
        private Vector2 origin;

        //properties
        //hier word de getter voor explorerwalkup aangegeven
        public ExplorerWalkUp ExplorerWalkUp
        {
            get { return this.explorerWalkUp; }

        }
        //hier word de getter voor explorerwalkdown aangegeven
        public ExplorerWalkDown ExplorerWalkDown
        {
            get { return this.explorerwalkDown; }

        }
        //hier word de getter voor explorerwalkleft aangegeven
        public ExplorerWalkLeft ExplorerWalkLeft
        {
            get { return this.explorerWalkLeft; }

        }
        //hier word de getter voor explorerwalkright aangegeven
        public ExplorerWalkRight ExplorerWalkRight
        {
            get { return this.explorerWalkRight; }

        }
        //hier word de getter voor exploreridle aangegeven
        public ExplorerIdle ExplorerIdle
        {
            get { return this.explorerIdle; }

        }
        //hier word de getter voor exploreridlewalk aangegeven
        public ExplorerIdleWalk ExplorerIdleWalk
        {
            get { return this.explorerIdleWalk; }

        }
        //hier word de getter voor position aangegeven en de setter van position maar ook de initialize
        public Vector2 Position 
        {

            get { return this.position; }
            set { 
                    this.position = value;
                    this.state.Initialize();
                }
        
        }
        //hier word de setter voor IEntityState aangegeven
        public IEntityState State
        {
            set { 
                    this.state = value;
                    this.state.Initialize();
                }
    
        }
        //hier word de getter voor PyramidPanic aangegeven
        public PyramidPanic Game 
        {
            get { return this.game; }
        }
        //hier word de getter voor speed aangegeven
        public int Speed
        {
            get { return this.speed; }
        }
        //hier word de getter voor Texture2d aangegeven
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        

        //Constructor
        public Explorer(PyramidPanic game, Vector2 position)
        {
            //hier word this.position gelijk gesteld aan positionin de constructor
            this.position = position;
            // hier word this. game gelijk gesteld aan game in de constructor
            this.game = game;
            //hier word this.texture gelijk gesteld and  game.Content.Load<Texture2D>(@"PlayScene\Explorer\Explorer"); wat de path is naar de afbeelding.
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\Explorer\Explorer");
            //hier word explorerwalkup gelijkgesteld aan nieuw explorerwalkup zodat het gebruikt kan worden voor de explorer
            this.explorerWalkUp = new ExplorerWalkUp(this);
            //hier word explorerwalkdown gelijkgesteld aan nieuw explorerwalkdown zodat het gebruikt kan worden voor de explorer
            this.explorerwalkDown = new ExplorerWalkDown(this);
            //hier word explorerwalkleft gelijkgesteld aan nieuw explorerwalkleft zodat het gebruikt kan worden voor de explorer
            this.explorerWalkLeft = new ExplorerWalkLeft(this);
            //hier word explorerwalkright gelijkgesteld aan nieuw explorerwalkright zodat het gebruikt kan worden voor de explorer
            this.explorerWalkRight = new ExplorerWalkRight(this);
            //hier word exploreridle gelijkgesteld aan exploreridle(this); zodat het gebruikt kan worden voor de explorer
            this.explorerIdle = new ExplorerIdle(this);
            //hier word exploreridlewalk gelijkgesteld aand new exploreridlewalk(this); zodat het gebruikt kan worden voor de explorer
            this.explorerIdleWalk = new ExplorerIdleWalk(this);
            //hier word de begin state aan gegeven waarmee de explorer op het begin gebruikt.
            this.state = this.explorerIdle;

           
        }


        //Update
        public void Update(GameTime gameTime)
        {
            //hier word de update method als state aangeroepen van gameTime
            this.state.Update(gameTime);
        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            //hier word de update method als state aangeroepen van gameTime
            this.state.Draw(gameTime);
        }
    }
}
