using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputController : MonoBehaviour
{
    //  回転速度
    [SerializeField] public float X_RotationSpeed = 500f;

    private Vector3 StartMousePosition = Vector3.zero;      //  マウスの最初の位置
    private Vector3 CurrentMousePosition = Vector3.zero;      //  マウスの現在位置
    private Vector3 StartCameraRotation = Vector3.zero;     //  カメラの最初の角度
    private Vector3 CurrentCameraRotation = Vector3.zero;     //  カメラの現在の角度

    private void Update()
    {
        MouseCursorFormat();
    }


    //  現在のマウスの位置を更新するメソッド
    public void Get_CurrentMousePosition_Update()
    {
        //  マウスの現在位置とカメラの角度を取得（初期地点の設定）
        CurrentMousePosition = Input.mousePosition;
        CurrentCameraRotation = Camera.main.gameObject.transform.rotation.eulerAngles;
    }

    //  最初のマウスの位置を更新するメソッド
    public void Get_StartMousePosition_Update()
    {
        //  マウスの現在位置とカメラの角度を取得（初期地点の設定）
        StartMousePosition = Input.mousePosition;
        StartCameraRotation = Camera.main.gameObject.transform.rotation.eulerAngles;
    }

    //  現在のマウス位置を返すメソッド
    public Vector3 Get_CurrentMousePosition()
    {
        return CurrentMousePosition;
    }

   

    //  マウスの回転
    public Quaternion Mouse_Rotate(Vector3 point)
    {
        //  マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");

        //  pointを中心にy軸回転
        transform.RotateAround(point, Vector3.up, mouseInputX * Time.deltaTime * X_RotationSpeed);    //  RotateAround( 中心とする座標 , 中心とする軸 , 回転角度 )
        
        return transform.rotation;
    }

    //  マウスカーソルの位置を初期化する
    private void MouseCursorFormat()
    {
        Cursor.lockState = CursorLockMode.None; //マウスカーソルの設定を初期化して、
        Cursor.visible = true; //マウスカーソルを表示する
    }

    //  ボタン(キーボード)が押されたら


    /*
    //  向きを計算するメソッド
    public Quaternion Mouse_Rotate(Vector3 playerPos)
    {
        //  マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");

        //  マウスの現在位置とカメラの角度を取得
        CurrentMousePosition = Input.mousePosition;
        CurrentCameraRotation = Camera.main.gameObject.transform.rotation.eulerAngles;

        //  初期位置からの差分算出
        var def = (CurrentMousePosition - StartMousePosition);
        //  回転角度の算出
        CurrentCameraRotation.y = StartCameraRotation.y - (-def.x * Y_RotationSpeed * 0.05f);       //  左右の回転（yのRotation）

        return Quaternion.Euler(CurrentCameraRotation);
    }
    */

}
