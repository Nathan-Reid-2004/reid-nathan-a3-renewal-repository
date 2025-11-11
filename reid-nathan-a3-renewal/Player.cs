using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {

        //defining variables

        public float topEdgeHitbox = 0.0f;
        public float bottomEdgeHitbox = 0.0f;
        public float leftEdgeHitbox = 0.0f;
        public float rightEdgeHitbox = 0.0f;

        public void DrawPlayerCursor(float x, float y, Tabs baseTabs)
        {

            //drawing the hitbox & defining edges
            //temporarily making colour red instead of clear so I can see the hitbox

            float hitboxX = x - 15;
            float hitboxY = y - 50;
            float hitboxWidth = 30;
            float hitboxHeight = 30;

            Draw.FillColor = Color.Clear;
            Draw.LineColor = Color.Clear;
            Draw.Rectangle(hitboxX, hitboxY, hitboxWidth, hitboxHeight);

            topEdgeHitbox = hitboxY;
            bottomEdgeHitbox = hitboxY + hitboxHeight;
            leftEdgeHitbox = hitboxX;
            rightEdgeHitbox = hitboxX + hitboxWidth;


            //drawing the cursor line/stem
            Draw.LineSize = 10;
            Draw.LineColor = Color.White;
            Draw.Line(x, y, x, y + 30);

            //drawing the cursor triangle
            Draw.FillColor = Color.White;
            Draw.Triangle(x, y - 30, x + 10, y, x - 10, y);

        }

        //setup & update functions
        public void Setup()
        {

        }

        public void Update(Tabs baseTabs)
        {
            DrawPlayerCursor(Input.GetMouseX(), Input.GetMouseY(), baseTabs);
        }
    }
}
