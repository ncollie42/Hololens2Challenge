using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var sound = GetComponent<AudioSource>();
        if (!sound.isPlaying)
            sound.Play();
    }
}
