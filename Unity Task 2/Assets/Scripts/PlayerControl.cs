using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        //input for game control from player-chosen action
        public Action playerAction;

        //decides if player input is accepted
        //not needed as of right now as only instance of stopping is ending the game, which disables the whole class anyways
        public bool playerActing;
        
        //handles character position in level
        public Transform playerPos; 
        
        //handles depiction of the player character's sprite
        public SpriteRenderer playerSprite;
        
        //handles physics of the player character's body
        public Rigidbody2D body;
        
        public float speed;
        private float move_x;
        
        public void OnEnable()
        {
            playerActing = true;
        }
        
        public void OnDisable()
        {
            playerActing = false;
        }

        private void Update()
        {
            //if the player's not supposed to be acting, don't accept his input
            if (playerActing!)
            {

            }
            if (playerActing)
            {
                //determines player movement on x axis based on adequate key input (e.g. A, D)
                move_x = Input.GetAxisRaw("Horizontal");
                Vector3 characterScale = transform.localScale;

                if (Input.GetAxis("Horizontal") < 0)
                {
                    characterScale.x = -5;
                }

                if (Input.GetAxis("Horizontal") > 0)
                {
                    characterScale.x = 5;
                }

                transform.localScale = characterScale;
                
                if (Input.GetKey(KeyCode.A))
                {
                    Debug.Log("Player moved left.");
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Debug.Log("Player moved right.");
                }
                //StartCoroutine(GameTest());
            }
        }

        private void FixedUpdate()
        {
            Vector2 movement = new Vector2(move_x * speed, body.velocity.y);
            body.velocity = movement;
        }

        private IEnumerator GameTest()
        {
            yield return null;
        }
    }
}