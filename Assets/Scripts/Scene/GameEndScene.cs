using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class GameEndScene : MonoBehaviour
{
    //Inspectorから値を変更したいかつ、他のクラスからの書き換えを防ぎたいもの
    [SerializeField] private GameObject GameClearUI;
    [SerializeField] private GameObject GameOverUI;

    [SerializeField] private TextMeshProUGUI Timer_Text;
    [SerializeField] private TextMeshProUGUI Result_Text;

    private float Timer_Result;
    private bool clearflg;

    private void Start()
    {
        //  かかった時間渡し
        Timer_Result = UIController.Get_Timer();

        //  クリアフラグ渡し
        clearflg=MainScene.Get_clearFlg();


        //  かかった時間書き出し
        Timer_Text.text = "Time：" + Timer_Result.ToString("n2");

        //  背景変化
        if (clearflg == true)
        {
            //UIの表示を無効化
            GameOverUI.SetActive(false);


            //  かかった時間によって称号のテキストを変える
            if (0f < Timer_Result && Timer_Result <= 40f)           //  かかった時間が0～50までの間なら
            {
                Result_Text.text = "あなたは...ベテラン配達員";
            }
            else if (40f < Timer_Result && Timer_Result <= 70f)
            {
                Result_Text.text = "あなたは...一般配達員";
            }
            else if (70f < Timer_Result && Timer_Result <= 90f)
            {
                Result_Text.text = "あなたは...新人配達員";
            }
            else
            {
                Result_Text.text = "あなたは...アルバイター";
            }
        }
        else if (clearflg == false) 
        {
            //UIの表示を無効化
            GameClearUI.SetActive(false);

            //  結果を表示
            Result_Text.text = "あなたは...大怪我をしてしまった";
        }

    }
}
