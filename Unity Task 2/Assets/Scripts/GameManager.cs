using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for more info on the the OnEnable and Update methods
//see: https://docs.unity3d.com/Manual/ExecutionOrder.html

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameController gameCon;

        [SerializeField] private CharacterController charCon;

        [SerializeField] private ScreenHider screenH;

        [SerializeField] private float hitTreshold = 0.1f;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        //Unity runtime function called after enabling game component
        public void OnEnable()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            if (gameStarted)
            {
                StartCoroutine(ResetGame());
            }
        }
        
        //determines if the game has been started
        private bool gameStarted;


        private IEnumerator ResetGame()
        {
            gameStarted = false;
            Time.timeScale = 0.5f;
            gameCon.enabled = false;
            screenH.Show();
            yield return new WaitForSecondsRealtime(1f);
            Time.timeScale = 1f;
            gameCon.enabled = true;
        }

        private bool IntersectionHit(Entity ent)
        {
            if (ent == null)
            {
                return false;
            }

            return Intersection.Normalize(charCon, ent) > hitTreshold;
        }
    }
}


