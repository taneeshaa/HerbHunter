using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    const float SPEED = 6f;

    [SerializeField]
    Transform SectionInfo;
    [SerializeField] public AudioSource voiceOver;

    Vector3 desiredScale = Vector3.zero;
    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, desiredScale, SPEED * Time.deltaTime);
    }
    public void OpenInfo()
    {
        desiredScale = Vector3.one;
    }
    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
        voiceOver.Play();
    }
}
