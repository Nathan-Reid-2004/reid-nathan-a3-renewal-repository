using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Email
    {
        //defining variables

        float sidebarXPosition = 100;
        float sidebarWidth = 100;
        float sidebarHeight = 40;

        public void DrawTabEmail(Tabs baseTabs, Game main, Player cursor)
        {

                //drawing tab background
                Draw.FillColor = Color.Gray;
                Draw.LineColor = Color.LightGray;
                Draw.LineSize = 2;
                Draw.Rectangle(100, 50, 400, 400);

                //drawing tab header
                Draw.FillColor = baseTabs.boxGreyHovering;
                Draw.Rectangle(100, 50, 400, 30);

                //drawing exit/close button, referencing positions/properties
                Draw.FillColor = Color.Red;
                Draw.LineColor = Color.LightGray;
                Draw.LineSize = 2;
                Draw.Rectangle(main.closeEmailXPosition, main.closeEmailYPosition, main.closeEmailWidth, main.closeEmailHeight);



            //drawing the sidebar buttons to access emails

            for (float sidebarYPosition = 90; sidebarYPosition < 400; sidebarYPosition += 50)
            {

                //drawing start box/tab & collision
                float topEdgeSidebar = sidebarYPosition;
                float bottomEdgeSidebar = sidebarYPosition + sidebarHeight;
                float leftEdgeSidebar = sidebarXPosition;
                float rightEdgeSidebar = sidebarXPosition + sidebarWidth;

                //if the hitbox and start tab collide, change tab colour
                bool leftCollisionSidebar = cursor.leftEdgeHitbox < rightEdgeSidebar;
                bool rightCollisionSidebar = cursor.rightEdgeHitbox > leftEdgeSidebar;
                bool topCollisionSidebar = cursor.topEdgeHitbox < bottomEdgeSidebar;
                bool bottomCollisionSidebar = cursor.bottomEdgeHitbox > topEdgeSidebar;

                bool isItCollidedSidebar = leftCollisionSidebar && rightCollisionSidebar && topCollisionSidebar && bottomCollisionSidebar;

                if (isItCollidedSidebar)
                {
                    Draw.FillColor = Color.White;
                }
                else
                {
                    Draw.FillColor = Color.LightGray;
                }
                Draw.LineColor = Color.LightGray;
                Draw.LineSize = 2;
                Draw.Rectangle(sidebarXPosition, sidebarYPosition, sidebarWidth, sidebarHeight);
            }


        }



        

        //setup & update functions
        public void Setup()
        {

        }

        public void Update(Tabs baseTabs, Game main, Player cursor)
        {
            
            DrawTabEmail(baseTabs, main, cursor);
        }
    }
}
