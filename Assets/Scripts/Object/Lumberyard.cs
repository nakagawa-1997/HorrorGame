using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class Lumberyard : MonoBehaviour
{
    //Inspectorから値を変更したいかつ、他のクラスからの書き換えを防ぎたいもの
    [SerializeField] private float AcquisitionSpan = 1.0f;

    [SerializeField] private AudioClip sound1;
    AudioSource audioSource;

    private int count = 0;

    private int MaxNum = 99;
    private int MinNum = 0;

    private float delta;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerStay(Collider collider)
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.AcquisitionSpan)
        {
            this.delta = 0;

            if (MinNum <= count && count < MaxNum)
            {
                //  音を鳴らす
                audioSource.PlayOneShot(sound1);

                count++;
                Debug.Log("OK");
            }
        }
    }
    public int GetCount()
    {
        return count;
    }
    //  減らす用
    public void SetCount(int SubCount)
    {
        this.count += SubCount;
    }
}
