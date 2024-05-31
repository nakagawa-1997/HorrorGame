using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] private Collider[] ItemAvailableColl;  //  �擾�\ / �擾�����𖞂����ȃI�u�W�F�N�g
    [SerializeField] private float RayMaxDistance = 100.0f;

    private void Start()
    {
        for (int i = 0; i < ItemAvailableColl.Length; i++)
        {
            ItemAvailableColl[i].GetComponent<Collider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        RaycastHit hit;

        for (int i = 0;i < ItemAvailableColl.Length;i++)
        {
            //  Ray�̒��������߂āA���܂����s�������H
            if (ItemAvailableColl[i].Raycast(ray, out hit, RayMaxDistance))
            {
                transform.position = ray.GetPoint(RayMaxDistance);
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
                Debug.Log("RayIsGetCollider");
            }
        }
    }
}
