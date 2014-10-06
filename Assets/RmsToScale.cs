using UnityEngine;
using System.Collections;

public class RmsToScale : MonoBehaviour
{
    public bool mute = true;

    float squareSum;
    int sampleCount;

    void Update()
    {
        var rms = (sampleCount > 0) ? Mathf.Sqrt(squareSum / sampleCount) : 0;

        transform.localScale = new Vector3(1, rms, 1);

        squareSum = 0;
        sampleCount = 0;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (var i = 0; i < data.Length; i += channels)
        {
            var level = data[i];
            squareSum += level * level;
        }

        sampleCount += data.Length / channels;

        if (mute)
            for (var i = 0; i < data.Length; i++)
                data[i] = 0;
    }
}
