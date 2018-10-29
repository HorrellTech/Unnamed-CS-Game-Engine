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

        /// <summary>
        /// Constructor for the scene
        /// </summary>
        public Scene()
        {

        }
    }
}
