using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CP_1
{
    class AutomatedSprite : Sprite
    {
        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, Point sentido, float evasionSpeedModifier, int evasionRange)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, sentido, evasionSpeedModifier, evasionRange)
        {
        
        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, int millisecondsPerFrame, Point sentido, float evasionSpeedModifier, int evasionRange)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, millisecondsPerFrame, sentido, evasionSpeedModifier, evasionRange)
        {
        
        }

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            
            // calculo de velocidad
            float velAbs;
            float dsi = 0;
            float dsd = 0;
            float dii = 0;
            float did = 0;
            float dmin = 0;
            Vector2 objetivo;

            // velocidad vectorial
            velAbs = (float)Math.Sqrt(Math.Pow(direction.X,2) + Math.Pow(direction.Y,2));
            
            // calculo de la distancia actual a alguno de las esquinas
            dsi = Vector2.Distance(position, new Vector2(0, 0));
            dsd = Vector2.Distance(position, new Vector2(clientBounds.Width,0));
            dii = Vector2.Distance(position, new Vector2(0, clientBounds.Height));
            did = Vector2.Distance(position, new Vector2(clientBounds.Width, clientBounds.Height));

            // determinar cual esquina es la mas cercana
            dmin = dsi; objetivo=new Vector2(0,0);
            if (dmin > dsd) { dmin = dsd; objetivo = new Vector2(clientBounds.Width, 0); }
            if (dmin > dii) { dmin = dii; objetivo = new Vector2(0, clientBounds.Height); }
            if (dmin > did) { dmin = did; objetivo = new Vector2(clientBounds.Width, clientBounds.Height); }
            //Debug.Print("sss "+dmin);
            // ir a la esquina mas cercana
            position.X += (objetivo.X - position.X) / (int)Math.Sqrt(Math.Pow(objetivo.X - position.X, 2) + Math.Pow(objetivo.Y - position.Y, 2)) * velAbs;
            position.Y += (objetivo.Y - position.Y) / (int)Math.Sqrt(Math.Pow(objetivo.X - position.X, 2) + Math.Pow(objetivo.Y - position.Y, 2)) * velAbs;
            //position += direction;
            
            if (position.X < 10)
                position.X = 10;
            if (position.Y < 10)
                position.Y = 10;
            if (position.X > clientBounds.Width - frameSize.X-10)
                position.X = clientBounds.Width - frameSize.X;
            if (position.Y > clientBounds.Height - frameSize.Y-10)
                position.Y = clientBounds.Height - frameSize.Y;
            
            base.Update(gameTime, clientBounds);
        }


        public override Point psentido
        {
            get { return sentido; }
        }
    } // fin clase
}
