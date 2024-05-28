using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 2.0f;        //  移動速度
    [SerializeField] float crouchHeight_YScale = 0.7f;

    private float CurrentV = 0;
    private float CurrentH = 0;

    private float Interpolation = 100.0f;            //  補間
    PlayerMode CurrentPlyMode;

    Rigidbody rb;

    GameObject InputController;
    GameObject mainCamera;

    //  しゃがみの高さ
    Vector3 crouchHeight;

    //  移動　ビットフラグ
    [Flags]
    private enum PlayerMode
    {
        Wark = 1 << 0,     //  0000 0001
        Run = 1 << 1,      //  0000 0010
        Crouch = 1 << 2,      //  0000 0100
        Hide = 1 << 3,     //  0000 1000
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InputController = GameObject.Find("InputController");
        mainCamera = GameObject.Find("Main Camera");

        CurrentPlyMode = PlayerMode.Wark;
        crouchHeight = new Vector3(0.0f, crouchHeight_YScale, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        //  しゃがみ追加
        Crouch();

        Debug.Log(CurrentPlyMode);
    }

    //  プレイヤー移動メソッド
    private void MoveUpdate()
    {
        float moveSpeed;
        //  キー入力受け取り
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        CurrentPlyMode = PlayerModeChange();

        //  移動を滑らかにする？やつっぽい
        CurrentV = Mathf.Lerp(CurrentV, v, Time.deltaTime * Interpolation);
        CurrentH = Mathf.Lerp(CurrentH, h, Time.deltaTime * Interpolation);

        moveSpeed = Mode_SpeedChenge(MoveSpeed);
        Debug.Log(moveSpeed);

        //  移動
        transform.position += transform.forward * CurrentV * moveSpeed * Time.deltaTime;
        transform.position += transform.right * CurrentH * moveSpeed * Time.deltaTime;

        //  向き受け渡し
        //this.gameObject.transform.rotation = InputController.GetComponent<InputController>().Mouse_Rotate(this.transform.position);
        this.gameObject.transform.localEulerAngles = mainCamera.GetComponent<CameraConntroller>().Camera_GetRotate_Y();
    }

    //  プレイヤーアニメーションメソッド

    

    //  プレイヤーのposition渡し
    public Vector3 GetPlayerPosition() 
    {
        return this.transform.position; 
    }

    //  プレイヤーしゃがみ
    void Crouch()
    {
        Vector3 croHeiScale = gameObject.transform.localScale;
        //  キーはファスモフォビア参考
        if (Input.GetKeyDown(KeyCode.C))
        {
            //this.gameObject.transform.position -= crouchHeight;
            croHeiScale -= crouchHeight;
            this.gameObject.transform.localScale = croHeiScale;
        }
        if(Input.GetKeyUp(KeyCode.C))
        {
            //this.gameObject.transform.position += crouchHeight;
            croHeiScale += crouchHeight;
            this.gameObject.transform.localScale = croHeiScale;
        }
    }

    PlayerMode PlayerModeChange()
    {
        PlayerMode plyMode;
        
        if (Input.GetKey(KeyCode.C))       // しゃがむ状態
        {
            plyMode = PlayerMode.Crouch;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))            //  走る状態
        {
            plyMode = PlayerMode.Run;
        }
        else if(Input.GetKey(KeyCode.F))        //   隠れる状態(決定キー？)
        {
            plyMode =PlayerMode.Hide;
        }
        else　　　　　　　　　　　　　　　　　　　　//  歩く状態
        {
            plyMode = PlayerMode.Wark;         
        }

        return plyMode;
    }

    //  プレイヤーの状態によってスピードを変化させる
    float Mode_SpeedChenge(float moveSpeed)
    {
        float speed = moveSpeed;
        switch (CurrentPlyMode)
        {
            case PlayerMode.Wark:
                speed *= 1;
                break;
            case PlayerMode.Run:
                speed *= 2;
                break;
            case PlayerMode.Crouch:
                speed /= 2;
                break;
            case PlayerMode.Hide:
                speed = 0;
                break;
            default:
                break;
        }

        return speed;
    }

}
