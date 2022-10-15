using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Upstream
{
    
    /// <summary>
    /// An AudioEvent behaviour that implements the naïve, simple algorithm outlined at http://archive.gamedev.net/archive/reference/programming/features/beatdetection/index.html
    /// </summary>
    
    [RequireComponent (typeof (AudioSource))]
    public class DumbBeatDetection : MonoBehaviour, IAudioEvent
    {
        
        
        public event Action AudioEvent;
        
        
        
        [SerializeField, Range (0.0001f, 0.01f)] private float detectionWindowTime = 1.0f; 
        [SerializeField] Text text;
        
        
        
        private int bufferLength, numOfBuffers;
        private float currentRMS;
        private CircularBuffer averager;

        
        
        private void Awake()
        {
            AudioSettings.GetDSPBufferSize (out bufferLength, out numOfBuffers);
            Debug.Log ($"Dsp length is {bufferLength}, buffer length in seconds is: {(float)bufferLength / (float)AudioSettings.outputSampleRate}");
        }
        
        

        private void OnValidate()
        {
            averager = new CircularBuffer (Mathf.RoundToInt (detectionWindowTime * AudioSettings.outputSampleRate));
        }


        private void OnAudioFilterRead (float[] data, int channels)
        {
            currentRMS = data.GetRMS();
            averager.Push (currentRMS);
        }
        
        private void Update()
        { 
            text.text = $"Current instant RMS: {currentRMS}, integrated: {averager.Average}";
            
            if (currentRMS >= averager.Average) text.color = Color.green;
            else text.color = Color.black;
        }
    }
}