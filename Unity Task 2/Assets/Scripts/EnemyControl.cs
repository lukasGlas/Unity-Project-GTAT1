using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Code: https://gamedevacademy.org/how-to-build-a-complete-2d-platformer-in-unity/
        // This function is called every time another collider overlaps the trigger collider
        IEnumerator OnTriggerEnter2D(Collider2D other)
        {
            // Checking if the overlapped collider is an enemy
            if (other.CompareTag("Enemy"))
            {
                // This scene HAS TO BE IN THE BUILD SETTINGS!!!
                SceneManager.LoadScene("SampleScene");
                

            }
        }
}