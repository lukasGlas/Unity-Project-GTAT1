using UnityEngine;
using UnityEngine.WSA;
using static Unity.Mathematics.math;

namespace Scripts
{
    public static class Intersection
    {
        private static Bounds RetrieveBounds(Entity ent)
        {
            return ent.spriteR.bounds;
        }

        private static Bounds RetrieveBounds(CharacterController character)
        {
            var characterExtents = character.CharacterSprite.bounds.extents;
            return new Bounds(character.Transform.position, characterExtents);
        }

        public static float Normalize(CharacterController character, Entity ent)
        {
            var entBounds = RetrieveBounds(ent);
            var characterBounds = RetrieveBounds(character);

            var xOverlap = max(0,
                min(entBounds.max.x, characterBounds.max.x) - max(entBounds.min.x, characterBounds.min.x));
            var yOverlap = max(0,
                min(entBounds.max.y, characterBounds.max.y) - max(entBounds.min.y, characterBounds.min.y));

            var overlapArea = xOverlap * yOverlap;

            var characterArea = characterBounds.size.x * characterBounds.size.y;

            return overlapArea / characterArea;
        }
    }
}