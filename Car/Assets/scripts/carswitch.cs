using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class carswitch : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] TextMeshProUGUI carname, p1txt, p2txt;
    [SerializeField] ParticleSystem ps;
    [SerializeField] Button secim, hazir;
    int idx;
    int selectcounter;
    void Start()
    {
        selectcounter = 0;
        idx = 0;
        cars[idx].SetActive(true);
        carname.text = cars[idx].GetComponent<carsinfo>().name;
    }

    void Update()
    {

    }
    public void Ileri()
    {
        if (idx != cars.Length - 1)
        {
            cars[idx].SetActive(false);
            idx++;
            cars[idx].SetActive(true);
            carname.text = cars[idx].GetComponent<carsinfo>().name;
            ps.Play();
        }
        else
        {
            cars[idx].SetActive(false);
            idx = 0;
            cars[idx].SetActive(true);
            carname.text = cars[idx].GetComponent<carsinfo>().name;
            ps.Play();
        }

    }
    public void Geri()
    {
        if (idx != 0)
        {
            cars[idx].SetActive(false);
            idx--;
            cars[idx].SetActive(true);
            carname.text = cars[idx].GetComponent<carsinfo>().name;
            ps.Play();

        }
        else
        {
            cars[idx].SetActive(false);
            idx = cars.Length - 1;
            cars[idx].SetActive(true);
            carname.text = cars[idx].GetComponent<carsinfo>().name;
            ps.Play();

        }
    }
    public void Secim()
    {
        switch (PlayerPrefs.GetInt("kisi"))
        {
            case 1:
                {
                    PlayerPrefs.SetInt("carvalue1", idx);
                    secim.gameObject.SetActive(false);
                    hazir.gameObject.SetActive(true);
                   
                    break;
                }

           case 2:
                {
                   
                    selectcounter++;
                    if (selectcounter == 1)
                    {
                        PlayerPrefs.SetInt("carvalue1", idx);
                        p1txt.text = "Player 1:" + cars[idx].name;
                    }
                    if (selectcounter == 2)
                    {
                        PlayerPrefs.SetInt("carvalue2", idx);
                        secim.gameObject.SetActive(false);
                        hazir.gameObject.SetActive(true);
                        p2txt.text = "Player 2:" + cars[idx].name;
                    }
                    break;
                }
        }
    }
    public void sahne()
    {
        if(selectcounter==0)
        {
            SceneManager.LoadScene("singlescene");
        }
        else
        {
            SceneManager.LoadScene("splitscene");
        }
    }
    public void menu()
    {
        SceneManager.LoadScene("mainmenu");
    }

}
