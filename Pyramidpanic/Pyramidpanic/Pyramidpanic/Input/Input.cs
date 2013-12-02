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
    public static class Input
    {
        //Fields
        
        // KeyboardStates voor Edge-detection
        private static KeyboardState ks, oks;
        //mouse states voor Edge-detection
        private static MouseState ms, oms;

        private static Rectangle mouseRect;

        //Constructor
        static Input() {

            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oks = ks;
            oms = ms;
            mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);

        }


        //Update
        public static void Update() {
           
            
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
        }


        #region Edge detector for the key was pressed but isn't anymore.
        //dit is een edgedetector voor het signaleren of een knop nu ingedrukt is en 
        //de vorige Update niet ingedruckt was
        public static bool EdgeDetectKeyUp(Keys key)
        {

            return (ks.IsKeyUp(key) && oks.IsKeyDown(key));

        }
        
        #endregion

        #region Edge detector for the key wasn't pressed but is pressed now.
        //dit is een edgedetector voor het signaleren of een knop niet ingedrukt is en 
        //de vorige Update wel ingedruckt was
        public static bool EdgeDetectKeyDown(Keys key)
        {

            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));

        }  
        #endregion

        //Dit is een level detector voor het detecteren of een keyboardtoets is ingedrukt.
        public static bool EdgeDetectMousePressLeft(){

        return ((ms.LeftButton == ButtonState.Pressed) && 
            (oms.LeftButton == ButtonState.Released));
    }

        //Dit is een level detector voor het detecteren of een keyboardtoets is ingedrukt.

        public static bool LevelDetectKeyDown(Keys key) { 
        return (ks.IsKeyDown(key));
        
        }

        public static bool LevelDetectKeyUp(Keys key)
        {
            return (ks.IsKeyUp(key));

        }

        #region Mouse position.
        //laat de positie van de muis.
        public static Vector2 MousePosition()
        {
            return new Vector2(ms.X, ms.Y);

        }

        #endregion

        public static Rectangle MouseRect() {

            mouseRect.X = ms.X;
            mouseRect.Y = ms.Y;

            return mouseRect;

        }

    }
}
