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

        

        public void DrawTabEmail(Tabs baseTabs, Game main, Player cursor)
        {

                //drawing tab background, referencing positions/properties
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



            //drawing the sidebar buttons to access emails, using a for loop to draw multiple
            for (float sidebarYPosition = 90; sidebarYPosition < 400; sidebarYPosition += 50)
            {

                //drawing start box/tab & collision
                float topEdgeSidebar = sidebarYPosition;
                float bottomEdgeSidebar = sidebarYPosition + sidebarHeight;
                float leftEdgeSidebar = sidebarXPosition;
                float rightEdgeSidebar = sidebarXPosition + sidebarWidth;

                //if the hitbox and button(s) collide, change tab colour
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
                    string[] emailsBody = ["Hello Guest, \n\nWelcome! We at Exodus Inc\nsincerely hope you enjoy your\nstay in one of our\nexclusive privacy pods(please note\nfor future reference that you\nare renting Pod 3). \n\nWe recommend that if you\nare feeling particularly stressed,\nyou book for at least 3 weeks. \n\nIf your rental period does\nrun out, from any point within our\nprivate sector of space,\nit will take roughly 3 hours\nto return to civilization.\n\nThank you for choosing Exodus.", "Hey ******,\n\nI hope you are doing alright.\n*** have been out in that\npod for awhile now.\nMom and I are worried\nabout ***.Please come home.\n\nLiving in that thing forever\nis not sustainable, as much as\nExodus makes *** think it is.\n\nIf *** are open to it,\n*** can have a fresh start.\nmom and I will pay\nfor everything. All *** have\nto do is stay.\n\nTalk soon bud.", "WARNING - URGENT.\n\nNutrient Capsule almost empty!\nOnce levels reach null,\nemergency feeding tubes will\nactivate. Please return to\nnearest nutrient cabinet ASAP.\n\nIf emergency supply reaches null,\npod will automatically return\nto Exodus Station 0].\n\nThis is a revered medical\nfacility. You will undergo\na full nourishment cycle and\nthorough checkup. Please stay alert\nto your levels.", "Hello Member #LUUP\n\nThank you for upgrading to\nour premium entertainment pack!\nWe value your loyalty.\nAs a gesture of our gratitude:\n\nPlease accept a 1 month\nextension to your rental!\nWe hope you enjoy.\n\nWe are excited to continUe\nproviding you with our best\nentertainment. The comfort zone\nhas never been so comfortable!", "WARNING - URGENT.\n\nExodus OS has detected\na problem within your pods\nengineering systems.\n\nWe recommend navigating to the\ngreen admin button to manually\ncontrol fuel flow to the engines.\n\nIn the event your comms\nsystem is damaged, be careful\nof aural nodes invading Exodus O5.\nWe should arrive soon to assist you."];

                for (float email1Hitbox = 125; email1Hitbox < 165; email1Hitbox++)
                {

                    if (Input.GetMouseY() == email1Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[0], 205, 90);
                    }
                }

                for (float email2Hitbox = 175; email2Hitbox < 215; email2Hitbox++)
                {

                    if (Input.GetMouseY() == email2Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[1], 205, 90);
                    }
                }

                for (float email3Hitbox = 225; email3Hitbox < 265; email3Hitbox++)
                {

                    if (Input.GetMouseY() == email3Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[2], 205, 90);
                    }
                }

                for (float email4Hitbox = 275; email4Hitbox < 315; email4Hitbox++)
                {

                    if (Input.GetMouseY() == email4Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[3], 205, 90);
                    }
                }

                for (float email5Hitbox = 325; email5Hitbox < 365; email5Hitbox++)
                {

                    if (Input.GetMouseY() == email5Hitbox && isItCollidedSidebar)
                    {
                        Draw.FillColor = Color.White;
                        Text.Draw(emailsBody[4], 205, 90);
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
