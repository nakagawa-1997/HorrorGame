using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{

    //  タイトルシーン切り替え
    public void ChangeTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    //  メインシーン切り替え
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    //エンディングシーン切り替え
    public void ChangeGameEndScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    //  ゲームを終わる
    public void GameEnd()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #endif
            Application.Quit();//ゲームプレイ終了
    }
}
