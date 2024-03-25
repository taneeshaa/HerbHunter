using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadInfo : MonoBehaviour
{
    private GameObject infoPlant;
    public void DisplayInfo()
    {
        var currentObject = GameObject.FindGameObjectWithTag("3DObject");
        infoPlant = currentObject.transform.GetChild(0).gameObject;
        infoPlant.SetActive(true);
    }

}
