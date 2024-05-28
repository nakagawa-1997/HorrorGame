using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] private Animator animator;

    [SerializeField] Transform InitialPos;
    [SerializeField] Transform targetPos;
    [SerializeField] private GameObject boxPrefab;

    [SerializeField] private float speed = 5.0f;


    private bool trunFlg = false;

    // Update is called once per frame
    void Update()
    {

        Debug.Log("NoTrun");
        animator.SetBool("TrunFlg", false);

        Quaternion rotation = this.transform.localRotation;


        if (trunFlg==false)
        {
            //  指定した位置まで移動
            this.transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);

            //指定した位置まで到着した場合
            if (transform.position == targetPos.position)
            {

                Debug.Log("Trun");
                animator.SetBool("TrunFlg", true);

                //  回転
                Vector3 rotationAngles = rotation.eulerAngles;
                // y軸の180度回転
                rotationAngles.y = rotationAngles.y + 180.0f;
                rotation = Quaternion.Euler(rotationAngles);

                this.transform.localRotation = rotation;

                trunFlg = true;
            }
        }
        else
        {
            //  最初の位置まで移動
            transform.position = Vector3.MoveTowards(transform.position, InitialPos.position, speed * Time.deltaTime);
            if (transform.position == InitialPos.position)
            {

                Debug.Log("ReTrun");
                animator.SetBool("TrunFlg", true);

                //  回転
                Vector3 rotationAngles = rotation.eulerAngles;
                // y軸の180度回転
                rotationAngles.y = rotationAngles.y - 180.0f;
                rotation = Quaternion.Euler(rotationAngles);


                this.transform.localRotation = rotation;
                trunFlg = false;
            }
        }
    }
}
