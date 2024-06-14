//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class GetItem : MonoBehaviour
{
    [SerializeField] private Collider[] ItemAvailableColl;  //  取得可能 / 取得条件を満たすオブジェクト
    [SerializeField] private float RayMaxDistance = 100.0f;

    [SerializeField] GameObject ItemController;

    [SerializeField] GameObject ItemParent;
    [SerializeField] GameObject[] ItemPrefab;

    private bool[] itemExists;
    private GameObject[] ObtainedItem;

    private void Start()
    {
        //  gameobjectの中身を渡すぐ渡せるよう紐づけておく
        ItemController = GameObject.Find("ItemController");

        for (int i = 0; i < ItemAvailableColl.Length; i++)
        {
            ItemAvailableColl[i].GetComponent<Collider>();
        }


        //  生産するアイテム配列の長さを渡す
        itemExists = new bool[ItemPrefab.Length];
        for (int i = 0;i < ItemPrefab.Length;i++)
        {
            itemExists[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  メインカメラの位置
        Vector3 rayOriginPos = Camera.main.transform.position;

        //  Raycastを飛ばす方向(mainのカメラが向いている方向)
        Vector3 rayDestPos= Camera.main.transform.forward;


        //  マウスを左クリックした後にRayを飛ばす
        if (Input.GetMouseButton(0))
        {
            //  Rayを作成
            Ray ray = new Ray(rayOriginPos, rayDestPos);
            //  Rayの衝突判定オブジェクト
            RaycastHit hit;

            for (int i = 0; i < ItemAvailableColl.Length; i++)
            {
                //  Rayの長さを決めて、決まった行動を取る？
                if (ItemAvailableColl[i].Raycast(ray, out hit, RayMaxDistance))
                {
                    transform.position = ray.GetPoint(RayMaxDistance);

                    //  オブジェクト別に行動を処理するのに『 hit.collider.tag == "○○" 』のように tag で判定することも可能
                    if (hit.collider.tag == "red")
                    {
                        Debug.Log("赤色の箱を触った");

                        //  アイテムのタグで生産するアイテムを判別する
                        ProcessByItem("key");
                    }
                    if (hit.collider.tag == "yellow")
                    {
                        Debug.Log("黄色の箱を触った");

                        //  アイテムのタグで生産するアイテムを判別する
                        ProcessByItem("memo");
                    }
                    if (hit.collider.tag == "blue")
                    {
                        Debug.Log("青色の箱を触った");

                        //  アイテムのタグで生産するアイテムを判別する
                        ProcessByItem("flashLight");
                    }
                }
            }

            //  Rayを表示
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }

    }

    //  アイテム取得後の動き(生産のみ)
    void ItemProduction(GameObject Prefab)
    {
        //  配列で設定したアイテムを生産する
        GameObject item = Instantiate(Prefab, ItemParent.transform.position, Quaternion.identity);

        //  親オブジェクトの指定？
        item.transform.parent = ItemParent.transform;
    }

    //  アイテム取得後の動き(全部)
    void ProcessByItem(string PrefabTagName)
    {
        //  アイテムのタグで生産するアイテムを判別する
        for (int j = 0; j < ItemPrefab.Length; j++)
        {
            if (itemExists[j] == false)
            {
                if (ItemPrefab[j].tag == PrefabTagName)
                {
                    //  アイテム生産（生産場所をUIカメラの子オブジェクトにする？）
                    ItemProduction(ItemPrefab[j]);
                    itemExists[j] = true;
                    Debug.Log(PrefabTagName + "が生産されました");
                }
                else
                {
                    Debug.Log(PrefabTagName + "というタグ名は見つかりません");
                }
            }
            else
            {
                Debug.Log(PrefabTagName + "は既に生産されています");
            }
        }
    }
}
