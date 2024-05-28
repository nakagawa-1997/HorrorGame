using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{

    [SerializeField]
    SceneController sceneController;

    GameObject SceneController;
    GameObject Player;

    Vector3 player = new Vector3();

    //  クリアフラグ
    private static bool clearFlag = true; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = Player.GetComponent<Player>().GetPlayerPosition();

        //  プレイヤーがある一定の位置まで落下していたらシーンを変更
        if (player.y < -0.5f)
        {
            clearFlag = false;
            //  シーン偏移
            this.sceneController.ChangeGameEndScene();
        }
        
    }

    public static bool Get_clearFlg()
    {
        return clearFlag;
    }
}