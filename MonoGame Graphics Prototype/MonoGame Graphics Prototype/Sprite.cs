using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGame_Graphics_Prototype {

    public class Sprite {

        // Variables
        private Texture2D texture;
        private Vector2 position,
                        origin;         // Used for rotations
        private float rotationDegrees,
                    scale;

        // Initialiser(s)
        public Sprite() { }

        public Sprite(Texture2D inTexture, float inX, float inY,
            float inRotation = 0, float inScale = 1, float inOriginX = -1, float inOriginY = -1) {

            texture = inTexture;
            position.X = inX;
            position.Y = inY;
            if (inOriginX == -1) {
                origin.X = inX + (texture.Width / 2);
                origin.Y = inY + (texture.Height / 2);
            }
            rotationDegrees = inRotation;
            scale = inScale;
        }


        // Getters
        public Texture2D getTexture() { return texture; }

        public Vector2 getPosition() { return position; }

        public Vector2 getOrigin() { return origin; }

        public float getRotationDegrees() { return rotationDegrees; }

        public float getRotationRadians() {
            float radians = rotationDegrees * (3.1415f / 180);
            return radians;
        }

        public float getScale() { return scale; }

        public int getWidth() { return texture.Width; }

        public int getHeight() { return texture.Height; }

        // Setters
        public void setTexture(Texture2D inTexture) {
            texture = inTexture;
        }
        public void setPosition(Vector2 inPosition) {
            position = inPosition;
        }
        public void setRotation(float inDegrees) {
            rotationDegrees = inDegrees;
        }

    }
}
