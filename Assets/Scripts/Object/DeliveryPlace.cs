using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPlace : MonoBehaviour
{
    [SerializeField] GameObject DeliveryObject;
    [SerializeField] SceneController SceneController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    { 
        if(collider.gameObject.tag=="BoxPrefab")
        {
            SceneController.ChangeGameEndScene();
        }
    }
}
