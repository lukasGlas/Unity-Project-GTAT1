using System;
using UnityEngine;

//for more info on the OnBecameInvisible & -Visible
//see: https://docs.unity3d.com/Manual/ExecutionOrder.html

namespace Scripts
{
    public class Visable : MonoBehaviour
    {
        public Action vis;
        public Action invis;
       
        //unity runtime function
        //called when GameObject with a renderer is rendered
        public void OnBecameVisible()
        {
            vis?.Invoke();
        }

        //unity runtime function
        //called when GameObject with a renderer is culled
        public void OnBecameInvisible()
        {
            invis?.Invoke();
        }

        
    }
}