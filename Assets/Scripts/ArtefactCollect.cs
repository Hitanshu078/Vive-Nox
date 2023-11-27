using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactCollect : MonoBehaviour
{
    ArtefactManager artefactManager;

    // Start is called before the first frame update
    void Start()
    {
        artefactManager = GameObject.FindGameObjectWithTag("ArtefactMan").GetComponent<ArtefactManager>();    
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            artefactManager.IncreaseArtefacts();
            Destroy(gameObject, 0.1f);
            //MAYBE PLAY SOME SFX AND VFX
        }
    }


}
