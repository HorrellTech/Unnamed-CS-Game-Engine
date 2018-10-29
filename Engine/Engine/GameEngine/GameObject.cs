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
        public delegate void OnAwake(GameObject self); // When the object has first been created in the scene
        public delegate void OnLoopBegin(GameObject self); // Triggers at the very start of the loop
        public delegate void OnLoop(GameObject self); // Triggers every loop
        public delegate void OnLoopEnd(GameObject self); // Triggers at the end of every loop
        public delegate void OnDraw(GameObject self); // When the object is running the draw event

        // The events that we can call in our main loop/draw methods
        public event OnAwake Awake;
        public event OnLoopBegin LoopBegin;
        public event OnLoop Loop;
        public event OnLoopEnd LoopEnd;
        public event OnDraw Draw;

        // Some variables
        private float x; // The X position
        private float y; // The Y position
        private float bboxLeft; // The Left position of the bounding box
        private float bboxRight; // The Right position of the bounding box
        private float bboxTop; // The Top position of the bounding box
        private float bboxBottom; // The Bottom position of the bounding box

        public GameObject()
        {

        }
    }
}
