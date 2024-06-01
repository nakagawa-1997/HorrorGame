using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChengeItem;

public class ItemUseJug : MonoBehaviour
{
    [SerializeField] GameObject ItemController;
    [SerializeField] GameObject flashLight;

    private bool IsClick_Memo = false;
    private GameObject memoAnime;



    // Start is called before the first frame update
    void Start()
    {
        //  gameobjectの中身を渡すぐ渡せるよう紐づけておく
        ItemController = GameObject.Find("ItemController");
        flashLight = GameObject.Find("FlashLight_spotLight");

    }

    // Update is called once per frame
    void Update()
    {
        //  tagを受け取る
        string playerItem;
        playerItem = ItemController.GetComponent<ChengeItem>().GetItemActiveTagName();

        //  使うキー（マウスの右クリック）が押されたかどうか
        if (Input.GetMouseButtonDown(1))    //  右クリック
        {
            //押された場合

            //  アイテム別で動きを変化させる
            switch (playerItem)
            {
                case "hand":
                    Debug.Log("アイテム：なし　右クリック");

                    break;
                case "key":

                    Debug.Log("アイテム：カギ　右クリック");
                    //  鍵→目の前に鍵のかかった扉があるか判定　ある場合（その鍵が使える扉か判定後、扉をロック解除する）　ない場合（なにもないと表示）
                    break;
                case "flashLight":

                    Debug.Log("アイテム：懐中電灯　右クリック");
                    //  懐中電灯→電気のON/OFF　
                    if (flashLight.activeSelf == true)
                    {
                        flashLight.SetActive(false);
                    }
                    else if (flashLight.activeSelf == false)
                    {
                        flashLight.SetActive(true);
                    }
                    break;
                case "memo":

                    Debug.Log("アイテム：メモ　右クリック");
                    IsClick_Memo = true;

                    break;

            }
        }
        else
        {
            //  押されなかった場合
            IsClick_Memo = false;
            //  何もなし
        }
    }

    public bool GetIsClick_MemoFlag()
    {
        return IsClick_Memo;
    }
}
