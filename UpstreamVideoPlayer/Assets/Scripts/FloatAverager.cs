using System;
using System.Collections.Generic;
using System.Linq;

namespace Upstream
{
    public class FloatAverager
    {
        [NonSerialized] public Queue<float> queue;

        public FloatAverager (int length) => queue = new Queue<float> (new float[length]);

        public float Add (float thing)
        {
            queue.Enqueue (thing);
            return queue.Dequeue();
        }

        public float Average()
        {
            return queue.Average();
        }

        public float AddAndGetAverage (float thing)
        {
            Add (thing);
            return queue.Average();
        }

        public void SetLength (int length) => queue = new Queue<float> (new float[length]);
    } 
}
