using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] private Collider[] ItemAvailableColl;  //  取得可能 / 取得条件を満たすオブジェクト
    [SerializeField] private float RayMaxDistance = 100.0f;

    [SerializeField] GameObject ItemController;

    private void Start()
    {
        //  gameobjectの中身を渡すぐ渡せるよう紐づけておく
        ItemController = GameObject.Find("ItemController");

        for (int i = 0; i < ItemAvailableColl.Length; i++)
        {
            ItemAvailableColl[i].GetComponent<Collider>();
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

                        GameObject item = Instantiate()
                    }
                    if (hit.collider.tag == "yellow")
                    {
                        Debug.Log("黄色の箱を触った");
                    }
                    if (hit.collider.tag == "blue")
                    {
                        Debug.Log("青色の箱を触った");
                    }
                }
            }

            //  Rayを表示
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }

    }
}
