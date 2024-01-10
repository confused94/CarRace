using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caraudiocontrol : MonoBehaviour
{
    
    [SerializeField] AudioSource sesKaynagi;
    [SerializeField] float minSpeed = 0f; // Minimum hýz
    [SerializeField] float maxSpeed = 150f; // Maksimum hýz
    [SerializeField] float minPitch = 0.5f; // Minimum pitch deðeri
    [SerializeField] float maxPitch = 3.0f; // Maksimum pitch deðeri
    playercontroller pc;
    private void Start()
    {
       
        pc=GetComponent<playercontroller>();
    }

    private void Update()
    {
   
        float speed = Mathf.InverseLerp(minSpeed, maxSpeed, pc.hiz);
        float pitch = Mathf.Lerp(minPitch, maxPitch, speed);
        sesKaynagi.pitch = pitch;
        //int sesIndex = Mathf.Clamp(Mathf.FloorToInt(speed * sesler.Length), 0, sesler.Length - 1);
        //sesKaynagi.clip = sesler[sesIndex];
        if (!sesKaynagi.isPlaying)
        {
            sesKaynagi.Play();
        }
    }
}

       

       

     

       
