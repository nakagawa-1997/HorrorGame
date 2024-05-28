using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraPos : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position=Camera.main.transform.position;
        this.gameObject.transform.rotation=Camera.main.transform.rotation;
    }
}
