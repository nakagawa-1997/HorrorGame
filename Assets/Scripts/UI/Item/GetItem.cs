//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class GetItem : MonoBehaviour
{
    [SerializeField] private Collider[] ItemAvailableColl;  //  �擾�\ / �擾�����𖞂����I�u�W�F�N�g
    [SerializeField] private float RayMaxDistance = 100.0f;

    [SerializeField] GameObject ItemController;

    [SerializeField] GameObject ItemParent;
    [SerializeField] GameObject[] ItemPrefab;

    private bool[] itemExists;
    private GameObject[] ObtainedItem;

    private void Start()
    {
        //  gameobject�̒��g��n�����n����悤�R�Â��Ă���
        ItemController = GameObject.Find("ItemController");

        for (int i = 0; i < ItemAvailableColl.Length; i++)
        {
            ItemAvailableColl[i].GetComponent<Collider>();
        }


        //  ���Y����A�C�e���z��̒�����n��
        itemExists = new bool[ItemPrefab.Length];
        for (int i = 0;i < ItemPrefab.Length;i++)
        {
            itemExists[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  ���C���J�����̈ʒu
        Vector3 rayOriginPos = Camera.main.transform.position;

        //  Raycast���΂�����(main�̃J�����������Ă������)
        Vector3 rayDestPos= Camera.main.transform.forward;


        //  �}�E�X�����N���b�N�������Ray���΂�
        if (Input.GetMouseButton(0))
        {
            //  Ray���쐬
            Ray ray = new Ray(rayOriginPos, rayDestPos);
            //  Ray�̏Փ˔���I�u�W�F�N�g
            RaycastHit hit;

            for (int i = 0; i < ItemAvailableColl.Length; i++)
            {
                //  Ray�̒��������߂āA���܂����s�������H
                if (ItemAvailableColl[i].Raycast(ray, out hit, RayMaxDistance))
                {
                    transform.position = ray.GetPoint(RayMaxDistance);

                    //  �I�u�W�F�N�g�ʂɍs������������̂Ɂw hit.collider.tag == "����" �x�̂悤�� tag �Ŕ��肷�邱�Ƃ��\
                    if (hit.collider.tag == "red")
                    {
                        Debug.Log("�ԐF�̔���G����");

                        //  �A�C�e���̃^�O�Ő��Y����A�C�e���𔻕ʂ���
                        ProcessByItem("key");
                    }
                    if (hit.collider.tag == "yellow")
                    {
                        Debug.Log("���F�̔���G����");

                        //  �A�C�e���̃^�O�Ő��Y����A�C�e���𔻕ʂ���
                        ProcessByItem("memo");
                    }
                    if (hit.collider.tag == "blue")
                    {
                        Debug.Log("�F�̔���G����");

                        //  �A�C�e���̃^�O�Ő��Y����A�C�e���𔻕ʂ���
                        ProcessByItem("flashLight");
                    }
                }
            }

            //  Ray��\��
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }

    }

    //  �A�C�e���擾��̓���(���Y�̂�)
    void ItemProduction(GameObject Prefab)
    {
        //  �z��Őݒ肵���A�C�e���𐶎Y����
        GameObject item = Instantiate(Prefab, ItemParent.transform.position, Quaternion.identity);

        //  �e�I�u�W�F�N�g�̎w��H
        item.transform.parent = ItemParent.transform;
    }

    //  �A�C�e���擾��̓���(�S��)
    void ProcessByItem(string PrefabTagName)
    {
        //  �A�C�e���̃^�O�Ő��Y����A�C�e���𔻕ʂ���
        for (int j = 0; j < ItemPrefab.Length; j++)
        {
            if (itemExists[j] == false)
            {
                if (ItemPrefab[j].tag == PrefabTagName)
                {
                    //  �A�C�e�����Y�i���Y�ꏊ��UI�J�����̎q�I�u�W�F�N�g�ɂ���H�j
                    ItemProduction(ItemPrefab[j]);
                    itemExists[j] = true;
                    Debug.Log(PrefabTagName + "�����Y����܂���");
                }
                else
                {
                    Debug.Log(PrefabTagName + "�Ƃ����^�O���͌�����܂���");
                }
            }
            else
            {
                Debug.Log(PrefabTagName + "�͊��ɐ��Y����Ă��܂�");
            }
        }
    }
}
