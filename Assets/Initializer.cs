using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour
{
    IEnumerator Start()
    {
        Application.targetFrameRate = 60;

        AudioSettings.speakerMode = AudioSpeakerMode.Mono;
        AudioSettings.outputSampleRate = 44100;
        AudioSettings.SetDSPBufferSize(320, 4);

        yield return null;
        yield return null;
        yield return null;

        Application.LoadLevel("Main");
    }
}
