using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer ReftoAudioMixer;
    // Start is called before the first frame update
  public void SetVolume (float volume)
  {
      ReftoAudioMixer.SetFloat("Volume", volume);
  }
}
