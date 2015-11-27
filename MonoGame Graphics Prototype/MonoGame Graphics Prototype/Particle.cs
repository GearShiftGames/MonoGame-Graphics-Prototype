/* Monogame Graphics Prototype
 * Particle Class
 * Written by Nathan Headley
 * 20/11/2015
 */

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGame_Graphics_Prototype {
    public class Particle {

        // Variables
        Vector2 position,
                velocity;
        double life;

        // Initialiser
        public Particle(float inX, float inY, double inLife, int inAngle, float inSpeed) {
            position = new Vector2(inX, inY);
            life = inLife;
            double radians = inAngle * Math.PI / 180;
            velocity.X = (float) (inSpeed * Math.Cos(radians));
            velocity.Y = (float) (inSpeed * Math.Sin(radians));
        }

        // Getters
        public Vector2 getPosition() {
            return position;
        }
        public double getLife() {
            return life;
        }

        // Setters
        public void update(double inTime) {
            if ((life - inTime) > 0) {
                life -= inTime;
            } else {
                life = 0;
            }
            position.X += (float) (velocity.X * (inTime/1000));
            position.Y += (float) (velocity.Y * (inTime/1000));
        }
    }
}
