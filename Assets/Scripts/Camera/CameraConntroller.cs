using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraConntroller : MonoBehaviour
{
    [SerializeField] private float CameraHeight_Y = 0.5f;
    //  回転速度
    [SerializeField] private float Y_RotationSpeed = 500f;
    [SerializeField] private float MaxRotateLimit;
    [SerializeField] private float MinRotateLimit;

    //private Vector3 Camera_PlayerDistance = new Vector3(-0.2f, 2f, -0f);        //  カメラとプレイヤーの距離
    private Vector3 Camera_PlayerDistance = new Vector3(-0.2f, 2f, -7f);

    //bool MoveMouseFlag;                 //  マウスが動いたかどうかのフラグ

    //  入力コントローラー
    GameObject InputController;

    GameObject Player;

    private void Start()
    {
        //入力コントローラーの中身を渡すぐ渡せるよう紐づけておく
        InputController = GameObject.Find("InputController");

        Player = GameObject.Find("Player");
        
        //  マウスの現在位置とカメラの角度を取得（初期地点の設定）
        InputController.GetComponent<InputController>().Get_StartMousePosition_Update();
        
        //  マウスの移動フラグをfalseにする
        //MoveMouseFlag = false;


        Vector3 playerPosition = Player.GetComponent<Player>().GetPlayerPosition();
        Camera.main.transform.position = playerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = Player.GetComponent<Player>().GetPlayerPosition();
        playerPosition += new Vector3(0.0f, CameraHeight_Y, 0.0f);
        Camera.main.transform.position = playerPosition;

        //  マウスの位置が移動したかどうか確認
        if (InputController.GetComponent<InputController>().Get_CurrentMousePosition() != Input.mousePosition)
        {
            //  カメラの位置を移動させる
            //InputController.GetComponent<InputController>().Mouse_Rotate(Player.transform.position);
            Camera.main.transform.position += Camera_Rotate(playerPosition, Camera.main.transform.position);

            //　X軸の回転上限を超えていた場合最大値、または最小値に戻す
            float localAngle_X = transform.localEulerAngles.x;
            float localAngle_Y = transform.localEulerAngles.y;

            if (localAngle_X > MaxRotateLimit && localAngle_X < 180)
            {
                localAngle_X = MaxRotateLimit;
            }
            if (localAngle_X < MinRotateLimit && localAngle_X > 180)
            {
                localAngle_X = MinRotateLimit;
            }

            Camera.main.transform.rotation = Quaternion.Euler(localAngle_X, localAngle_Y, 0.0f);
        }
        else 
        {
            //  マウスの現在位置とカメラの角度を取得（初期地点の設定）
            InputController.GetComponent<InputController>().Get_CurrentMousePosition_Update();
        }
        Camera.main.transform.position = playerPosition;

    }


    private Quaternion CameraRotate_Y(Vector3 point)
    {
        float mouseInputY = Input.GetAxis("Mouse Y");
        //  pointを中心にx軸回転
        transform.RotateAround(point, Vector3.right, mouseInputY * Time.deltaTime * Y_RotationSpeed);

        return transform.rotation;
    }

    //  向きを計算するメソッド
    private Vector3 Camera_Rotate(Vector3 playerPos, Vector3 cameraPos)
    {
        //  カメラの現在座標からプレイヤーの座標を引く→カメラの中心を原点(0,0,0)の位置にする
        Vector3 cameraZero = cameraPos - playerPos;


        //  マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");
        float angle_Y = mouseInputX * Time.deltaTime * InputController.GetComponent<InputController>().X_RotationSpeed;
        //  pointを中心にy軸回転
        this.transform.RotateAround(cameraZero, Vector3.up, angle_Y);    //  RotateAround( 中心とする座標 , 中心とする軸 , 回転角度 )


        //  マウスの移動量
        float mouseInputY = Input.GetAxis("Mouse Y");
        float angle_X = mouseInputY * Time.deltaTime * Y_RotationSpeed;

        //  pointを中心にx軸回転
        this.transform.RotateAround(cameraZero, Vector3.left, angle_X);

        //  カメラを回転させたまま元の位置に戻す→カメラの中心をプレイヤーにする
        cameraPos = cameraZero + playerPos;

        return cameraPos;
    }

    public Vector3 Camera_GetRotate_Y()
    {
        return new Vector3(0.0f, this.gameObject.transform.localEulerAngles.y, 0.0f);
    }
}
