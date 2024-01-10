using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform[] noktalar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = noktalar[1].position;
        transform.LookAt(noktalar[0].position);
    }
}
