using UnityEngine;
using System.Collections;

public class RmsToScale : MonoBehaviour
{
    public bool mute = true;

    float squareSum;
    int sampleCount;

    void Update()
    {
        if (sampleCount < 1) return;

        var rms = Mathf.Sqrt(squareSum / sampleCount);

        transform.localScale = Vector3.one * rms;

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
