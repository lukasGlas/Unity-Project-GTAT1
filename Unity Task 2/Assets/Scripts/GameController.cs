using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class GameController : MonoBehaviour
    {
        public IEnumerable<Entity> entities => ents;

        public bool gameStarted;

        [SerializeField] private Vector2 minMaxGameSpeed;
        
        [SerializeField] private Vector2Int minMaxGridHeight;
        
        [SerializeField] private float spawnFirstEntLocation;

        [SerializeField] private Entity entPrefab;


        private Vector2 gridSize;

        private float currentGameSpeed;

        private Queue<Entity> ents;

        private float startTime;

        public void StartGame()
        {
            gameStarted = true;
            startTime = Time.time;
        }

        public void Awake()
        {
            gridSize = entPrefab.GetComponentInChildren<SpriteRenderer>().sprite.bounds.size;
            ents = new Queue<Entity>();

            for (var i = 0; i < 30; i++)
            {
                AddEnt();
            }
        }

        private void OnDisable()
        {
            gameStarted = false;
        }

        private void Update()
        {
            if (!gameStarted)
            {
                return;
            }

            var gameStartTime = (Time.time - startTime);
            var delta = minMaxGameSpeed.y - minMaxGameSpeed.x;
            currentGameSpeed = minMaxGameSpeed.x + delta * Mathf.Clamp01(gameStartTime / 1000);
            Time.timeScale = currentGameSpeed;
        }

        private void AddEnt()
        {
            var newEnt = Instantiate(entPrefab, transform);
            var entPosition = newEnt.transform.localPosition;
            entPosition.x = ents.Count > 0 ? ents.Last().transform.localPosition.x + gridSize.x : spawnFirstEntLocation;
            newEnt.highPos = IsHighTile();
            entPosition.y += newEnt.highPos ? minMaxGridHeight.y * gridSize.y : minMaxGridHeight.x * gridSize.y;
            newEnt.transform.localPosition = entPosition;
            newEnt.Visable.vis += () => RemoveEnt(newEnt);
            ents.Enqueue(newEnt);
        }

        private bool IsHighTile()
        {
            if (!gameStarted)
            {
                return false;
            }

            var results = ents.Skip(ents.Count - 4).Select(x => x.highPos ? 1 : 0).Select((x, y) => Mathf.Min(x, y));

            if (results.Any(x => x != 0))
            {
                return false;
            }
            
            var delta = minMaxGameSpeed.y - minMaxGameSpeed.x;
            var difficulty = 0.25f + (currentGameSpeed - minMaxGameSpeed.x) / (delta) * 0.75f;
            return Random.value < difficulty;
        }

        private void RemoveEnt(Entity ent)
        {
            Destroy(ent.gameObject);
            ents.Dequeue();
            AddEnt();
        }
    }
}