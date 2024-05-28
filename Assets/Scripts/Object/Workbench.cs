using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.UIElements.ToolbarMenu;

public class Workbench : MonoBehaviour
{
    [SerializeField] private float Wood_AcquisitionSpan = 1.0f;

    [SerializeField] Lumberyard lumberyard;

    private int woodCount = 0;

    private int MaxNum = 99;
    private int MinNum = 0;

    private float delta;

    /// <summary>
    /// 木の作成メソッド
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerStay(Collider collider)
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.Wood_AcquisitionSpan)
        {
            this.delta = 0;

            if (MinNum <= woodCount && woodCount < MaxNum && lumberyard.GetCount() - 5 >= 0) 
            {
                woodCount++;
                //  木のカウントを変更
                lumberyard.SetCount(-5);
                Debug.Log("OK");
            }
        }
    }


    /// <summary>
    /// 木材の数を渡す
    /// </summary>
    /// <returns></returns>
    public int Get_WoodCount()
    {
        return woodCount;
    }
}
