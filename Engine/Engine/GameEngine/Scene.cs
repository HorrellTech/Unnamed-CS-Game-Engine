/*
 * The Scene class will keep track of the Game Objects contained in it, 
 * with cameras/views, dimentions
 */
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public class Scene
    {
        private const int VIEWCOUNT = 10;

        private List<GameObject> objects = new List<GameObject>(); // Hold a list of all the objects in the scene

        // Variables
        private float width; // The width of the scene in pixels
        private float height; // The height of the scene in pixels
        private View[] views; // Store the views in the current scene

        /// <summary>
        /// Constructor for the scene, set the width and height of the scene
        /// </summary>
        public Scene(float width, float height, float viewCenterX, float viewCenterY, float viewWidth, float viewHeight)
        {
            views = new View[VIEWCOUNT]; // Initialize the views

            this.width = width;
            this.height = height;

            views[0] = new View(new Vector2f(viewCenterX, viewCenterY), new Vector2f(viewWidth, viewHeight)); // Create the first view

            for(var i = 1; i < VIEWCOUNT; i++)
            {
                views[i] = new View();
            }
        }

        /// <summary>
        /// Main loop for the scene. Will handle the logic and drawing of the objects instances
        /// </summary>
        public void Loop()
        {
            // OBJECT UPDATES
            if(objects.Count > 0)
            {
                // Itterate throught each object
                foreach(var ob in objects)
                {
                    if (ob.GetInstances.Count > 0)
                    {
                        // Loop through the object instances
                        foreach (var inst in ob.GetInstances)
                        {
                            if(inst.Active) // Make sure the instance is active
                            {
                                inst.Loop(); // Perform the event
                            }
                        }
                    }
                }
            }

            // OBJECT DRAWING
            if (objects.Count > 0)
            {
                // Itterate throught each object
                foreach (var ob in objects)
                {
                    if (ob.GetInstances.Count > 0)
                    {
                        // Loop through the object instances
                        foreach (var inst in ob.GetInstances)
                        {
                            if (inst.Active) // Make sure the instance is active
                            {
                                inst.Draw(); // Perform the event
                            }
                        }
                    }
                }
            }

            // OBJECT DRAWING GUI
            if (objects.Count > 0)
            {
                // Itterate throught each object
                foreach (var ob in objects)
                {
                    if (ob.GetInstances.Count > 0)
                    {
                        // Loop through the object instances
                        foreach (var inst in ob.GetInstances)
                        {
                            if (inst.Active) // Make sure the instance is active
                            {
                                inst.DrawGui(); // Perform the event
                            }
                        }
                    }
                }
            }
        }
    }
}
