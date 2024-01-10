using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;

public class carspawn : MonoBehaviour
{
    [SerializeField] Transform olusmanoktasi;
    [SerializeField] GameObject[] cars;
    [SerializeField] GameObject yapayzeka;
    Transform olusmanoktasi2;
    GameObject player2cam,yapayzekanoktasi;
    [SerializeField] Button btn;
    bool menukontrol;
   


    //[SerializeField] GameObject yapayzeka,yapayzekanoktasi;
   
    void Start()
    {
        Destroy(GameObject.Find("settings").gameObject);
        //--------oyuncu oluþturma------------
        if (PlayerPrefs.GetInt("kisi")==2)
        {
            olusmanoktasi2 = GameObject.Find("olusmanoktasi2").gameObject.transform;
            GameObject player1 = Instantiate(cars[PlayerPrefs.GetInt("carvalue1")], olusmanoktasi.position, olusmanoktasi.rotation);
            GameObject player2 = Instantiate(cars[PlayerPrefs.GetInt("carvalue2")], olusmanoktasi2.position, olusmanoktasi2.rotation);
            //GameObject.Find("Main Camera").GetComponent<cameracontroller>().noktalar[0] = odak;
            Camera.main.GetComponent<cameracontroller>().noktalar[0] = player1.transform.Find("odak");
            Camera.main.GetComponent<cameracontroller>().noktalar[1] = player1.transform.Find("takip");
            player2cam = GameObject.Find("player2cam").gameObject;
            player2cam.GetComponent<cameracontroller>().noktalar[0] = player2.transform.Find("odak");
            player2cam.GetComponent<cameracontroller>().noktalar[1] = player2.transform.Find("takip");
            player2.GetComponent<playercontroller>().enabled = false;
            player1.GetComponent<playercontroller2>().enabled = false;
        }
        else
        {
            yapayzekanoktasi = GameObject.Find("yapayzekaolusmanoktasi");
            GameObject player1 = Instantiate(cars[PlayerPrefs.GetInt("carvalue1")], olusmanoktasi.position, olusmanoktasi.rotation);
            player1.GetComponent<playercontroller2>().enabled = false;
            Camera.main.GetComponent<cameracontroller>().noktalar[0] = player1.transform.Find("odak");
            Camera.main.GetComponent<cameracontroller>().noktalar[1] = player1.transform.Find("takip");
            GameObject.Find("GameManager").GetComponent<cameraswitch>().cams[1] = player1.transform.Find("cams/Camera").gameObject;
            GameObject aicar = Instantiate(yapayzeka, yapayzekanoktasi.transform.position, yapayzeka.transform.rotation);
            aicar.GetComponent<WaypointProgressTracker>().circuit = GameObject.Find("point").GetComponent<WaypointCircuit>();
        }
       
        
        
       




    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menukontrol = !menukontrol;
            if (menukontrol)
            {
                Time.timeScale = 0;
                btn.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                btn.gameObject.SetActive(false);
            }
        }
    }
    public void menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }


}
