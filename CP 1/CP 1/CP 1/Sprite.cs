using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CP_1
{
    abstract class Sprite
    {

        // Save a reference to the sprite manager to
        // use to get the player position
        SpriteManager spriteManager;
        
        //  int alto = 690;
       // int ancho = 1024;
        Texture2D textureImage;
        protected Point frameSize;
        Point currentFrame;
        Point sheetSize;
        int collisionOffset;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;
        protected Vector2 speed;
        protected Vector2 position;
        SpriteEffects SpEfect;
        protected Point sentido;
        protected float evasionSpeedModifier;
        protected int evasionRange;
        public string collisionCueName { get; private set; }
        public int velAbs=5;

        //public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, Point sentido, float evasionSpeedModifier, int evasionRange) 
        //    : this(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, defaultMillisecondsPerFrame, sentido, evasionSpeedModifier, evasionRange)
        //{
        
        //}

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
           int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
           string collisionCueName, SpriteEffects SpEfect, Point sentido)
            : this(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, defaultMillisecondsPerFrame, collisionCueName, SpEfect, sentido)
        {
        }

         //
        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
            int millisecondsPerFrame, string collisionCueName, SpriteEffects SpEfect, Point sentido)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.collisionCueName = collisionCueName;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this.sentido = sentido;
            this.SpEfect = SpEfect;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                if (direction == Vector2.Zero)
                {
                    currentFrame.X = 0;
                    currentFrame.Y = 0;
                }
                else
                {

                    // codigo antiguo
                    ++currentFrame.X;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 1;
                        if (sentido.Y == 0) { currentFrame.Y = 0; } else { currentFrame.Y = 1; }
                    }
                }
                
                // direccion
                if (sentido.X == 0) { SpEfect = SpriteEffects.None; } else { SpEfect = SpriteEffects.FlipHorizontally; }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage, position,
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1f, SpEfect, 0);
        }

        public abstract Vector2 direction
        {
            get;
        }

        public abstract Point psentido
        {
            get;
        }

        public Vector2 GetPosition
        {
            get { return position; }
        }

        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                (int)position.X + collisionOffset,
                (int)position.Y + collisionOffset,
                frameSize.X - (collisionOffset * 2),
                frameSize.Y - (collisionOffset * 2));
            }
        }

      
        public Vector2 direccionEscape(Rectangle clientBounds)
        {
            Vector2 salida;
            salida = speed;

            // calculo de velocidad
            //float velAbs;
            float dsi = 0;
            float dsd = 0;
            float dii = 0;
            float did = 0;
            float dmin = 0;
            Vector2 objetivo;

            // velocidad vectorial
            //velAbs = (float)Math.Sqrt(Math.Pow(direction.X, 2) + Math.Pow(direction.Y, 2));
            velAbs = 3;
            // calculo de la distancia actual a alguno de las esquinas
            dsi = Vector2.Distance(position, new Vector2(0, 0));
            dsd = Vector2.Distance(position, new Vector2(clientBounds.Width, 0));
            dii = Vector2.Distance(position, new Vector2(0, clientBounds.Height));
            did = Vector2.Distance(position, new Vector2(clientBounds.Width, clientBounds.Height));

            // determinar cual esquina es la mas cercana
            dmin = dsi; objetivo = new Vector2(0, 0);
            if (dmin > dsd) { dmin = dsd; objetivo = new Vector2(clientBounds.Width, 0); }
            if (dmin > dii) { dmin = dii; objetivo = new Vector2(0, clientBounds.Height); }
            if (dmin > did) { dmin = did; objetivo = new Vector2(clientBounds.Width, clientBounds.Height); }
            //Debug.Print("sss "+dmin);
            // ir a la esquina mas cercana
            salida.X = (objetivo.X - position.X) / (int)Math.Sqrt(Math.Pow(objetivo.X - position.X, 2) + Math.Pow(objetivo.Y - position.Y, 2)) * velAbs;
            salida.Y = (objetivo.Y - position.Y) / (int)Math.Sqrt(Math.Pow(objetivo.X - position.X, 2) + Math.Pow(objetivo.Y - position.Y, 2)) * velAbs;

            return salida;
        }

        public void limitePantalla(Rectangle clientBounds)
        {
           
            //int alto = Game.Window.ClientBounds.Height;
            //int ancho = Game.Window.ClientBounds.Width;

            if (position.X < 10)
            {
                position.X = 10;
               
            }
            if (position.Y < 10)
            {
                position.Y = 10;
               
            }

            if (position.X > clientBounds.Width - frameSize.X - 10)
            {
                position.X = clientBounds.Width - frameSize.X - 10;
                
            }
            if (position.Y > clientBounds.Height - frameSize.Y - 10)
            {
                position.Y = clientBounds.Height - frameSize.Y - 10;
                
            }

           
        }

        public bool paredCasa(Rectangle clientBounds)
        {
           
            bool clip = false;
            
            // versión nueva

            // ciclo principal
            Vector2 a = spriteManager.GetPlayerPosition();// spriteManager.cantidadCasas(1);
            for (int i = 0; i < spriteManager.cantidadCasas(1); i++)
            {
                //Vector2 posicion = spriteManager.posicionCasa(i);
                Vector2 arranque = spriteManager.arranqueCasa(i);
                char tipo = spriteManager.tipoCasa(i);
                Rectangle rectanguloCasa = spriteManager.intersectoCasa(i);

                if (tipo == 'c')
                {
                    if ( rectanguloCasa.Intersects(this.collisionRect))
                    {
                        this.speed = arranque;
                        clip = true;
                    }
                }
            }

            // versión antigua
            //Rectangle rtemp;
            //// casas principales
            //for (int i = 0; i < SpriteManager.listaCasas.Count; i++)
            //{
            //    rtemp = new Rectangle((int)SpriteManager.listaCasas.,(int)SpriteManager.casas[i].Y,43,48); // parametrizar estos valores
            //    if (rtemp.Intersects(this.collisionRect)){
            //        // detectar donde se chocó.
            //        if ((i>=0 && i <= 9) || (i>=26 && i <= 35)){
            //            // contacto con casa vertical
            //            position.X -= speed.X;
            //            speed.X = 0;
            //            if (speed.Y >= 0) { speed.Y = -velAbs; } else { speed.Y = velAbs; }
            //        }
            //        else {
            //            // contacto con casa Horizontal
            //            position.Y -= speed.Y;
            //            speed.Y = 0;
            //            if (speed.X >= 0) { speed.X = -velAbs; } else { speed.X = velAbs; }
            //        }
            //        clip = true;
            //        //position -= speed*2;
                   
            //    }
            //}

            //// casas esquina
            //for (int i = 0; i < SpriteManager.listaCasas.Count; i++)
            //{
            //    rtemp = new Rectangle((int)SpriteManager.casas2[i].X, (int)SpriteManager.casas[i].Y, 43, 48); // parametrizar estos valores
            //    if (rtemp.Intersects(this.collisionRect))
            //    {
            //       // position -= speed*2;
                   
            //    }
            //}
            return clip;
        }
    }
}
