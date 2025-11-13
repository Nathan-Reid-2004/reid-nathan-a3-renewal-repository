using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
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

        //defining email tab Vector2s
        Vector2 email5Top = new Vector2(110, 295);

        Vector2 email4Top = new Vector2(110, 245);

        Vector2 email3Top = new Vector2(110, 195);

        Vector2 email2Top = new Vector2(110, 145);

        Vector2 email1Top = new Vector2(110, 95);

        //defining center-point of email tab

        

        public void DrawTabEmail(Tabs baseTabs, Game main, Player cursor)
        {

                //drawing tab background
                Draw.FillColor = Color.Gray;
                Draw.LineColor = Color.LightGray;
                Draw.LineSize = 2;
                Draw.Rectangle(main.emailTabBackgroundXPosition, main.emailTabBackgroundYPosition, main.emailTabBackgroundWidth, main.emailTabBackgroundHeight);

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

                //To access each individual email, I created a string array holding all email text. I then used for loops to
                //detect if the mouse cursor is within the specific Y coordinate range to access the email.
                    string[] emailsBody = ["Hello this is a test", "Bye bye this is a test", "Yet another test", "Testy Testy", "Testing 123"];

                for (float email1Hitbox = 125; email1Hitbox < 165; email1Hitbox++)
                {

                    if (Input.GetMouseY() == email1Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[0], 200, 200);
                    }
                }

                for (float email2Hitbox = 175; email2Hitbox < 215; email2Hitbox++)
                {

                    if (Input.GetMouseY() == email2Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[1], 200, 200);
                    }
                }

                for (float email3Hitbox = 225; email3Hitbox < 265; email3Hitbox++)
                {

                    if (Input.GetMouseY() == email3Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[2], 200, 200);
                    }
                }

                for (float email4Hitbox = 275; email4Hitbox < 315; email4Hitbox++)
                {

                    if (Input.GetMouseY() == email4Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[3], 200, 200);
                    }
                }

                for (float email5Hitbox = 325; email5Hitbox < 365; email5Hitbox++)
                {

                    if (Input.GetMouseY() == email5Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[4], 200, 200);
                    }
                }

                //email titles
                Draw.LineColor = Color.LightGray;
                Draw.LineSize = 2;
                Draw.Rectangle(sidebarXPosition, sidebarYPosition, sidebarWidth, sidebarHeight);

                Text.Size = 15;
                Text.Draw("Pod Status \nUpdate", email5Top);

                Text.Size = 15;
                Text.Draw("Rental \nPeriod", email4Top);

                Text.Size = 15;
                Text.Draw("Nutrients \nWarning", email3Top);

                Text.Size = 15;
                Text.Draw("Worried...", email2Top);

                Text.Size = 15;
                Text.Draw("Welcome!", email1Top);
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
