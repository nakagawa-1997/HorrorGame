using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ChengeItem;

public class ChengeItem : MonoBehaviour
{
    [SerializeField] private GameObject ItemPos;

    [SerializeField] public GameObject[] ItemPrefab;
    

    //  現在所持しているアイテム
    private int currentItem;


    //  アイテム状態　ビットフラグ　※アイテムプレハブの中身と対応した上から順番に名前をつけること
    [Flags]
    public enum PlayerItem
    {
        Free = 1 << 0,     //  0000 0001
        Light = 1 << 1,      //  0000 0010
        Key = 1 << 2,      //  0000 0100
        Memo = 1 << 3
    }


    // Start is called before the first frame update
    void Start()
    {
        currentItem = 0;
        for (int i = 0; i < ItemPrefab.Length; i++)
        {
            if (i == currentItem)
            {
                ItemPrefab[i].SetActive(true);
            }
            else
            {
                ItemPrefab[i].SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        ItemChange();
    }

    void ItemChange()
    {
        //  マウスホイールの移動量取得
        float wheel = Input.GetAxis("Mouse ScrollWheel");

        //  各アイテムごとに表示する物を切り替え
        ItemJug(wheel);

        Debug.Log(currentItem);

    }

    /// <summary>
    /// 選択されたアイテムの名前を返す
    /// </summary>
    /// <param name="wheel"></param>
    /// <returns></returns>
    void ItemJug(float wheel)
    {
        if (wheel > 0)
        {
            currentItem = (currentItem + 1) % ItemPrefab.Length;

            for (int i = 0; i < ItemPrefab.Length; i++)
            {
                if (i == currentItem)
                {
                    ItemPrefab[i].SetActive(true);
                }
                else
                {
                    ItemPrefab[i].SetActive(false);
                }
            }
        }
        else if (wheel < 0)
        {
            currentItem = (currentItem - 1) % ItemPrefab.Length;
            if (currentItem < 0)
            {
                currentItem = 3;
            }

            for (int i = 0; i < ItemPrefab.Length; i++)
            {
                if (i == currentItem)
                {
                    ItemPrefab[i].SetActive(true);
                }
                else
                {
                    ItemPrefab[i].SetActive(false);
                }
            }
        }

    }
    /*
    public PlayerItem GetItemActivMode()
    {
        PlayerItem itemName = PlayerItem.Free;
        int ItemNo;

        for (int i = 0; i < ItemPrefab.Length; i++)
        {
            if (i == currentItem)
            {
                //  int型をenum型に変更するための作業
                ItemNo = 1 << i;
                itemName = (PlayerItem)Enum.ToObject(typeof(PlayerItem), ItemNo);
            }
        }

        return itemName;
    }
    */

    public string GetItemActiveTagName()
    {
        string itemTagName = "hand";

        for (int i = 0; i < ItemPrefab.Length; i++)
        {
            if (i == currentItem)
            {
                //  int型をenum型に変更するための作業
                itemTagName = ItemPrefab[i].tag;
            }
        }

        return itemTagName;
    }
}
