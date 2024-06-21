using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefabInfo : MonoBehaviour
{
    //  �f�U�C���p�^�[���@�V���O���g���ɂ���
    //  �A�C�e���I�u�W�F�N�g�̔z��������ɍ��i�N���X�H�C���X�^���X��������j
    [SerializeField] GameObject[] ItemPrefab;

    //  �������ł��邱��
    //  �A�C�e���̏���n������A�����������肷��֐��������ō���ĕʂ̃X�N���v�g�ŌĂяo��
    //  ������ Update �Ȃ��̌Ăяo����p�X�N���v�g�Ƃ��Ĉ���

    //  �z��̒�����n���֐�
    public int Get_ItemMaxNum()
    {
        return ItemPrefab.Length;
    }

    //  �z��̃^�O��n���֐�
    public string Get_ItemTag(int i)
    {
        return ItemPrefab[i].tag;
    }

    //  �v���n�u���̂��̂̏���n���֐�
    public GameObject Get_Prefab(int i)
    {
        return ItemPrefab[i];
    }

    //  �I�u�W�F�N�g�̕\��/��\����؂�ւ���֐�
    public void Object_SetActiveTrue(int i)     //  �\��
    {
        ItemPrefab[i].SetActive(true);
    }
    public void Object_SetActiveFalse(int i)    //  ��\��
    {
        ItemPrefab[i].SetActive(false);
    }

}
