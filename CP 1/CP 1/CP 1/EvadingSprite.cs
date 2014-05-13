using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CP_1
{
    class EvadingSprite : Sprite
    {
        // Save a reference to the sprite manager to
        // use to get the player position
        SpriteManager spriteManager;

        // Variables to delay evasion until player is close 
        float evasionSpeedModifier;
        int evasionRange;
        bool evade = false;
        bool contactoCasa = false;

        //10 + 3
        public EvadingSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame,
            Point sheetSize, Vector2 speed, string collisionCueName,
            SpriteManager spriteManager, float evasionSpeedModifier,
            int evasionRange, SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset,
            currentFrame, sheetSize, speed, collisionCueName, SpEfect, sentido)
        {
            this.spriteManager = spriteManager;
            this.evasionSpeedModifier = evasionSpeedModifier;
            this.evasionRange = evasionRange;
        }

        //11 + 3 
        public EvadingSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame,
            Point sheetSize, Vector2 speed, int millisecondsPerFrame,
            string collisionCueName, SpriteManager spriteManager,
            float evasionSpeedModifier, int evasionRange,
             SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset,
            currentFrame, sheetSize, speed, millisecondsPerFrame,
            collisionCueName,  SpEfect,  sentido)
        {
            this.spriteManager = spriteManager;
            this.evasionSpeedModifier = evasionSpeedModifier;
            this.evasionRange = evasionRange;
        }
  

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // First, move the sprite along its direction vector
            position += speed;

            // inicio deteccion de sentido optimo para arrancar
            if (paredCasa(clientBounds)) { contactoCasa = true; }
            if (!contactoCasa)
            {
                speed = direccionEscape(clientBounds);
            }
           
            // Use the player position to move the sprite closer in
            // the X and/or Y directions
            Vector2 pplayer = spriteManager.GetPlayerPosition();

           

            // revisión de fuera de pantalla
            limitePantalla(clientBounds);
            //paredCasa(clientBounds) ;

            // calculo de sentido, no funciona bien!
            if (speed.X > 0) { sentido.X = 0; } else { sentido.X = 1; }
            if (speed.Y > 0) { sentido.Y = 0; } else { sentido.Y = 1; }

            base.Update(gameTime, clientBounds);
        }

        public override Point psentido
        {
            get { return sentido; }
        }

   

       
    }
}