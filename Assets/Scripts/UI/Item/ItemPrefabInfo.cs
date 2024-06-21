using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefabInfo : MonoBehaviour
{
    //  デザインパターン　シングルトンにする
    //  アイテムオブジェクトの配列をここに作る（クラス？インスタンス化させる）
    [SerializeField] GameObject[] ItemPrefab;

    //  ▼ここですること
    //  アイテムの情報を渡したり、書き換えたりする関数をここで作って別のスクリプトで呼び出す
    //  ここは Update なしの呼び出し専用スクリプトとして扱う

    //  配列の長さを渡す関数
    public int Get_ItemMaxNum()
    {
        return ItemPrefab.Length;
    }

    //  配列のタグを渡す関数
    public string Get_ItemTag(int i)
    {
        return ItemPrefab[i].tag;
    }

    //  プレハブそのものの情報を渡す関数
    public GameObject Get_Prefab(int i)
    {
        return ItemPrefab[i];
    }

    //  オブジェクトの表示/非表示を切り替える関数
    public void Object_SetActiveTrue(int i)     //  表示
    {
        ItemPrefab[i].SetActive(true);
    }
    public void Object_SetActiveFalse(int i)    //  非表示
    {
        ItemPrefab[i].SetActive(false);
    }

}
