using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Tabs
    {
        //defining variables

        Color startButtonGreen = new Color("78AE43");
        Color startButtonGreenHovering = new Color("#22AD00");

        public Color boxGreyHovering = new Color("##A3A396");



        //defining X, Y, Width, and Height of all Tabs
        float taskbarBGXPosition = 0;
        float taskbarBGYPosition = 550;
        float taskbatBGWidth = 800;
        float taskbarBGHeight = 50;

        float taskbarBoxYPosition = 552;
        float taskbarBoxWidth = 50;
        float taskbarBoxHeight = 46;

        float taskbarStartXPosition = 0;
        float taskbarStartYPosition = 552;
        float taskbarStartWidth = 150;
        float taskbarStartHeight = 46;

        public bool leftCollisionBox;
        public bool rightCollisionBox;
        public bool topCollisionBox;
        public bool bottomCollisionBox;

        public bool isItCollidedBox;

        public bool leftCollisionStart;
        public bool rightCollisionStart;
        public bool topCollisionStart;
        public bool bottomCollisionStart;

        public bool isItCollidedStart;




        public void DrawTaskbar(Player cursor)
        {

            //drawing taskbar background
            Draw.FillColor = Color.Gray;
            Draw.LineColor = Color.LightGray;
            Draw.LineSize = 2;
            Draw.Rectangle(taskbarBGXPosition, taskbarBGYPosition, taskbatBGWidth, taskbarBGHeight);

            //drawing taskbar boxes/tabs. using a for loop to draw multiple.
            for (int taskbarBoxXPosition = 200; taskbarBoxXPosition < 400; taskbarBoxXPosition += 100)
            {
               

                //defining collision for each box/tab
                float topEdgeBox = taskbarBoxYPosition;
                float bottomEdgeBox = taskbarBoxYPosition + taskbarBoxHeight;
                float leftEdgeBox = taskbarBoxXPosition;
                float rightEdgeBox = taskbarBoxXPosition + taskbarBoxWidth;

                //if the hitbox and tabs collide, change tab colour
                leftCollisionBox = cursor.leftEdgeHitbox < rightEdgeBox;
                rightCollisionBox = cursor.rightEdgeHitbox > leftEdgeBox;
                topCollisionBox = cursor.topEdgeHitbox < bottomEdgeBox;
                bottomCollisionBox = cursor.bottomEdgeHitbox > topEdgeBox;

                isItCollidedBox = leftCollisionBox && rightCollisionBox && topCollisionBox && bottomCollisionBox;

                if (isItCollidedBox)
                {
                    Draw.FillColor = boxGreyHovering;
                }
                else
                {
                    Draw.FillColor = Color.LightGray;
                }

                Draw.LineColor = Color.DarkGray;
                Draw.LineSize = 2;
                Draw.Rectangle(taskbarBoxXPosition, taskbarBoxYPosition, taskbarBoxWidth, taskbarBoxHeight);
            }

            //drawing start box/tab & collision
            float topEdgeStart = taskbarStartYPosition;
            float bottomEdgeStart = taskbarStartYPosition + taskbarStartHeight;
            float leftEdgeStart = taskbarStartXPosition;
            float rightEdgeStart = taskbarStartXPosition + taskbarStartWidth;

            //if the hitbox and start tab collide, change tab colour
            leftCollisionStart = cursor.leftEdgeHitbox < rightEdgeStart;
            rightCollisionStart = cursor.rightEdgeHitbox > leftEdgeStart;
            topCollisionStart = cursor.topEdgeHitbox < bottomEdgeStart;
            bottomCollisionStart = cursor.bottomEdgeHitbox > topEdgeStart;

            isItCollidedStart = leftCollisionStart && rightCollisionStart && topCollisionStart && bottomCollisionStart;

            if (isItCollidedStart)
            {
                Draw.FillColor = startButtonGreenHovering;
            }
            else
            {
                Draw.FillColor = startButtonGreen;
            }

            Draw.LineColor = Color.DarkGray;
            Draw.LineSize = 2;
            Draw.Rectangle(taskbarStartXPosition, taskbarStartYPosition, taskbarStartWidth, taskbarStartHeight);

        }



        
        //setup & update functions
        public void Setup()
        {

        }

        public void Update(Player cursor)
        {
            DrawTaskbar(cursor);
        }
    }
}
