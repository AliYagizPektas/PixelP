public static class GraduallyChange
{
    /// <summary>Gradually changes a given value to target value.</summary>
    /// <param name="from">Start value.</param>
    /// <param name="callback">Lambda for assigning gradually changing value to a variable.</param>
    /// <param name="to">Target value.</param>
    /// <param name="duration">How long it will take start value to reach target value? In seconds.</param>
    /// <param name="isSmooth">Should interpolation be smooth?</param>
    /// <param name="onComplete">Function to run when interpolation completed.</param>
    public static System.Collections.IEnumerator To(System.Func<float> from, System.Action<float> callback, float to, float duration, bool isSmooth = false, System.Action onComplete = null)
    {
        var t = 0f;
        var current = from();
        var a = from();
        while (current != to)
        {
            t += UnityEngine.Time.fixedDeltaTime;
            t = System.Math.Clamp(t, 0, duration);
            current = isSmooth ? Lerp(current, to, (t / (duration * 10))) : Lerp(a, to, (t / duration));
            if (current.IsSimiliarTo(to))
            {
                callback(to);
                onComplete?.Invoke();
                break;
            }
            callback(current);
            yield return new UnityEngine.WaitForFixedUpdate();
        }
    }
    /// <summary>Checks if a and b similiar to eachother by delta.</summary>
    /// <param name="delta">Minimum difference between numbers.</param>
    /// <returns>True if numbers are similiar</returns>
    public static bool IsSimiliarTo(this float a, float b, float delta = 0.01f) => System.Math.Abs(b - a) <= delta;

    /// <summary>Linearly interpolate between a and b.</summary>
    /// <param name="t">Interpolation value between values.</param>
    /// <returns>Interpolated value between values</returns>
    public static float Lerp(float a, float b, float t) => (1 - t) * a + t * b;
}
