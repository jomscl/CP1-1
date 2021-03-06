﻿using System;
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
        //public EvadingSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, Point sentido, SpriteManager spriteManager, float evasionSpeedModifier, int evasionRange)
        //    : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, sentido, evasionSpeedModifier, evasionRange)
        //{
        //    this.spriteManager = spriteManager;
        //    this.evasionSpeedModifier = evasionSpeedModifier;
        //    this.evasionRange = evasionRange;
        //}

        //public EvadingSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, SpriteEffects SpEfect, Point sentido, float evasionSpeedModifier, int evasionRange)
        //    : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, millisecondsPerFrame, sentido, evasionSpeedModifier, evasionRange)
        //{
        //    this.spriteManager = spriteManager;
        //    this.evasionSpeedModifier = evasionSpeedModifier;
        //    this.evasionRange = evasionRange;
        //}

        //public EvadingSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame, SpriteEffects SpEfect, Point sentido, SpriteManager spriteManager, float evasionSpeedModifier, int evasionRange)
        //    : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame, SpEfect, sentido, spriteManager, evasionSpeedModifier, evasionRange)
        //{
        //    this.spriteManager = spriteManager;
        //    this.evasionSpeedModifier = evasionSpeedModifier;
        //    this.evasionRange = evasionRange;
        //}

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // First, move the sprite along its direction vector
            //position += speed;

            // inicio deteccion de sentido optimo para arrancar
            if (!evade)
            {
                position = direccionEscape(position, clientBounds);
            }
           
            // Use the player position to move the sprite closer in
            // the X and/or Y directions
            Vector2 pplayer = spriteManager.GetPlayerPosition();

            if (evade)
            {
                // Move away from the player horizontally
                if (pplayer.X < position.X)
                {
                    position.X += Math.Abs(speed.Y)+2;
                   // Debug.WriteLine("Izquierda");
                }
                else if (pplayer.X > position.X)
                {
                    position.X -= Math.Abs(speed.Y);
                   // Debug.WriteLine("Derecha");
                }

                // Move away from the player vertically
                if (pplayer.Y < position.Y)
                {
                    position.Y += Math.Abs(speed.X)+2;
                   // Debug.WriteLine("Abajo");
                }
                else if (pplayer.Y > position.Y)
                {
                    position.Y -= Math.Abs(speed.X);
                    //Debug.WriteLine("Arriba");
                }
            }
            else
            {
                if (Vector2.Distance(position, pplayer) < evasionRange)
                {
                    // Player is within evasion range,
                    // reverse direction and modify speed
                    speed *= -evasionSpeedModifier;
                    evade = true;
                }
            }

            // revisión de fuera de pantalla
            if(limitePantalla(clientBounds));
            if (paredCasa(clientBounds)) ;

            // calculo de sentido, no funciona bien!
            if (speed.X > 0) { sentido.X = 0; } else { sentido.X = 1; }
            if (speed.Y > 0) { sentido.Y = 0; } else { sentido.Y = 1; }

            base.Update(gameTime, clientBounds);
        }

        public override Point psentido
        {
            get { return sentido; }
        }

        //public bool limitePantalla(Rectangle clientBounds)
        //{
        //    bool clip = false;
        //    //int alto = Game.Window.ClientBounds.Height;
        //    //int ancho = Game.Window.ClientBounds.Width;

        //    if (position.X < 10)
        //    {
        //        position.X = 10;
        //        clip = true;
        //    }
        //    if (position.Y < 10)
        //    {
        //        position.Y = 10;
        //        clip = true;
        //    }
          
        //    if (position.X > clientBounds.Width - frameSize.X - 10)
        //    {
        //        position.X = clientBounds.Width - frameSize.X -10;
        //        clip = true;
        //    }
        //    if (position.Y > clientBounds.Height - frameSize.Y - 10)
        //    {
        //        position.Y = clientBounds.Height - frameSize.Y - 10;
        //        clip = true;
        //    }
           
        //    return clip;
            
        //}

       
    }
}