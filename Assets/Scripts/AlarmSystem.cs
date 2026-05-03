using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private TriggerDetector _detector;
    [SerializeField] private float _stepSound;

    private AudioSource _audioSource;
    private Coroutine audioStatus;
    private float _maxSound => 1;
    private float _minSound => 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnEnable()
    {
        _detector.ThiefIsEnter += AlarmStatus;
    }

    private void AlarmStatus(bool isEnter)
    {
        if (audioStatus != null)
        {
            StopCoroutine(audioStatus);
        }

        if(isEnter)
        {
           if (_audioSource.isPlaying == false) _audioSource.Play();

           audioStatus = StartCoroutine(ChangeVolume(_maxSound));
        }
        else
        {
           audioStatus = StartCoroutine(ChangeVolume(_minSound));
        }
    }
    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
           _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _stepSound * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == _minSound) _audioSource.Stop();
    }
}
