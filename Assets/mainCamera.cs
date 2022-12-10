using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    public AudioClip mainClip;
    private void Start()
    {
        mainClip = gameObject.GetComponent<AudioListener>().GetComponent(AudioClip);
    }

}
