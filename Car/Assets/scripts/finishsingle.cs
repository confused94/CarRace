using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishsingle : MonoBehaviour
{

    GameObject win, lose;
        private void Start()
        {
            win = GameObject.Find("AnaCanvas/sonuc/win").gameObject;
            lose = GameObject.Find("AnaCanvas/sonuc/lose").gameObject;
          

            win.gameObject.SetActive(false);
            lose.gameObject.SetActive(false);
          
        }
        private void OnTriggerEnter(Collider other)
        {

        if (other.gameObject.tag == "rakip")
        {
            lose.gameObject.SetActive(true);
            Invoke("sahnedegis",2);
          
        }
        if(other.gameObject.tag=="Player")
        {
            win.gameObject.SetActive(true);
            Invoke("sahnedegis", 2);
        }

        }
        void sahnedegis()
        {
            SceneManager.LoadScene("mainmenu");
        }
 }


