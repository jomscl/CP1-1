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


namespace CP_1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        UserControlledSprite player; // solo el jugador principal, en este pc
        Texture2D whiteRectangle;

        // Lista de srpites utiles, tanto net players como el ladron
        List<Sprite> spriteList = new List<Sprite>();

        //// Listado de casas
        //List<Casas2> listaCasas = new List<Casas2>();
        Texture2D pixel;
       

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void LoadContent( )
        {
            // creación de las casas
            CP_1.Game1.listaCasas.Add(new Casas2(0, new Vector2(0, 0), 67, 124, 'v', new Point(0, 0), new Vector2(1, -4), 'c'));
            CP_1.Game1.listaCasas.Add(new Casas2(1, new Vector2(0, 67), 67, 117, 'v', new Point(0, 1), new Vector2(1, -4), 's'));
            CP_1.Game1.listaCasas.Add(new Casas2(1, new Vector2(0, 133), 67, 111, 'v', new Point(0, 2), new Vector2(1, -4), 'c'));
            CP_1.Game1.listaCasas.Add(new Casas2(2, new Vector2(0, 200), 67, 105, 'v', new Point(0, 3), new Vector2(1, -4), 'c'));
            CP_1.Game1.listaCasas.Add(new Casas2(2, new Vector2(0, 267), 67, 99, 'v', new Point(0, 4), new Vector2(1, 4), 'c'));
            CP_1.Game1.listaCasas.Add(new Casas2(3, new Vector2(0, 333), 67, 93, 'v', new Point(0, 5), new Vector2(1, 4), 'c'));
            CP_1.Game1.listaCasas.Add(new Casas2(3, new Vector2(0, 400), 67, 87, 'v', new Point(0, 6), new Vector2(1, 4), 'c'));
            CP_1.Game1.listaCasas.Add(new Casas2(4, new Vector2(0, 467), 67, 81, 'v', new Point(0, 7), new Vector2(1, 4), 's'));
            CP_1.Game1.listaCasas.Add(new Casas2(4, new Vector2(0, 533), 67, 69, 'v', new Point(0, 8), new Vector2(1, 4), 'c'));






            //CP_1.Game1.listaCasas.Add(new Casas2(0, new Vector2(0, 0), 43, 48, 'v', new Point(0, 0), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(1, new Vector2(0, 43), 43, 48, 'v', new Point(1, 0), new Vector2(0, -5), 's'));
            //CP_1.Game1.listaCasas.Add(new Casas2(2, new Vector2(0, 86), 43, 48, 'v', new Point(2, 0), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(3, new Vector2(0, 129), 43, 48, 'v', new Point(3, 0), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(4, new Vector2(0, 172), 43, 48, 'v', new Point(4, 0), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(5, new Vector2(0, 215), 43, 48, 'v', new Point(5, 0), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(6, new Vector2(0, 258), 43, 48, 'v', new Point(6, 0), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(7, new Vector2(0, 301), 43, 48, 'v', new Point(7, 0), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(8, new Vector2(0, 344), 43, 48, 'v', new Point(8, 0), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(9, new Vector2(0, 387), 43, 48, 'v', new Point(9, 0), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(10, new Vector2(0, 430), 43, 48, 'v', new Point(10, 0), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(11, new Vector2(0, 473), 43, 48, 'v', new Point(11, 0), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(12, new Vector2(0, 516), 43, 48, 'v', new Point(12, 0), new Vector2(0, 5), 's'));
            //CP_1.Game1.listaCasas.Add(new Casas2(13, new Vector2(0, 559), 43, 48, 'v', new Point(13, 0), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(14, new Vector2(48, 559), 43, 48, 'h', new Point(13, 1), new Vector2(-5, 0), 's'));
            //CP_1.Game1.listaCasas.Add(new Casas2(15, new Vector2(96, 559), 43, 48, 'h', new Point(13, 2), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(16, new Vector2(144, 559), 43, 48, 'h', new Point(13, 3), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(17, new Vector2(192, 559), 43, 48, 'h', new Point(13, 4), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(18, new Vector2(240, 559), 43, 48, 'h', new Point(13, 5), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(19, new Vector2(288, 559), 43, 48, 'h', new Point(13, 6), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(20, new Vector2(336, 559), 43, 48, 'h', new Point(13, 7), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(21, new Vector2(384, 559), 43, 48, 'h', new Point(13, 8), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(22, new Vector2(432, 559), 43, 48, 'h', new Point(13, 9), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(23, new Vector2(480, 559), 43, 48, 'h', new Point(13, 10), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(24, new Vector2(528, 559), 43, 48, 'h', new Point(13, 11), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(25, new Vector2(576, 559), 43, 48, 'h', new Point(13, 12), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(26, new Vector2(624, 559), 43, 48, 'h', new Point(13, 13), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(27, new Vector2(672, 559), 43, 48, 'h', new Point(13, 14), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(28, new Vector2(720, 559), 43, 48, 'h', new Point(13, 15), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(29, new Vector2(768, 559), 43, 48, 'h', new Point(13, 16), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(30, new Vector2(816, 559), 43, 48, 'h', new Point(13, 17), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(31, new Vector2(864, 559), 43, 48, 'h', new Point(13, 18), new Vector2(5, 0), 's'));
            //CP_1.Game1.listaCasas.Add(new Casas2(32, new Vector2(912, 559), 43, 48, 'h', new Point(13, 19), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(33, new Vector2(912, 516), 43, 48, 'v', new Point(19, 12), new Vector2(0, 5), 's'));
            //CP_1.Game1.listaCasas.Add(new Casas2(34, new Vector2(912, 473), 43, 48, 'v', new Point(19, 11), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(35, new Vector2(912, 430), 43, 48, 'v', new Point(19, 10), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(36, new Vector2(912, 387), 43, 48, 'v', new Point(19, 9), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(37, new Vector2(912, 344), 43, 48, 'v', new Point(19, 8), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(38, new Vector2(912, 301), 43, 48, 'v', new Point(19, 7), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(39, new Vector2(912, 258), 43, 48, 'v', new Point(19, 6), new Vector2(0, 5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(40, new Vector2(912, 215), 43, 48, 'v', new Point(19, 5), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(41, new Vector2(912, 172), 43, 48, 'v', new Point(19, 4), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(42, new Vector2(912, 129), 43, 48, 'v', new Point(19, 3), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(43, new Vector2(912, 86), 43, 48, 'v', new Point(19, 2), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(44, new Vector2(912, 43), 43, 48, 'v', new Point(19, 1), new Vector2(0, -5), 's'));
            //CP_1.Game1.listaCasas.Add(new Casas2(45, new Vector2(912, 0), 43, 48, 'v', new Point(19, 0), new Vector2(0, -5), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(46, new Vector2(864, 0), 43, 48, 'h', new Point(18, 0), new Vector2(5, 0), 's'));
            //CP_1.Game1.listaCasas.Add(new Casas2(47, new Vector2(816, 0), 43, 48, 'h', new Point(17, 0), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(48, new Vector2(768, 0), 43, 48, 'h', new Point(16, 0), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(49, new Vector2(720, 0), 43, 48, 'h', new Point(15, 0), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(50, new Vector2(672, 0), 43, 48, 'h', new Point(14, 0), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(51, new Vector2(624, 0), 43, 48, 'h', new Point(13, 0), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(52, new Vector2(576, 0), 43, 48, 'h', new Point(12, 0), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(53, new Vector2(528, 0), 43, 48, 'h', new Point(11, 0), new Vector2(5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(54, new Vector2(480, 0), 43, 48, 'h', new Point(10, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(55, new Vector2(432, 0), 43, 48, 'h', new Point(9, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(56, new Vector2(384, 0), 43, 48, 'h', new Point(8, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(57, new Vector2(336, 0), 43, 48, 'h', new Point(7, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(58, new Vector2(288, 0), 43, 48, 'h', new Point(6, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(59, new Vector2(240, 0), 43, 48, 'h', new Point(5, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(60, new Vector2(192, 0), 43, 48, 'h', new Point(4, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(61, new Vector2(144, 0), 43, 48, 'h', new Point(3, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(62, new Vector2(96, 0), 43, 48, 'h', new Point(2, 0), new Vector2(-5, 0), 'c'));
            //CP_1.Game1.listaCasas.Add(new Casas2(63, new Vector2(48, 0), 43, 48, 'h', new Point(1, 0), new Vector2(-5, 0), 's'));


            // posicion inicial del npc (ladron)
            Vector2 npc = new Vector2(600, 300); // por ahora parte al centro, después será al azar, en alguna casa
          
            

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Images/Jugadores"), new Vector2(150, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(6, 6), "", SpriteEffects.None, new Point(0, 0));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(300, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 300), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
            spriteList.Add(new EvadingSprite(Game.Content.Load<Texture2D>(@"Images/NPC"), npc, new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(0, 0), "", this, .75f, 150, SpriteEffects.None, new Point(0, 0)));

            pixel = new Texture2D(Game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it
            //pixel = new Texture2D(Game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
             base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //// Update player
            //player.Update(gameTime, Game.Window.ClientBounds);
            //// Update all sprites
            //foreach (Sprite s in spriteList)
            //{
            //    s.Update(gameTime, Game.Window.ClientBounds);
            //    // Check for collisions and exit game if there is one
            //    if (s.collisionRect.Intersects(player.collisionRect))
            //    {
            //        //Game.Exit();
                    
            //    }
            //}
            UpdateSprites(gameTime);

            base.Update(gameTime);
        }

        protected void UpdateSprites(GameTime gameTime)
        {
            // Update player
            player.Update(gameTime, Game.Window.ClientBounds);

            // Update all non-player sprites
            for (int i = 0; i < spriteList.Count; ++i)
            {
                Sprite s = spriteList[i];
                
                
                s.Update(gameTime, Game.Window.ClientBounds);

                // Check for collisions
                if (s.collisionRect.Intersects(player.collisionRect))
                {

                }
  

            }

        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            Rectangle rtemp;
            Color colorIterativo;
          
            // dibujar las casas
            for (int i = 0; i<CP_1.Game1.listaCasas.Count; i++)
            {
                if (CP_1.Game1.listaCasas[i].GetTipo == 'c')
                {
                    rtemp = new Rectangle((int)CP_1.Game1.listaCasas[i].GetPosition.X, (int)CP_1.Game1.listaCasas[i].GetPosition.Y, (int)CP_1.Game1.listaCasas[i].GetAncho, (int)CP_1.Game1.listaCasas[i].GetAlto);
                    //resto=Math.DivRem(i, 2, resto);
                    if ( (i%2) == 0) { colorIterativo = Color.Red; } else { colorIterativo = Color.Yellow; }
                    DrawBorder(rtemp, 1, colorIterativo);
                    //spriteBatch.Draw(whiteRectangle, new Rectangle((int)CP_1.Game1.listaCasas[i].GetPosition.X, (int)CP_1.Game1.listaCasas[i].GetPosition.Y, (int)CP_1.Game1.listaCasas[i].GetAncho, (int)CP_1.Game1.listaCasas[i].GetAncho),Color.White);
                }
            }
            
            // Draw the player
            player.Draw(gameTime, spriteBatch);
            // Draw all sprites
            foreach (Sprite s in spriteList)
                s.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public Vector2 GetPlayerPosition()
        {
            return player.GetPosition;
        }


        // rutinas para acceder a los datos de cada casa, pero no funciona!
        public int cantidadCasas(int i=0)
        {
            return CP_1.Game1.listaCasas.Count; 
        }

        public Vector2 arranqueCasa(int i)
        {
            return CP_1.Game1.listaCasas[i].GetArranque;
        }

        public Vector2 posicionCasa(int i)
        {
            return CP_1.Game1.listaCasas[i].GetPosition;
        }

        public char tipoCasa(int i)
        {
            return CP_1.Game1.listaCasas[i].GetTipo;
        }

        public Rectangle intersectoCasa(int i)
        {
            return CP_1.Game1.listaCasas[i].collisionRect;
        }
        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }
    }
}
