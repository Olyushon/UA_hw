using UnityEngine;

public class BombAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourcePrefab;

    public void PlayExplosionSound()
    {
        AudioSource audioSource = Instantiate(_audioSourcePrefab, transform.position, Quaternion.identity);
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
