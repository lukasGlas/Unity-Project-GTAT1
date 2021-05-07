using UnityEditor.U2D;
using UnityEngine;

namespace Scripts
{
    public class ScreenHider : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvG;

        private float targetVis;

        private float lastHide;

        private void Awake()
        {
            targetVis = 1f;
        }

        private void Update()
        {
            if (Time.time - lastHide > 30f)
            {
                Show();
            }
        }

        public void Show()
        {
            targetVis = 1f;
        }

        private void Hide()
        {
            targetVis = 0f;
            lastHide = Time.time;
        }
        
    }
}