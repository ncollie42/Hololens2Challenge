using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackable : MonoBehaviour
{

    unitControl unitControl;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("unitControl"))
            unitControl = GameObject.Find("unitControl").GetComponent<unitControl>();
    }

    public void AttackMe()
    {
        unitControl.attackSelected(transform.gameObject);
    }
}
