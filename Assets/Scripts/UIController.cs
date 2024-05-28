using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class UIController : MonoBehaviour
{
    //Inspectorから値を変更したいかつ、他のクラスからの書き換えを防ぎたいもの
    [SerializeField] private GameObject CountUI;
    // [SerializeField] private GameObject CreateUI;

    [SerializeField] private Lumberyard lumberyard;
    //  [SerializeField] private Workbench workbench;

    [SerializeField] private TextMeshProUGUI Item_Text;
    //  [SerializeField] private TextMeshProUGUI Create_Text;
    [SerializeField] private TextMeshProUGUI Timer_Text;


    private int Wood_Count;
    private int Create_Count;
    public static float Timer;


    void Start()
    {
        //  最初の操作説明Canvasを表示



        if(lumberyard == null)
        {
            Debug.Log("null");
        }

        //カウントするUIの表示を無効化
        CountUI.SetActive(false);
        // CreateUI.SetActive(false);

        //  カウント等、必要な変数
        Wood_Count = 0;
        Create_Count = 0;
        Timer = 0;
    }

    void Update()
    {

        //  各アイテムのカウントの値を取ってくる
        Wood_Count = lumberyard.GetCount();
        //  Create_Count = workbench.Get_WoodCount();

        Timer += Time.deltaTime;
        Timer_Text.text = "Timer：" + Timer.ToString("n2");

        //  カウントが0より大きくなったら木材のUIを表示
        if (Wood_Count>0)
        {
            //  CountUIを表示
            CountUI.SetActive(true);
        }

        //  カウントが0より大きくなったらのUIを表示
        if (Create_Count>0)
        {
            //  CreateUIを表示
           //  CreateUI.SetActive(true);
        }

        //  テキスト書き換え
        ItemDisplay(Wood_Count);
        WindowDispray(Create_Count);
    }

    public void ItemDisplay(int count)
    {
        //  アイテムテキスト書き換え
        Item_Text.text = count.ToString();
    }


    //  右上に木材を入手したら吹き出しと、数字を表示するメソッドを作成
    public void WindowDispray(int ItemCount)
    {
        //  橋カウント書き換え
        // Create_Text.text = ItemCount.ToString();
    }

    public static float Get_Timer()
    {
        return Timer;
    }

}
