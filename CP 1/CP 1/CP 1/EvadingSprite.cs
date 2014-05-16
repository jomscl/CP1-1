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
            

            // inicio deteccion de sentido optimo para arrancar
            if (paredCasa(clientBounds)) { contactoCasa = true; }
            if (!contactoCasa)
            {
                speed = direccionEscape(clientBounds); contactoCasa = true;
            }
            else
            {
                Vector2 pplayer = spriteManager.GetPlayerPosition();
                speed = Vector2.Zero;
                Random random = new Random();
                  
                if (Vector2.Distance(this.position, pplayer) < 100)
                {
                    if (Math.Abs(pplayer.X - position.X) < 80)
                    {
                        if (pplayer.X < position.X) { speed.X += 3; } else { speed.X -= 3; }
                        speed.Y+= (int)random.Next(-1, 1);
                    }
                    if (Math.Abs(pplayer.Y - position.Y) < 80)
                    {
                        if (pplayer.Y < position.Y) { speed.Y += 3; } else { speed.Y -= 3; }
                        speed.X += (int)random.Next(-1, 1);
                    }
                }
                
            }
           // First, move the sprite along its direction vector
            position += speed;

            // Use the player position to move the sprite closer in
            // the X and/or Y directions
           

            // revisión de fuera de pantalla
            limitePantalla(clientBounds);
            //paredCasa(clientBounds) ;

            // calculo de sentido
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