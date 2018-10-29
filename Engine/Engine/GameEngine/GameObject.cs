/*
 * A base class for all Game Objects to inherit from. Will handle things like basic physics by default(with the option to turn these features off if 
 * the user decides they want to use their own physics)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.GameEngine
{
    public class GameObject
    {
        // We want delegates and events to allow us to use the Loops and Draws without having to override any events
        public delegate void _OnAwake(GameObject self); // When the object has first been created in the scene
        public delegate void _OnLoopBegin(GameObject self); // Triggers at the very start of the loop
        public delegate void _OnLoop(GameObject self); // Triggers every loop
        public delegate void _OnLoopEnd(GameObject self); // Triggers at the end of every loop
        public delegate void _OnDraw(GameObject self); // When the object is running the draw event
        public delegate void _OnDrawGui(GameObject self); // When the object is running the draw event overtop of all other drawing methods

        // The events that we can call in our main loop/draw methods
        public event _OnAwake OnAwake;
        public event _OnLoopBegin OnLoopBegin;
        public event _OnLoop OnLoop;
        public event _OnLoopEnd OnLoopEnd;
        public event _OnDraw OnDraw;
        public event _OnDrawGui OnDrawGui;

        // Internal private variables
        private bool _hasAwoken; // We want to keep track of whether the object has woken or not, and if so, then perform the awake event
        private GameObject _parentObject; // The object that will have this object in its instances list

        // Some variables
        private float x; // The X position
        private float y; // The Y position
        private float bboxLeft; // The Left position of the bounding box
        private float bboxRight; // The Right position of the bounding box
        private float bboxTop; // The Top position of the bounding box
        private float bboxBottom; // The Bottom position of the bounding box
        private bool visible; // If the object should be drawn or not
        private bool active; // If the object is active. If not, then do not perform ANY events

        private List<GameObject> instances = new List<GameObject>(); // Hold a list of the instances of this parent object

        public GameObject()
        {
            x = 0;
            y = 0;
            // The bounding box variables will generally be set from a sprite
            bboxLeft = 0;
            bboxRight = 0;
            bboxTop = 0;
            bboxBottom = 0;

            _hasAwoken = false;
            _parentObject = null;
        }

        /// <summary>
        /// Handle the awake event
        /// </summary>
        public void Awake()
        {
            if(OnAwake != null)
            {
                OnAwake(this);
            }

            _hasAwoken = true;
        }
        
        /// <summary>
        /// Handle the main loop event
        /// </summary>
        public void Loop()
        {
            // Perform the awake event
            if(!_hasAwoken)
            {
                Awake();
            }

            // The beginnng of the main loop
            if (OnLoopBegin != null)
            {
                OnLoopBegin(this);
            }

            // The main loop
            if (OnLoop != null)
            {
                OnLoop(this);
            }

            // The end of the main loop
            if (OnLoopEnd != null)
            {
                OnLoopEnd(this);
            }
        }

        /// <summary>
        /// Hande the draw event
        /// </summary>
        public void Draw()
        {
            if (visible)
            {
                if (OnDraw != null)
                {
                    OnDraw(this);
                }
            }
        }

        /// <summary>
        /// Hande the draw GUI event
        /// </summary>
        public void DrawGui()
        {
            if (OnDrawGui != null)
            {
                OnDrawGui(this);
            }
        }

        /// <summary>
        /// Create a new instance of this object and store it into the instances list, also return the object for direct access to it
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public GameObject InstanceCreate(float x, float y)
        {
            var ob = new GameObject();
            ob.x = x;
            ob.y = y;
            ob._parentObject = this;

            instances.Add(ob);

            return (ob);
        }

        /// <summary>
        /// Remove this instance from the parent game object and from memory
        /// </summary>
        public void InstanceDestroy()
        {
            if(_parentObject != null)
            {
                _parentObject.instances.Remove(this);
            }
        }

        /// <summary>
        /// Return the list of instances
        /// </summary>
        public List<GameObject> GetInstances
        {
            get { return (instances); }
        }
    }
}
