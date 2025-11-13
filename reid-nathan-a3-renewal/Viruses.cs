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
        Vector2 roamingVirusesVelocity;

        public bool leftCollisionRoaming;
        public bool rightCollisionRoaming;
        public bool topCollisionRoaming;
        public bool bottomCollisionRoaming;

        public bool isItCollidedRoaming;

        public void RoamingVirusesMovement(Player cursor, Game main)
        {

            Vector2 roamingVirusesDirection = main.emailCenter - roamingVirusesStartingPoint;
            Vector2 roamingVirusesDirectionNormalized = Vector2.Normalize(roamingVirusesDirection);

            float roamingVirusesSpeed = 100;
            roamingVirusesStartingPoint += roamingVirusesDirectionNormalized * roamingVirusesSpeed * Time.DeltaTime;
        }

        public void DrawRoamingViruses(Player cursor)
        {

            //drawing viruses
            Draw.FillColor = Color.Yellow;
            Draw.LineColor = Color.Green;
            Draw.LineSize = 2;
            Draw.Rectangle(roamingVirusesStartingPoint, roamingVirusesSize);

            if (isItCollidedRoaming)
            {
                Draw.FillColor = Color.Blue;
                Draw.Rectangle(0, 0, 800, 600);

                Text.Draw("Exodus OS 9.0 ran into an issue and has to restart.", 190, 300);
                Text.Size = 900;
                Text.Color = Color.White;
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
        }


        //setup & update functions
        public void Setup()
        {

        }

        public void Update(Player cursor, Game main)
        {
            RoamingVirusesMovement(cursor, main);
            main.EmailTabBackgroundCollision();
            RoamingVirusesCollision(main, cursor);
            DrawRoamingViruses(cursor);

        }
    }
}
