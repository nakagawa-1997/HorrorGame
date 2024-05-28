using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageCreationLocation : MonoBehaviour
{

    [SerializeField] Lumberyard lumberyard;

    [SerializeField] private GameObject BoxPrefab;

    [SerializeField] private float Box_AcquisitionSpan = 5.0f;

    GameObject BoxObj;

    //  箱が存在しているかどうかフラグ
    private bool boxFlag;
    private float delta;



    private void Update()
    {
        ExistCheckObject();
    }

    /// <summary>
    /// 箱を作成するメソッド
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerStay(Collider collider)
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.Box_AcquisitionSpan && boxFlag == false)
        {
            this.delta = 0;

            if (lumberyard.GetCount() - 5 >= 0 )
            {
                //  木のカウントを変更
                lumberyard.SetCount(-5);
                Debug.Log("YES");

                //  箱作成
                GameObject BoxObj = Instantiate(BoxPrefab);
                BoxObj.transform.position = new Vector3(30.0f, 8.0f, 20.0f);
            }
        }
    }


    /// <summary>
    /// オブジェクトが存在するかを確認
    /// </summary>
    private void ExistCheckObject()
    {
        if (BoxPrefab)
        {

            Debug.Log(false);
            boxFlag = false;

        }
        else
        {
            Debug.Log(true);
            boxFlag = true;
        }
    }
}
