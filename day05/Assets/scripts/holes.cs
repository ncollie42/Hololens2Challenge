using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holes : MonoBehaviour
{
    [SerializeField] GameObject main;
    main mainscript;
    // Start is called before the first frame update
    void Start()
    {
        mainscript = main.GetComponent<main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            Debug.Log("Made it to the hole"); //Call next
            mainscript.nextLevel();
        }
         
    }
}
