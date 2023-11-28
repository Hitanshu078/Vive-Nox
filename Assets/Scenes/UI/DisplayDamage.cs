using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damagecanvas;
    [SerializeField] float splatterTime = 0.3f;
    
    void Start()
    {
        damagecanvas.enabled = false;       
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatterImg());
    }

    IEnumerator ShowSplatterImg()
    {
        damagecanvas.enabled = true;
        yield return new WaitForSeconds(splatterTime);
        damagecanvas.enabled = false;
    }
}