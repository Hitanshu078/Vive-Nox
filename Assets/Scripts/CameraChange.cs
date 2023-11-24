using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    [SerializeField] GameObject Weapon;
    int CamMode = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Camera")){
            if(CamMode == 1){
                CamMode = 0;
            }
            else{
                CamMode +=1;
            }
            StartCoroutine(Camchange ());
        }    
        if(Input.GetButtonDown("Shoot")){
            CamMode = 1;
            StartCoroutine(Camchange());
            if(Input.GetButtonDown("Camera")){
            if(CamMode == 1){
                CamMode = 0;
            }
            else{
                CamMode +=1;
            }
            StartCoroutine(Camchange ());
        }    
        }
    }

    IEnumerator Camchange(){
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0){
            ThirdCam.SetActive(true);
            FirstCam.SetActive (false);
            Weapon.SetActive(false);
        }
        if (CamMode == 1){
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
            Weapon.SetActive(true);
        }
    }
}
