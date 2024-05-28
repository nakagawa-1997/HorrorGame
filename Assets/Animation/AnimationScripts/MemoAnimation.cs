using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoAnimation : MonoBehaviour
{
    //  メモ用
    private GameObject memo;
    [SerializeField] private float memoStopPoint_X = 0;
    [SerializeField] private float memoStopPoint_Y = 0;
    [SerializeField] private float memoStopPoint_Z = 0;

    private Animator anim = null;

    private GameObject isClick;
    private bool standBy_isClick = false;

    // Start is called before the first frame update
    void Start()
    {
        //  メモ用
        anim = GetComponent<Animator>();
        //  ゲームオブジェクトの受け渡し（アニメーションを途中で止めるために使用）
        memo = GameObject.Find("Memo");
        isClick = GameObject.Find("ItemUse");
    }

    // Update is called once per frame
    void Update()
    {
        bool clickFlag = isClick.GetComponent<ItemUseJug>().GetIsClick_MemoFlag();

        if (clickFlag == true) 
        {
            if (standBy_isClick == false) //  待機状態じゃないならば
            {
                //  メモ→メモに書かれた文字の表示（ゲームループを回す）
                anim.SetBool("IsClick", true);

                standBy_isClick = true;
            }
            else if(standBy_isClick == true)
            {



            }


            Vector3 memo_StopPoint = new Vector3(memoStopPoint_X, memoStopPoint_Y, memoStopPoint_Z);
            //  もう一度右クリックされるまで見続ける

            //  アニメーションでオブジェクトが指定の位置まで来たらアニメーションを一時停止させる
            if (memo.transform.position == memo_StopPoint)
            {
                //  一時停止
                anim.SetFloat("MovingSpeed", 0.0f);


                if (Input.GetMouseButtonDown(1))
                {
                    //  アニメーションを再開する
                    anim.SetFloat("MovingSpeed", 1.0f);
                    anim.SetBool("IsClick", false);

                }
            }

        }
        
    }

    public void IsClickedAnim()
    {
        
    }
}
