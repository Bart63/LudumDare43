using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioSource VolumeAudio;

    public void VolumeController()
    {
        VolumeAudio.volume = VolumeSlider.value;
    }
}