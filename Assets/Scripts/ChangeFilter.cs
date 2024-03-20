using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeFilter : MonoBehaviour
{
    public GameObject facePrefab;

    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;
    Renderer meshRenderer;
    public ARFaceManager faceManager;

    private void Start()
    {
        meshRenderer = facePrefab.GetComponent<Renderer>();
    }
    public void chooseGreenFilter()
    {
        var materialsCopy = meshRenderer.materials;
        materialsCopy[0] = greenMaterial;
        meshRenderer.materials = materialsCopy;

        faceManager.enabled = false;
        faceManager.enabled = true;
    }
    public void chooseRedFilter()
    {
        var materialsCopy = meshRenderer.materials;
        materialsCopy[0] = redMaterial;
        meshRenderer.materials = materialsCopy;

        faceManager.enabled = false;
        faceManager.enabled = true;
    }

    public void chooseBlueFilter()
    {
        var materialsCopy = meshRenderer.materials;
        materialsCopy[0] = blueMaterial;
        meshRenderer.materials = materialsCopy;

        faceManager.enabled = false;
        faceManager.enabled = true;
    }
}
