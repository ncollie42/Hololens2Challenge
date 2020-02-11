using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public bool triggered = false;
    [SerializeField] GameObject target;
   
    private void OnTriggerEnter(Collider other)
    { 
        //if (!target)
        //    return;

        //Debug.Log("Target: " + target+ "   Other:" + other);
        

        //Debug.Log(other.gameObject.tag + tag + target.tag);
        //Debug.Log(other.gameObject.CompareTag(target.tag));
        //if (other.gameObject.CompareTag(target.tag))


        if (target.CompareTag(other.tag))
            triggered = true;
        Debug.Log("Good");
        //}
      
    }

    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }
}
