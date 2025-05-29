using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler
{
    private const float _OnVolumeValue = 0f;
    private const float _OffVolumeValue = -80f;

    private const string _MusicKey = "MusicVolume";
    private const string _SoundsKey = "SoundsVolume";

    private AudioMixer _audioMixer;

    public AudioHandler(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public void ToggleMusic()
    {
        if (IsVolumeOn(_MusicKey))
            VolumeOff(_MusicKey);
        else
            VolumeOn(_MusicKey);
    }

    public void ToggleSounds()
    {
        if (IsVolumeOn(_SoundsKey))
            VolumeOff(_SoundsKey);
        else
            VolumeOn(_SoundsKey);
    }

    private bool IsVolumeOn(string key) 
        => _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - _OnVolumeValue) < 0.01f;

    private void VolumeOn(string key)
    {
        _audioMixer.SetFloat(key, _OnVolumeValue);
    }

    private void VolumeOff(string key)
    {
        _audioMixer.SetFloat(key, _OffVolumeValue);
    }

}
