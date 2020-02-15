using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public bool triggered = false;
    [SerializeField] GameObject target;
   
    private void OnTriggerEnter(Collider other)
    { 
        if (target.CompareTag(other.tag))
            triggered = true;      
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}
