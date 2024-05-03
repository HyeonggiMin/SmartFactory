using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 특정 기능을 실행할 때, 해당 기능에 맞는 audio clip을 재생
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // 싱글톤 객체
    AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // 캐싱 or 래퍼런싱
    }

    public void PlayAudioClip(AudioClip clipName)
    {
        AudioClip clip = audioClips.Find(x => x == clipName);
        audioSource.clip = clip;
        audioSource.Play();
    }
}