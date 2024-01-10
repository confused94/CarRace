using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class playercontroller : MonoBehaviour
{
    //field's
    #region
    [SerializeField] GameObject mesh1, mesh2, mesh3, mesh4;
    [SerializeField] WheelCollider col1, col2, col3, col4;
    [SerializeField] float tork;
    [SerializeField] Transform isinnoktasi;
    [SerializeField] Light[] lights;
    [SerializeField] Light[] front_light;
    [SerializeField] int max_hiz;
    GameObject tersyon;
    Text vitestxt;
    Text hiztxt;
    
    GameObject kadran;
    [SerializeField] ParticleSystem[] dumanlar, patlama;
    [SerializeField] AudioSource vitessesi;
    [SerializeField] float maxAci;
    [SerializeField] float donusHassasiyeti;
    
    private int vites;
    private int vitessayisi = 5;
    Rigidbody rb;
    bool islight;
    float aci;
    int isinnoktasayisi;

    [SerializeField] Vector3 centerOfMass;
    public float hiz;
   
    Quaternion quat1;
    bool isbrake;
    float braking;
    #endregion
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass; 
        rb= GetComponent<Rigidbody>();
        kadran = GameObject.FindWithTag("kadrantag").gameObject;
        hiztxt = GameObject.FindWithTag("kphtag").GetComponent<Text>();
        vitestxt = GameObject.FindWithTag("vitestag").GetComponent<Text>();
        tersyon = GameObject.FindWithTag("tersyontag").gameObject;
        tersyon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carcontroller();
        gearchanging();
        wheelsteer(mesh1, col1);
        wheelsteer(mesh2, col2);
        wheelsteer(mesh3, col3);
        wheelsteer(mesh4, col4);
        speedometer();
        frontlight();
        RaycastHit hit;
        if (Physics.Raycast(isinnoktasi.position, isinnoktasi.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.CompareTag("ilerinokta"))
            {
                if (isinnoktasayisi>Int16.Parse(hit.transform.gameObject.name))
                {
                    tersyon.gameObject.SetActive(true);
                    
                    
                }
                else
                {
                    isinnoktasayisi = Int16.Parse(hit.transform.gameObject.name);
                    
                    tersyon.gameObject.SetActive(false);
                }
            }


            Debug.DrawRay(isinnoktasi.position, isinnoktasi.TransformDirection(Vector3.forward)*hit.distance, Color.green);

        }
        
        
    }
    void frontlight()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            islight = !islight;
            //front_light[0].gameObject.SetActive(islight);
            //front_light[1].gameObject.SetActive(islight);
            front_light[0].GetComponent<Light>().enabled= islight;
            front_light[1].GetComponent<Light>().enabled = islight;
        }
    }
    void speedometer()
    {
        if (hiz == 0)
        {
            Quaternion kadranacisi = Quaternion.Euler(new Vector3(0, 0, 0));
            kadran.transform.localRotation = kadranacisi;
        }
        else
        {
            Quaternion kadranacisi = Quaternion.Euler(new Vector3(0, 0, -hiz * 1.4f));
            kadran.transform.localRotation = kadranacisi;
        }
    }
    private void carcontroller()
    {
        hiz = rb.velocity.magnitude * 3.6f;
        
        hiztxt.text=hiz.ToString("0");
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        if (hiz < max_hiz)
        {

            if (Input.GetKey(KeyCode.RightShift))
            {
            
                foreach (var item in lights)
                {
                    item.GetComponent<Light>().intensity = 30;
                }
                isbrake = true;

            }
            else
            {

                foreach (var item in lights)
                {
                    item.GetComponent<Light>().intensity = 5;
                }
                isbrake = false;

            }
        }
        else
        {
            isbrake = true;
        }
        if (hiz > 10)
        {
            foreach (var item in dumanlar)
            {
                //var mains = item.main;
                //mains.loop = true;
                item.Stop();
            }
        }
       
        
        braking = isbrake ? 80000 : 0;
        col3.motorTorque = max_hiz*tork * dikey;
        col4.motorTorque = max_hiz * tork * dikey;
       
       
        aci = maxAci * yatay * donusHassasiyeti;

        col1.steerAngle = Mathf.Lerp(col1.steerAngle, aci, 0.6f);
        col2.steerAngle= Mathf.Lerp(col2.steerAngle, aci, 0.6f);

        col3.brakeTorque = braking;
        col4.brakeTorque = braking;
        col1.brakeTorque = braking;
        col2.brakeTorque = braking;

        quat1 = new Quaternion(0, aci * yatay * Time.deltaTime, 0, 0);



    }
    void wheelsteer(GameObject mesh,WheelCollider col)
    {
        Vector3 pos;
        

        col.GetWorldPose(out pos, out quat1);
        mesh.transform.position = pos;
        //mesh.transform.rotation = Quaternion.Lerp(quat,quat1,.1f);
        mesh.transform.rotation = quat1;
    }
    void gearchanging()
    {
        
        float f=Mathf.Abs(hiz / max_hiz);
        float yuksekvites = (1 / (float)vitessayisi) * (vites + 1);
        float dusukvites = (1 / (float)vitessayisi) * vites;
        
        
        if (f > yuksekvites && vites < (vitessayisi - 1))
        {
            vites++;
            vitestxt.text = (vites+1).ToString();
            foreach(var item in patlama)
            {
                item.Play();
            }
            vitessesi.Play();
            
        }
        if (f < dusukvites && vites > 0)
        {
            vites--;
            vitestxt.text = vites.ToString();

        }
    }
  
}

