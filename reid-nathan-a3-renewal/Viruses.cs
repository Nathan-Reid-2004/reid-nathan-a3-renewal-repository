using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Viruses
    {
        //defining variables

        Vector2 roamingVirusesStartingPoint = new Vector2(700, 100);
        Vector2 roamingVirusesSize = new Vector2(50);

        public bool leftCollisionRoaming;
        public bool rightCollisionRoaming;
        public bool topCollisionRoaming;
        public bool bottomCollisionRoaming;

        public bool isItCollidedRoaming;

        public bool leftCollisionRoamingCursor;
        public bool rightCollisionRoamingCursor;
        public bool topCollisionRoamingCursor;
        public bool bottomCollisionRoamingCursor;

        public bool isItCollidedRoamingCursor;

        public bool leftCollisionSpeedUp;
        public bool rightCollisionSpeedUp;
        public bool topCollisionSpeedUp;
        public bool bottomCollisionSpeedUp;

        public bool isItCollidedSpeedUp;

        //defining the timer variable
        public float timer;

        public void RoamingVirusesMovement(Player cursor, Game main)
        {
            //defining virus movement towards the center of the email tab
            Vector2 roamingVirusesDirection = main.emailCenter - roamingVirusesStartingPoint;
            Vector2 roamingVirusesDirectionNormalized = Vector2.Normalize(roamingVirusesDirection);
            float roamingVirusesSpeed = 100;

            //defining virus movement when colliding with the mouse cursor
            if (isItCollidedRoamingCursor)
            {

                roamingVirusesDirectionNormalized -= roamingVirusesDirection;
            }

            //if cursor is inside of email tab, the speed of the virus increases
            leftCollisionSpeedUp = cursor.leftEdgeHitbox < main.rightEdgeEmailTabBackground;
            rightCollisionSpeedUp = cursor.rightEdgeHitbox > main.leftEdgeEmailTabBackground;
            topCollisionSpeedUp = cursor.topEdgeHitbox < main.bottomEdgeEmailTabBackground;
            bottomCollisionSpeedUp = cursor.bottomEdgeHitbox > main.topEdgeEmailTabBackground;

            isItCollidedSpeedUp = leftCollisionSpeedUp && rightCollisionSpeedUp && topCollisionSpeedUp && bottomCollisionSpeedUp;

            //drawing the timer. depending on the value of the timer, the value of the speed increase will get higher.
            float timer = Time.SecondsElapsed;

            Text.Draw($"{timer:F2}", 20, 20);

            if (isItCollidedSpeedUp)
            {
                roamingVirusesSpeed *= 1.2f;
            }

            if (isItCollidedSpeedUp && Time.SecondsElapsed >= 20)
            {
                roamingVirusesSpeed *= 1.5f;
            }

            if (isItCollidedSpeedUp && Time.SecondsElapsed >= 40)
            {
                roamingVirusesSpeed *= 1.8f;
            }

            if (isItCollidedSpeedUp && Time.SecondsElapsed >= 60)
            {
                roamingVirusesSpeed *= 2.1f;
            }

            roamingVirusesStartingPoint += roamingVirusesDirectionNormalized * roamingVirusesSpeed * Time.DeltaTime;
        }

        public void DrawRoamingViruses(Player cursor, Email emailTab)
        {

            //drawing viruses
            Draw.FillColor = Color.Yellow;
            Draw.LineColor = Color.Green;
            Draw.LineSize = 2;
            Draw.Rectangle(roamingVirusesStartingPoint, roamingVirusesSize);


            //if the virus collides with the email tab, the game over screen will display. This will only happen
            //if the email tab is NOT null.
            if (isItCollidedRoaming && emailTab != null)
            {
                Draw.FillColor = Color.Blue;
                Draw.Rectangle(0, 0, 800, 600);

                Text.Draw("Exodus OS 9.0 ran into an issue and has to restart.", 50, 300);
                Text.Size = 200;
                Text.Color = Color.White;

                //smaller window size prevents players from reaching the viruses and continuing to
                //play after a game over,
                Window.SetSize(500, 500);
            }

        }

        public void RoamingVirusesCollision(Game main, Player cursor)
        {
            //defining collision for the viruses
            float topEdgeRoaming = roamingVirusesStartingPoint.Y;
            float bottomEdgeRoaming = roamingVirusesStartingPoint.Y + roamingVirusesSize.Y;
            float leftEdgeRoaming = roamingVirusesStartingPoint.X;
            float rightEdgeRoaming = roamingVirusesStartingPoint.X + roamingVirusesSize.X;

            //if the hitbox collides with the email tab, display game over screen
            leftCollisionRoaming = leftEdgeRoaming < main.rightEdgeEmailTabBackground;
            rightCollisionRoaming = rightEdgeRoaming > main.leftEdgeEmailTabBackground;
            topCollisionRoaming = bottomEdgeRoaming < main.bottomEdgeEmailTabBackground;
            bottomCollisionRoaming = topEdgeRoaming > main.topEdgeEmailTabBackground;

            isItCollidedRoaming = leftCollisionRoaming && rightCollisionRoaming && topCollisionRoaming && bottomCollisionRoaming;

            //defining collision between the mouse cursor and the viruses
            leftCollisionRoamingCursor = cursor.leftEdgeHitbox < rightEdgeRoaming;
            rightCollisionRoamingCursor = cursor.rightEdgeHitbox > leftEdgeRoaming;
            topCollisionRoamingCursor = cursor.topEdgeHitbox < bottomEdgeRoaming;
            bottomCollisionRoamingCursor = cursor.bottomEdgeHitbox > topEdgeRoaming;

            isItCollidedRoamingCursor = leftCollisionRoamingCursor && rightCollisionRoamingCursor && topCollisionRoamingCursor && bottomCollisionRoamingCursor;
        }


        //setup & update functions
        public void Setup()
        {

        }

        public void Update(Player cursor, Game main, Email emailTab)
        {
            RoamingVirusesMovement(cursor, main);
            main.EmailTabBackgroundCollision();
            RoamingVirusesCollision(main, cursor);
            DrawRoamingViruses(cursor, emailTab);

        }
    }
}
