using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishscript : MonoBehaviour
{
    GameObject win, lose,win2,lose2;
    private void Start()
    {
        win=GameObject.Find("AnaCanvas/sonuc/win").gameObject;
        lose= GameObject.Find("AnaCanvas/sonuc/lose").gameObject;
        win2 = GameObject.Find("AnaCanvas2/sonuc/win").gameObject;
        lose2 = GameObject.Find("AnaCanvas2/sonuc/lose").gameObject;

        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        win2.gameObject.SetActive(false);
        lose2.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
      if(other.GetComponentInParent<playercontroller>().isActiveAndEnabled) 
        {
            win.gameObject.SetActive(true);
            lose2.gameObject.SetActive(true);
            Invoke("sahnedegis", 3);
        }
        else
        {
            win2.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
            Invoke("sahnedegis", 3);
        }
      
    }
    void sahnedegis()
    {
        SceneManager.LoadScene("arabasecim");
    }
}
