using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Inspectorから値を変更したいかつ、他のクラスからの書き換えを防ぎたいもの
    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCursorSound()
    {
        //  音を鳴らす
        audioSource.PlayOneShot(sound1);
    }
    public void PlayButtonPushSound()
    {
        //  音を鳴らす
        audioSource.PlayOneShot(sound2);
    }
}
