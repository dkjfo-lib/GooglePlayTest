using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEx
{
    public static class MyRandom
    {
        public static float Range(Vector2 vector)
            => Random.Range(vector.x, vector.y);
        public static int Range(Vector2Int vector)
            => Random.Range(vector.x, vector.y);

        public static float[] Range(Vector2[] vectors)
            => vectors.Select(s => Range(s)).ToArray();
        public static int[] Range(Vector2Int[] vectors)
            => vectors.Select(s => Range(s)).ToArray();
    }
}
