/*
 * The Scene class will keep track of the Game Objects contained in it, 
 * with cameras/views, dimentions
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public class Scene
    {
        private List<GameObject> objects = new List<GameObject>(); // Hold a list of all the objects in the scene

        // Variables
        private float width; // The width of the scene in pixels
        private float height; // The height of the scene in pixels
        private float viewX; // The X position of the main view
        private float viewY; // The Y position of the main view
        private float viewW; // The width of the main view
        private float viewH; // The height of the main view

        /// <summary>
        /// Constructor for the scene
        /// </summary>
        public Scene()
        {

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
