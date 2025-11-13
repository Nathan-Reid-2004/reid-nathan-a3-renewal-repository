// Include the namespaces (code libraries) you need below.
using Raylib_cs;
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        Color backgroundBlue = new Color("#018281");

        Game main;
        Player cursor;
        Tabs baseTabs;
        Email emailTab;
        Email emailTabRespawn;

        //I put the positions/properties here, in Game.CS, so that I do not have to reference them from emailTab
        //(since the variables no longer work once the instance of the class goes null)
        public float closeEmailXPosition = 470;
        public float closeEmailYPosition = 50;
        public float closeEmailWidth = 30;
        public float closeEmailHeight = 30;
        public bool isItCollidedCloseEmail;


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Renewal");
            Window.SetSize(800, 600);

            cursor = new Player();
            cursor.Setup();

            baseTabs = new Tabs();
            baseTabs.Setup();

            emailTab = new Email();
            emailTab.Setup();

            emailTabRespawn = new Email();

            main = new Game();
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(backgroundBlue);

            baseTabs.Update(cursor);

            //collision for the email tab
            float topEdgeCloseEmail = closeEmailYPosition;
            float bottomEdgeCloseEmail = closeEmailYPosition + closeEmailHeight;
            float leftEdgeCloseEmail = closeEmailXPosition;
            float rightEdgeCloseEmail = closeEmailXPosition + closeEmailWidth;
             
            bool leftCollisionCloseEmail = cursor.leftEdgeHitbox < rightEdgeCloseEmail;
            bool rightCollisionCloseEmail = cursor.rightEdgeHitbox > leftEdgeCloseEmail;
            bool topCollisionCloseEmail = cursor.topEdgeHitbox < bottomEdgeCloseEmail;
            bool bottomCollisionCloseEmail = cursor.bottomEdgeHitbox > topEdgeCloseEmail;

            bool isItCollidedCloseEmail = leftCollisionCloseEmail && rightCollisionCloseEmail && topCollisionCloseEmail && bottomCollisionCloseEmail && Input.IsMouseButtonPressed(MouseInput.Left);

            //using a for loop with completely random variables. the variables do not matter at all to my program- I put random values
            //in because I needed a for loop to have null work. once emailTab becomes null, so does everything else in the loop
            //as well (ie. the update function)
            for (float closeEmailTab = 0; closeEmailTab < 1; closeEmailTab += 0.1f)
            {

                //keeps the game running even after the object has become null
                if (emailTab == null)
                {
                    continue;
                }

                //despawns the email tab if the player hovers cursor over it and left clicks
                if (isItCollidedCloseEmail)
                {
                    emailTab = null;
                    continue;
                }

                emailTab.Update(baseTabs, main, cursor);

            }

            
            bool newTabSpawnEmail = baseTabs.isItCollidedBox && Input.IsMouseButtonDown(MouseInput.Left);

            if (newTabSpawnEmail)
            {
                emailTab = new Email();
            }

            bool newTabSpawnPasscode = baseTabs.isItCollidedStart && Input.IsMouseButtonDown(MouseInput.Left);

            if (newTabSpawnPasscode)
            {
                Console.WriteLine("Please enter admin password.");
                string playerPasswordInput = Console.ReadLine();

                string correctPassword = "3*0]U5";

                if (playerPasswordInput != correctPassword)
                {
                    Console.WriteLine("Incorrect password. Please re-click the START button and try again.");
                }
                else if (playerPasswordInput == correctPassword)
                {
                    Console.WriteLine("Correct password entered. Please return to your previous tab- you will see the engine management screen has appeared.");
                }

            }

            cursor.Update(baseTabs);
        }
    }
}
