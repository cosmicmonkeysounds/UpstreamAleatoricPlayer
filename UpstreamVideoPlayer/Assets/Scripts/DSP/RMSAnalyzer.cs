using System;
using UnityEngine;
using UnityEngine.UI;
using Upstream;

namespace Upstream
{
    
    /// <summary>
    /// A class that analyzes the audio incoming and spits out the current RMS value, averaged to the response time
    /// of your choice.
    /// </summary>
    [RequireComponent (typeof (AudioSource))]
    public class RMSAnalyzer : MonoBehaviour, IAudioAnalyzer
    {
        
        [SerializeField, Range (1, 250)] private int averagerLength = 50;
        private FloatAverager averager;
        
        
        
        public float Value { get => averager.Average(); }
        
        
        private void OnValidate()
        {
            averager = new FloatAverager (averagerLength);
        }
        

        /// <summary>
        /// Dead simple, really; iterate through each sample in the buffer and add each square to a sum;
        /// Multiply the sum by n, take the square of that value, and finally add it to averager.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="channels"></param>
        private void OnAudioFilterRead (float[] data, int channels) => averager.Add (data.GetRMS());
        
        
        
        
        private void Update()
        {
            //Debug.Log ($"Current RMS vallue is: {averager.Average()}");
        }
        
    }
}