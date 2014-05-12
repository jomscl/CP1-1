using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CP_1
{
    class Casas2
    {
        int numero;
        Vector2 posicion;
        int alto;
        int ancho;
        char orientación; // 'h' para horizintal, 'v' para vertical
        Point indice;
        Vector2 arranque;
        char tipo; //c= casa, s= calle
        
        SpriteManager spriteManager;

        public Casas2(int numero, Vector2 posicion, int alto, int ancho, char orientacion, Point indice, Vector2 arranque, char tipo)
           // : this(numero, posicion, alto, ancho, orientacion, indice, arranque)
        {
            this.numero = numero;
            this.posicion = posicion;
            this.ancho = ancho;
            this.alto = alto;
            this.orientación = orientacion;
            this.indice = indice;
            this.arranque = arranque;
            this.tipo = tipo;
            this.spriteManager = spriteManager;
        }

        public Vector2 GetPosition
        {
            get { return posicion; }
        }

        public Point GetIndice
        {
            get { return indice; }
        }

        public Vector2 GetArranque
        {
            get { return arranque; }
        }

        public int GetAncho
        {
            get { return ancho; }
        }

        public int GetAlto
        {
            get { return alto; }
        }

        public char GetOrientacion
        {
            get { return orientación; }
        }

        public char GetTipo
        {
            get { return tipo; }
        }

        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                (int)posicion.X,
                (int)posicion.Y,
                ancho,
                alto);
            }
        }
    }
}
