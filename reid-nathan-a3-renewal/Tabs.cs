using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Tabs
    {
        //defining variables

        Color startButtonGreen = new Color("78AE43");

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



        public void DrawTaskbar(Player cursor)
        {

            //drawing taskbar background
            Draw.FillColor = Color.Gray;
            Draw.LineColor = Color.LightGray;
            Draw.LineSize = 2;
            Draw.Rectangle(taskbarBGXPosition, taskbarBGYPosition, taskbatBGWidth, taskbarBGHeight);

            //drawing taskbar boxes/tabs
            for (int taskbarBoxXPosition = 200; taskbarBoxXPosition < 750; taskbarBoxXPosition += 100)
            {
                Draw.FillColor = Color.LightGray;
                Draw.LineColor = Color.DarkGray;
                Draw.LineSize = 2;
                Draw.Rectangle(taskbarBoxXPosition, taskbarBoxYPosition, taskbarBoxWidth, taskbarBoxHeight);

                //defining collision for each box/tab
                float topEdgeBox = taskbarBoxYPosition;
                float bottomEdgeBox = taskbarBoxYPosition + taskbarBoxHeight;
                float leftEdgeBox = taskbarBoxXPosition;
                float rightEdgeBox = taskbarBoxXPosition + taskbarBoxWidth;

                //PUT IF STATEMENT HERE FOR COLLISION (WILL CHANGE COLOUR)!!

                bool leftCollision = cursor.leftEdgeHitbox < rightEdgeBox;
                bool rightCollision = cursor.rightEdgeHitbox > leftEdgeBox;
                bool topCollision = cursor.topEdgeHitbox < bottomEdgeBox;
                bool bottomCollision = cursor.bottomEdgeHitbox > topEdgeBox;

                bool isItCollided = leftCollision && rightCollision && topCollision && bottomCollision;


            }

            //drawing start box/tab
            Draw.FillColor = startButtonGreen;
            Draw.LineColor = Color.DarkGray;
            Draw.LineSize = 2;
            Draw.Rectangle(taskbarStartXPosition, taskbarStartYPosition, taskbarStartWidth, taskbarStartHeight);

            float topEdgeStart = taskbarStartYPosition;
            float bottomEdgeStart = taskbarStartYPosition + taskbarStartHeight;
            float leftEdgeStart = taskbarStartXPosition;
            float rightEdgeStart = taskbarStartXPosition + taskbarStartWidth;

            if (cursor.rightEdgeHitbox > leftEdgeStart && cursor.leftEdgeHitbox < rightEdgeStart
                && cursor.bottomEdgeHitbox > topEdgeStart && cursor.topEdgeHitbox < bottomEdgeStart)
            {
                Draw.FillColor = Color.DarkGray;
            }

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
