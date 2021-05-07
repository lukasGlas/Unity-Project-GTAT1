using System;
using UnityEngine;

namespace Scripts
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private Visable visable;
        public Visable Visable => Visable;
        
        [SerializeField] public SpriteRenderer spriteR; //?

        public SpriteRenderer SpriteRenderer => spriteR; //?

        public bool highPos;
    }
}