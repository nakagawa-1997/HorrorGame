using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class IsGetItem : MonoBehaviour
{
    //  Inspectorで指定したまとめてCanvasGroupのアルファ値を変更する
    [SerializeField] private CanvasGroup UI_Icon;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float waitTime = 0.5f;   //  完全に表示されてからの待ち時間

    private float alphaValue;//変化する透過率の値

    //  タイマー用
    private float countTime;

    private bool goingFlag;
    private bool ReturnFlag;
    private bool rimitTimeFlag;


    private void Start()
    {
        alphaValue = 0.0f;
        countTime = 0.0f;

        goingFlag = false;
        ReturnFlag = false;
        rimitTimeFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  使うキー（マウスの右クリック）が押されたかどうか
        if (Input.GetMouseButtonDown(1))
        {
            //  行きフラグをtrueにする
            goingFlag = true;
        }

        //  行きフラグがtrueの場合
        if (goingFlag)
        {
            alphaValue = Mathf.Lerp(alphaValue, 1.0f, Time.deltaTime * speed);
            if(alphaValue>=0.98f)
            {
                //  行きフラグの初期化と待機フラグの変更
                goingFlag = false;
                rimitTimeFlag = true;

                alphaValue = 1.0f;
            }
        }
        else if (rimitTimeFlag)//  待機フラグがtrueの場合
        {
            if (countTime < waitTime)
            {
                //  カウントする時間を増やす
                countTime += Time.deltaTime;
            }
            else
            {
                rimitTimeFlag = false;
                ReturnFlag = true;
            }
        }
        else if (ReturnFlag)//  帰りフラグがtrueの場合
        {
            alphaValue = Mathf.Lerp(alphaValue, 0.0f, Time.deltaTime * speed);
            if (alphaValue <= 0.02f)
            {
                //  帰りフラグの初期化
                ReturnFlag = false;
                alphaValue = 0.0f;
            }
        }

        //  透過率変更
        UI_Icon.alpha = alphaValue;
    }
}
