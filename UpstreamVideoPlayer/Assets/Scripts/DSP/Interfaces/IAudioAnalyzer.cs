namespace Upstream
{
    /// <summary>
    /// Simple interface whose implementations should yield a single new "Value" at every audio buffer callback.
    /// </summary>
    public interface IAudioAnalyzer
    {
        public float Value { get; }
    }
}