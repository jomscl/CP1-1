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
    class Casas : Sprite //Microsoft.Xna.Framework.GameComponent
    {

        int numero;
        Vector2 posicion;
        int alto;
        int ancho;
        char orientación; // 'h' para horizintal, 'v' para vertical
        Point indice;
        Vector2 arranque;

        public Casas(int numero, Vector2 posicion, int alto, int ancho, char orientacion, Point indice, Vector2 arranque)
            : this (numero, posicion, alto, ancho, orientacion, indice, arranque)
        {
            this.numero = numero;
            this.posicion = posicion;
            this.ancho = ancho;
            this.alto = alto;
            this.orientación = orientacion;
            this.indice = indice;
            this.arranque = arranque;

        }

        public Casas(Game game)
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
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
