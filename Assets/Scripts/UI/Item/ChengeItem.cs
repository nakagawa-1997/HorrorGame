using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ChengeItem;

public class ChengeItem : MonoBehaviour
{
    [SerializeField] private GameObject ItemPos;
    [SerializeField] private GameObject ItemInfo;

    int ItemPrefabLength;

    //  �擾�����A�C�e���̃^�O��������
    private string[] itemTag;
    private int count;
    private GameObject[] tagObjs;
    

    //  ���ݏ������Ă���A�C�e��
    private int currentItem;


    //  �A�C�e����ԁ@�r�b�g�t���O�@���A�C�e���v���n�u�̒��g�ƑΉ������ォ�珇�Ԃɖ��O�����邱��
    [Flags]
    public enum PlayerItem
    {
        Free = 1 << 0,     //  0000 0001
        Light = 1 << 1,      //  0000 0010
        Key = 1 << 2,      //  0000 0100
        Memo = 1 << 3
    }


    // Start is called before the first frame update
    void Start()
    {
        //  �����Ăяo����悤�ɏꏊ�������Ă���
        ItemInfo = GameObject.Find("ItemInfo");

        //  �A�C�e���z��̒�����n���Ă���
        ItemPrefabLength = ItemInfo.GetComponent<ItemPrefabInfo>().Get_ItemMaxNum();

        itemTag = new string[ItemPrefabLength];
        tagObjs = new GameObject[ItemPrefabLength];
    }

    // Update is called once per frame
    void Update()
    {
        ItemChange();
    }

    void ItemChange()
    {
        //  �}�E�X�z�C�[���̈ړ��ʎ擾
        float wheel = Input.GetAxis("Mouse ScrollWheel");

        //  �e�A�C�e�����Ƃɕ\�����镨��؂�ւ�
        ItemJug(wheel);

        Debug.Log(currentItem);

    }

    /// <summary>
    /// �I�����ꂽ�A�C�e���̖��O��Ԃ�
    /// </summary>
    /// <param name="wheel"></param>
    /// <returns></returns>
    void ItemJug(float wheel)
    {
        if (wheel > 0)
        {
            currentItem = (currentItem + 1) % ItemPrefabLength;

            for (int i = 0; i < ItemPrefabLength; i++)
            {
                if (i == currentItem)
                {
                    //  �I�u�W�F�N�g�̕\��
                    tagObjs[i].SetActive(true);
                }
                else
                {
                    //  �I�u�W�F�N�g���\��
                    tagObjs[i].SetActive(false);
                }
            }
        }
        else if (wheel < 0)
        {
            currentItem = (currentItem - 1) % ItemPrefabLength;
            if (currentItem < 0)
            {
                currentItem = 3;
            }

            for (int i = 0; i < ItemPrefabLength; i++)
            {
                if (i == currentItem)
                {
                    //  �I�u�W�F�N�g��\��
                    tagObjs[i].SetActive(true);
                }
                else
                {
                    //  �I�u�W�F�N�g���\��
                    tagObjs[i].SetActive(false);
                }
            }
        }

    }

    /*
    public PlayerItem GetItemActivMode()
    {
        PlayerItem itemName = PlayerItem.Free;
        int ItemNo;

        for (int i = 0; i < ItemPrefab.Length; i++)
        {
            if (i == currentItem)
            {
                //  int�^��enum�^�ɕύX���邽�߂̍��
                ItemNo = 1 << i;
                itemName = (PlayerItem)Enum.ToObject(typeof(PlayerItem), ItemNo);
            }
        }

        return itemName;
    }
    */

    public string GetItemActiveTagName()
    {
        string itemTagName = "hand";

        for (int i = 0; i < ItemPrefabLength; i++)
        {
            if (i == currentItem)
            {
                //  int�^��enum�^�ɕύX���邽�߂̍��
                itemTagName = ItemInfo.GetComponent<ItemPrefabInfo>().Get_ItemTag(i);
            }
        }

        return itemTagName;
    }

    //  �A�C�e���̃^�O��n��
    public void ItemTag(string tagName)
    {
        for (int i = 0; i < itemTag.Length; i++)
        {
            if (itemTag[i]==null)
            {
                itemTag[i] = tagName;
                //  tag��GameObject��������
                tagObjs[i]=GameObject.Find(tagName);
            }
        }
    }

    //  �^�O�z��̏�����
    public void ItemChengeInit(int ItemMaxNum)
    {
        currentItem = 0;
        for (int i = 0; i < ItemMaxNum; i++)
        {
            if (i == currentItem)
            {
                //ItemInfo.GetComponent<ItemPrefabInfo>().Object_SetActiveTrue(i);
                tagObjs[i].SetActive(true);
            }
            else
            {
                //ItemInfo.GetComponent<ItemPrefabInfo>().Object_SetActiveFalse(i);
                tagObjs[i].SetActive(false);
            }
        }

        //  �z�C�[���̔z��錾
        itemTag = new string[ItemPrefabLength];
        itemTag[0] = "hand";
    }

}
