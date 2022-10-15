using System;
using Unity.VisualScripting;

namespace Upstream
{
    
    
    public class CircularBuffer
    {
        
        
        protected int     currentIndex, size;
        protected float   runningSum;
        protected float[] arr;
        
        
        public CircularBuffer (int _size)
        {
            size = _size;
            arr  = new float[size];
        }
        
        
        public void Push (float thing)
        {
            if (++currentIndex >= size) currentIndex = 0;
            
            runningSum += thing;
            runningSum -= arr[currentIndex];
            
            arr[currentIndex] = thing;
        }
       
        
        public float Get (int index) => arr[(currentIndex + index) % size];
        public float GetCurrent()    => arr[currentIndex];
        
        public float Average    { get => runningSum / size; }
        public float RunningSum { get => runningSum; }
        
    }
    

}