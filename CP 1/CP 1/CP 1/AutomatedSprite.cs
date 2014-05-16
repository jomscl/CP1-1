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

        SpriteManager spriteManager;
        // 10
        public AutomatedSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, string collisionCueName, SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, collisionCueName, SpEfect,  sentido)
        {
        }
        // 11
        public AutomatedSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, int millisecondsPerFrame, string collisionCueName,
            SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName,  SpEfect,  sentido)
        {
        }

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // perseguir al npc
            Vector2 npc = spriteManager.GetNpcPosition();
            speed = Vector2.Zero;
            Random random = new Random();

            if (Vector2.Distance(this.position, npc) < 1000)
            {
                if (Math.Abs(npc.X - position.X) < 80)
                {
                    if (npc.X > position.X) { speed.X += 3; } else { speed.X -= 3; }
                    speed.Y += (int)random.Next(-1, 1);
                }
                if (Math.Abs(npc.Y - position.Y) < 80)
                {
                    if (npc.Y > position.Y) { speed.Y += 3; } else { speed.Y -= 3; }
                    speed.X += (int)random.Next(-1, 1);
                }
            }
           
            // avance
            position += speed;
            
             // choque de las casas
            if (paredCasa(clientBounds)) { }

            // condicion de borde
            limitePantalla(clientBounds);  


            
            base.Update(gameTime, clientBounds);
        }


        public override Point psentido
        {
            get { return sentido; }
        }
    } // fin clase
}
