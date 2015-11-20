/* Monogame Graphics Prototype
 * Animated Sprite Class
 * Written by Nathan Headley
 * 20/11/2015
 */

/* Change Log
 * 
 * Works with different animations in one sprite sheet
 *  - startAnimation(line number) will decide which animation to play
 *  
 */

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGame_Graphics_Prototype {

    public class AnimatedSprite : Sprite {

        // Variables
        int frameWidth,         // Width of each frame in pixels
            frameHeight,        // Height of each frame in pixels
            horizontalFrames,   // Number of frames in each row
            verticalFrames,     // Number of rows or vertical frames
            currentHorizontal,  // Current horizontal frame
            currentVertical,    // Current vertical frame (current animation)
            currentState;       // Current state of sprite (0 = still, 1 = animating)
        double frameTime,       // Interval between each frame in milliseconds (1000ms = 1s)
                lastTime;       // The time that the last animation occurred

        // Initializer
        public AnimatedSprite(Texture2D inSpriteSheet, float inX, float inY, 
            int inWidth, int inHeight, double inTime, float inScale = 1) {
            
            setTexture(inSpriteSheet);
            setPosition(new Vector2(inX, inY));
            frameWidth = inWidth;
            frameHeight = inHeight;
            horizontalFrames = getTexture().Width / frameWidth;
            verticalFrames = getTexture().Height / frameHeight;
            frameTime = inTime;
            currentState = 1;
        }

        // Method to change which frame is displaying
        public void changeFrame(double inTime) {
            if (currentHorizontal < horizontalFrames - 1) {
                currentHorizontal++;
            } else {
                currentHorizontal = 0;
            }
            lastTime = inTime;
        }

        // Method to start animating, takes in which animation to start
        public void startAnimation(int inAnimation) {
            currentVertical = inAnimation;
            currentState = 1;
        }

        // Getters - no need for setters that i've found?
        public int getFrameWidth() {
            return frameWidth;
        }
        public int getFrameHeight() {
            return frameHeight;
        }
        public int getCurrentHorizontal() {
            return currentHorizontal;
        }
        public int getCurrentVertical() {
            return currentVertical;
        }
        public int getCurrentState() {
            return currentState;
        }
        public double getFrameTime() {
            return frameTime;
        }
        public double getLastTime() {
            return lastTime;
        }

    }

}
