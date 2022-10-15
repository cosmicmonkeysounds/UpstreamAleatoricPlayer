using System.Collections.Generic;
using UnityEngine;

namespace Upstream
{
    public static class Utils
    {
        public static bool IsEven (this int num) => num % 2 == 0;
        
        public static float GetRMS (this float[] data)
        {
            float square = 0.0f;
            
            foreach (float sample in data)
                square += sample * sample;

            return Mathf.Sqrt (square / data.Length);
        }
        
        public static float GetRMS (this List<float> data)
        {
            float square = 0.0f, mean = 1.0f / data.Count;
            
            foreach (float sample in data)
                square += sample * sample;
            
            return Mathf.Sqrt (mean * square);
        }
        
    }
}