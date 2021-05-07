using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class CharacterController : MonoBehaviour
    {
        public Transform Transform => character;
        public SpriteRenderer CharacterSprite => charSprite;

       [SerializeField] public Transform character;

       [SerializeField] private SpriteRenderer charSprite;

        private void Update()
        {
            StartCoroutine(GameTest());
        }

        private IEnumerator GameTest()
        {
            yield return null;
        }
    }
}