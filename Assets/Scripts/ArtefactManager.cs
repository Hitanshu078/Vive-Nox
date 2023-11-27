using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactManager : MonoBehaviour
{

    int collectedArtefacts = 0;
    [SerializeField] GameObject[] artefacts;

    // Start is called before the first frame update
    void Start()
    {
        collectedArtefacts = LoadLevel();
        Debug.Log("Curr Collected: " + collectedArtefacts);
        SetArtefactActive(collectedArtefacts);
    }

    void SetArtefactActive(int x) 
    {
        Debug.Log("I'm told to set this active: " + x);
        if (x >= 4) return;

        if (x >= 1)
            artefacts[x].SetActive(true);
        else
            artefacts[0].SetActive(true);
    }

    public void IncreaseArtefacts() 
    {
        if (collectedArtefacts >= 4) return; // GAME SHOULD END 
        collectedArtefacts++;
     
        Debug.Log("collectedArtefacts : " + collectedArtefacts);

        PlayerPrefs.SetInt("A", collectedArtefacts);
        PlayerPrefs.Save();
        SetArtefactActive(collectedArtefacts);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            PlayerPrefs.DeleteAll();
        }
    }

    int LoadLevel() 
    {
       return PlayerPrefs.GetInt("A", 0);
    }
}
