// Include the namespaces (code libraries) you need below.
using Raylib_cs;
using System;
using System.Numerics;

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

        Player cursor;
        Tabs baseTabs;


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
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(backgroundBlue);

            baseTabs.Update(cursor);

            cursor.Update(baseTabs);
            
        }
    }

}
