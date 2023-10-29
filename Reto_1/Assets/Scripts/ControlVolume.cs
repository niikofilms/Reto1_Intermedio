using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControlVolume : MonoBehaviour
{
    [Header("options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    private float lastVolume;

    

    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(ChangeVolumeFx);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }

    public void SetMute()

    {
        if (mute.isOn)

        {
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);

        }

        else
            mixer.SetFloat("VolMaster", lastVolume);

    }

    public void openPanel (GameObject panel)
    {
        PlaySoundButton();
    }    

    public void ChangeVolumeMaster(float v)

    {
        mixer.SetFloat("VolMaster", v);
    }
    public void ChangeVolumeFx(float v)

    {
        mixer.SetFloat("VolFx", v);
    }
    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);

    }


}
