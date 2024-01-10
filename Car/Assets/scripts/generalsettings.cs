using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class generalsettings : MonoBehaviour
{
    AudioSource source;
    private static generalsettings settings;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (settings == null)
        {
            settings = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {


        source = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("menuses"))
        {
            source.volume = PlayerPrefs.GetFloat("menuses");
        }
        else
        {
            PlayerPrefs.SetFloat("menuses", 1f);
           
            PlayerPrefs.SetInt("grafik", 2);
        }
            
    }

    void Update()
    {
      
        
    }
   
}
