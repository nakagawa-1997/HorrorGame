using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ChengeItem;

public class ChengeItem : MonoBehaviour
{
    [SerializeField] private GameObject ItemPos;
    [SerializeField] private GameObject ItemInfo;

    int ItemPrefabLength;

    //  取得したアイテムのタグ名を入れる
    private string[] itemTag;
    private int count;
    private GameObject[] tagObjs;
    

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
        //  すぐ呼び出せるように場所を見つけておく
        ItemInfo = GameObject.Find("ItemInfo");

        //  アイテム配列の長さを渡しておく
        ItemPrefabLength = ItemInfo.GetComponent<ItemPrefabInfo>().Get_ItemMaxNum();

        itemTag = new string[ItemPrefabLength];
        tagObjs = new GameObject[ItemPrefabLength];
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
            currentItem = (currentItem + 1) % ItemPrefabLength;

            for (int i = 0; i < ItemPrefabLength; i++)
            {
                if (i == currentItem)
                {
                    //  オブジェクトの表示
                    tagObjs[i].SetActive(true);
                }
                else
                {
                    //  オブジェクトを非表示
                    tagObjs[i].SetActive(false);
                }
            }
        }
        else if (wheel < 0)
        {
            currentItem = (currentItem - 1) % ItemPrefabLength;
            if (currentItem < 0)
            {
                currentItem = 3;
            }

            for (int i = 0; i < ItemPrefabLength; i++)
            {
                if (i == currentItem)
                {
                    //  オブジェクトを表示
                    tagObjs[i].SetActive(true);
                }
                else
                {
                    //  オブジェクトを非表示
                    tagObjs[i].SetActive(false);
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

        for (int i = 0; i < ItemPrefabLength; i++)
        {
            if (i == currentItem)
            {
                //  int型をenum型に変更するための作業
                itemTagName = ItemInfo.GetComponent<ItemPrefabInfo>().Get_ItemTag(i);
            }
        }

        return itemTagName;
    }

    //  アイテムのタグを渡す
    public void ItemTag(string tagName)
    {
        for (int i = 0; i < itemTag.Length; i++)
        {
            if (itemTag[i]==null)
            {
                itemTag[i] = tagName;
                //  tagでGameObjectを見つける
                tagObjs[i]=GameObject.Find(tagName);
            }
        }
    }

    //  タグ配列の初期化
    public void ItemChengeInit(int ItemMaxNum)
    {
        currentItem = 0;
        for (int i = 0; i < ItemMaxNum; i++)
        {
            if (i == currentItem)
            {
                //ItemInfo.GetComponent<ItemPrefabInfo>().Object_SetActiveTrue(i);
                tagObjs[i].SetActive(true);
            }
            else
            {
                //ItemInfo.GetComponent<ItemPrefabInfo>().Object_SetActiveFalse(i);
                tagObjs[i].SetActive(false);
            }
        }

        //  ホイールの配列宣言
        itemTag = new string[ItemPrefabLength];
        itemTag[0] = "hand";
    }

}
