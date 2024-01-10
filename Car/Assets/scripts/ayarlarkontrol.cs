using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ayarlarkontrol : MonoBehaviour
{
    [SerializeField] Slider menuses_seviye;
    [SerializeField] TMP_Dropdown grafik_seviye;
    AudioSource seskaynak;
    void Start()
    {

        seskaynak = GameObject.Find("settings").GetComponent<AudioSource>();

        menuses_seviye.value = PlayerPrefs.GetFloat("menuses");
        grafik_seviye.value = PlayerPrefs.GetInt("grafik");
       
        
    }
    public void Menusesdegisiklik()
    {
        PlayerPrefs.SetFloat("menuses", menuses_seviye.value);
        seskaynak.volume = menuses_seviye.value;
        Debug.Log(seskaynak.name);

    }
    
    public void grafikdegisim(int secilendeger)
    {
        PlayerPrefs.SetInt("grafik", secilendeger);
        grafik_seviye.value= secilendeger;
        QualitySettings.SetQualityLevel(secilendeger);
    }
    public void menu()
    {
       SceneManager.LoadScene("mainmenu");
    }
}
