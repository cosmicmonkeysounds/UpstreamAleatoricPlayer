using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Upstream
{
    /// <summary>
    /// Simple class that modifies the gain of whatever is upstream in the DSP chain.
    /// </summary>
    [RequireComponent (typeof (AudioSource))]
    public class GainDSP : MonoBehaviour, IAudioProcessor
    {
        [SerializeField, Range (0.0f, 2.0f)] private float gain = 1.0f;

        private void OnAudioFilterRead (float[] data, int channels)
        { 
            int totalSamples = data.Length / channels;
        
            for (int sampleIndex = 0; sampleIndex < totalSamples; sampleIndex += channels)
            { 
                for (int channelIndex = 0; channelIndex < channels; ++channelIndex)
                {
                    data[sampleIndex * channels + channelIndex] *= gain; 
                }
            }
        }
    }
    
}