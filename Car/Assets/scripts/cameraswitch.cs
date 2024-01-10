using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour
{
    public GameObject[] cams;
    int cams_value;
     void Start()
    {
        cams_value = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            CloseCams();
            cams_value++;

            if (cams_value >= cams.Length)
            {
                cams_value = 0;
            }
        }
        cams[cams_value].gameObject.SetActive(true);
    }
    private void CloseCams()
    {
        
        foreach (var item in cams)
        {
            item.SetActive(false);
        }
    }
    
   
}
