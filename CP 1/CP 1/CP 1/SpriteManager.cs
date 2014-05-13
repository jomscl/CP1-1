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
        UserControlledSprite player;
        List<Sprite> spriteList = new List<Sprite>();

        List<Casas2> listaCasas = new List<Casas2>();

        //public static Vector2[] casas ={
        //                                new Vector2(0 , 86), new Vector2(0 , 129), new Vector2(0 , 172), new Vector2(0 , 215), new Vector2(0 , 258), new Vector2(0 , 301), new Vector2(0 , 344), new Vector2(0 , 387), new Vector2(0 , 430), new Vector2(0 , 473), 
        //                                new Vector2(96 , 559), new Vector2(144 , 559), new Vector2(192 , 559), new Vector2(240 , 559), new Vector2(288 , 559), new Vector2(336 , 559), new Vector2(384 , 559), new Vector2(432 , 559), new Vector2(480 , 559), new Vector2(528 , 559), new Vector2(576 , 559), new Vector2(624 , 559), new Vector2(672 , 559), new Vector2(720 , 559), new Vector2(768 , 559), new Vector2(816 , 559), 
        //                                new Vector2(912 , 473), new Vector2(912 , 430), new Vector2(912 , 387), new Vector2(912 , 344), new Vector2(912 , 301), new Vector2(912 , 258), new Vector2(912 , 215), new Vector2(912 , 172), new Vector2(912 , 129), new Vector2(912 , 86), 
        //                                new Vector2(816 , 0), new Vector2(768 , 0), new Vector2(720 , 0), new Vector2(672 , 0), new Vector2(624 , 0), new Vector2(576 , 0), new Vector2(528 , 0), new Vector2(480 , 0), new Vector2(432 , 0), new Vector2(384 , 0), new Vector2(336 , 0), new Vector2(288 , 0), new Vector2(240 , 0), new Vector2(192 , 0), new Vector2(144 , 0), new Vector2(96 , 0)
        //                             };
        
        //public static Vector2[] casas = {
       //                       new Vector2(0 , 86), new Vector2(0 , 129), new Vector2(0 , 172), new Vector2(0 , 215), new Vector2(06 , 258), new Vector2(0 , 301), new Vector2(0 , 344), new Vector2(0 , 387), new Vector2(0 , 430), new Vector2(0 , 473), new Vector2(0 , 559), 
       //                       new Vector2(144 , 559), new Vector2(192 , 559), new Vector2(240 , 559), new Vector2(288 , 559), new Vector2(336 , 559), new Vector2(384 , 559), new Vector2(432 , 559), new Vector2(480 , 559), new Vector2(528 , 559), new Vector2(576 , 559), new Vector2(624 , 559), new Vector2(672 , 559), new Vector2(720 , 559), new Vector2(768 , 559), new Vector2(816 , 559), 
       //                       new Vector2(912 , 473), new Vector2(912 , 430), new Vector2(912 , 387), new Vector2(912 , 344), new Vector2(912 , 301), new Vector2(912 , 258), new Vector2(912 , 215), new Vector2(912 , 172), new Vector2(912 , 129), new Vector2(912 , 86), 
       //                       new Vector2(816 , 0), new Vector2(768 , 0), new Vector2(720 , 0), new Vector2(672 , 0), new Vector2(624 , 0), new Vector2(576 , 0), new Vector2(528 , 0), new Vector2(480 , 0), new Vector2(432 , 0), new Vector2(384 , 0), new Vector2(336 , 0), new Vector2(288 , 0), new Vector2(240 , 0), new Vector2(192 , 0), new Vector2(144 , 0), new Vector2(96 , 0), 
       //                   };
        //public static Vector2[] casas2 = {new Vector2(0, 0), new Vector2(912, 0), new Vector2(0, 559), new Vector2(912, 559) };
        //public static Vector2[] salidas = {new Vector2(0 , 43), 	new Vector2(912 , 43), new Vector2(0 , 516), 	new Vector2(912 , 516), new Vector2(48 , 0), 	new Vector2(864 , 0), new Vector2(48 , 559), new Vector2(864 , 559) };

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
            listaCasas.Add(new Casas2(0, new Vector2(0, 0), 43, 48, 'v', new Point(0, 0), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(1, new Vector2(0, 43), 43, 48, 'v', new Point(1, 0), new Vector2(0, -5), 's'));
            listaCasas.Add(new Casas2(2, new Vector2(0, 86), 43, 48, 'v', new Point(2, 0), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(3, new Vector2(0, 129), 43, 48, 'v', new Point(3, 0), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(4, new Vector2(0, 172), 43, 48, 'v', new Point(4, 0), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(5, new Vector2(0, 215), 43, 48, 'v', new Point(5, 0), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(6, new Vector2(0, 258), 43, 48, 'v', new Point(6, 0), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(7, new Vector2(0, 301), 43, 48, 'v', new Point(7, 0), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(8, new Vector2(0, 344), 43, 48, 'v', new Point(8, 0), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(9, new Vector2(0, 387), 43, 48, 'v', new Point(9, 0), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(10, new Vector2(0, 430), 43, 48, 'v', new Point(10, 0), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(11, new Vector2(0, 473), 43, 48, 'v', new Point(11, 0), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(12, new Vector2(0, 516), 43, 48, 'v', new Point(12, 0), new Vector2(0, 5), 's'));
            listaCasas.Add(new Casas2(13, new Vector2(0, 559), 43, 48, 'v', new Point(13, 0), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(14, new Vector2(48, 559), 43, 48, 'h', new Point(13, 1), new Vector2(-5, 0), 's'));
            listaCasas.Add(new Casas2(15, new Vector2(96, 559), 43, 48, 'h', new Point(13, 2), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(16, new Vector2(144, 559), 43, 48, 'h', new Point(13, 3), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(17, new Vector2(192, 559), 43, 48, 'h', new Point(13, 4), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(18, new Vector2(240, 559), 43, 48, 'h', new Point(13, 5), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(19, new Vector2(288, 559), 43, 48, 'h', new Point(13, 6), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(20, new Vector2(336, 559), 43, 48, 'h', new Point(13, 7), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(21, new Vector2(384, 559), 43, 48, 'h', new Point(13, 8), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(22, new Vector2(432, 559), 43, 48, 'h', new Point(13, 9), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(23, new Vector2(480, 559), 43, 48, 'h', new Point(13, 10), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(24, new Vector2(528, 559), 43, 48, 'h', new Point(13, 11), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(25, new Vector2(576, 559), 43, 48, 'h', new Point(13, 12), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(26, new Vector2(624, 559), 43, 48, 'h', new Point(13, 13), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(27, new Vector2(672, 559), 43, 48, 'h', new Point(13, 14), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(28, new Vector2(720, 559), 43, 48, 'h', new Point(13, 15), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(29, new Vector2(768, 559), 43, 48, 'h', new Point(13, 16), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(30, new Vector2(816, 559), 43, 48, 'h', new Point(13, 17), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(31, new Vector2(864, 559), 43, 48, 'h', new Point(13, 18), new Vector2(5, 0), 's'));
            listaCasas.Add(new Casas2(32, new Vector2(912, 559), 43, 48, 'h', new Point(13, 19), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(33, new Vector2(912, 516), 43, 48, 'v', new Point(19, 12), new Vector2(0, 5), 's'));
            listaCasas.Add(new Casas2(34, new Vector2(912, 473), 43, 48, 'v', new Point(19, 11), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(35, new Vector2(912, 430), 43, 48, 'v', new Point(19, 10), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(36, new Vector2(912, 387), 43, 48, 'v', new Point(19, 9), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(37, new Vector2(912, 344), 43, 48, 'v', new Point(19, 8), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(38, new Vector2(912, 301), 43, 48, 'v', new Point(19, 7), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(39, new Vector2(912, 258), 43, 48, 'v', new Point(19, 6), new Vector2(0, 5), 'c'));
            listaCasas.Add(new Casas2(40, new Vector2(912, 215), 43, 48, 'v', new Point(19, 5), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(41, new Vector2(912, 172), 43, 48, 'v', new Point(19, 4), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(42, new Vector2(912, 129), 43, 48, 'v', new Point(19, 3), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(43, new Vector2(912, 86), 43, 48, 'v', new Point(19, 2), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(44, new Vector2(912, 43), 43, 48, 'v', new Point(19, 1), new Vector2(0, -5), 's'));
            listaCasas.Add(new Casas2(45, new Vector2(912, 0), 43, 48, 'v', new Point(19, 0), new Vector2(0, -5), 'c'));
            listaCasas.Add(new Casas2(46, new Vector2(864, 0), 43, 48, 'h', new Point(18, 0), new Vector2(5, 0), 's'));
            listaCasas.Add(new Casas2(47, new Vector2(816, 0), 43, 48, 'h', new Point(17, 0), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(48, new Vector2(768, 0), 43, 48, 'h', new Point(16, 0), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(49, new Vector2(720, 0), 43, 48, 'h', new Point(15, 0), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(50, new Vector2(672, 0), 43, 48, 'h', new Point(14, 0), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(51, new Vector2(624, 0), 43, 48, 'h', new Point(13, 0), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(52, new Vector2(576, 0), 43, 48, 'h', new Point(12, 0), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(53, new Vector2(528, 0), 43, 48, 'h', new Point(11, 0), new Vector2(5, 0), 'c'));
            listaCasas.Add(new Casas2(54, new Vector2(480, 0), 43, 48, 'h', new Point(10, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(55, new Vector2(432, 0), 43, 48, 'h', new Point(9, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(56, new Vector2(384, 0), 43, 48, 'h', new Point(8, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(57, new Vector2(336, 0), 43, 48, 'h', new Point(7, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(58, new Vector2(288, 0), 43, 48, 'h', new Point(6, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(59, new Vector2(240, 0), 43, 48, 'h', new Point(5, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(60, new Vector2(192, 0), 43, 48, 'h', new Point(4, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(61, new Vector2(144, 0), 43, 48, 'h', new Point(3, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(62, new Vector2(96, 0), 43, 48, 'h', new Point(2, 0), new Vector2(-5, 0), 'c'));
            listaCasas.Add(new Casas2(63, new Vector2(48, 0), 43, 48, 'h', new Point(1, 0), new Vector2(-5, 0), 's'));


            // posicion inicial del npc
            Random random = new Random();
            //  int casa = random.Next(0, casas.Length);
            Vector2 npc = new Vector2(300, 200);
            //if (npc.X < 100) { npc.X += 350; }
            //if (npc.Y < 100) { npc.Y += 350; }
            //if (npc.X >100) { npc.X -= 350; }
            //if (npc.Y > 100) { npc.Y -= 350; }
            

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Images/Jugadores"),Vector2.Zero, new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(6, 6), "", SpriteEffects.None, new Point(0,0));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
           // spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(300, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
          //  spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 300), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
            spriteList.Add(new EvadingSprite(Game.Content.Load<Texture2D>(@"Images/NPC"), npc, new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(0, 0), "", this, .75f, 150, SpriteEffects.None, new Point(0, 0)));

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

        public int cantidadCasas(int i=0)
        {
            return listaCasas.Count; 
        }

        public Vector2 arranqueCasa(int i)
        {
            return listaCasas[i].GetArranque;
        }

        public Vector2 posicionCasa(int i)
        {
            return listaCasas[i].GetPosition;
        }

        public char tipoCasa(int i)
        {
            return listaCasas[i].GetTipo;
        }

        public Rectangle intersectoCasa(int i)
        {
            return listaCasas[i].collisionRect;
        }

    }
}
