using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenemanager : MonoBehaviour
{
    [SerializeField] Animator animator;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void sahne1()
    {
        animator.SetTrigger("karartma");
        PlayerPrefs.SetInt("kisi",1);
        SceneManager.LoadScene("secim");
    }
    public void sahne2()
    {
        animator.SetTrigger("karartma");
        PlayerPrefs.SetInt("kisi", 2);
        SceneManager.LoadScene("secim");
    }

    public void ayarlar()
    {
        animator.SetTrigger("karartma");
        SceneManager.LoadScene("ayarlar");
    }






    public void cikis()
    {
        Application.Quit();        
    }
}
