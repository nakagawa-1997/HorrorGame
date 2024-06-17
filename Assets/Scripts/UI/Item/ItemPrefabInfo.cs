using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefabInfo : MonoBehaviour
{
    //  デザインパターン　シングルトンにする
    [SerializeField] GameObject[] ItemPrefab;

    //  アイテムオブジェクトの配列をここに作る（クラス？インスタンス化させる）
    //  アイテムの情報を渡したり、書き換えたりする関数をここで作って別のスクリプトで呼び出す
    //  ここは Update なしの呼び出し専用スクリプトとして扱う

    //  配列の長さを渡す関数
    //  配列のタグを渡す関数
    //  プレハブそのものの情報を渡す関数
    //  オブジェクトの表示/非表示を切り替える関数

}
