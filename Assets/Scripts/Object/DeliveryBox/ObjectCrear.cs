using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCrear : MonoBehaviour
{
    [SerializeField] private GameObject BoxPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(BoxPrefab);
    }


}
