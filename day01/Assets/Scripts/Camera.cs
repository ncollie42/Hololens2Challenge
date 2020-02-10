using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject active;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCamParent(0);
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    void getInput()
    {
        //If gets much longer, keycode - UpdateCamParent(49)
        if (Input.GetKey(KeyCode.Alpha1))
        {
            UpdateCamParent(0);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            UpdateCamParent(1);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            UpdateCamParent(2);
        }

    }

    void UpdateCamParent(int index)
    {
        active.GetComponent<player>().active = false;
        active = players[index];
        transform.parent = active.transform;
        var newVec = active.transform.position;
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, newVec.y, newVec.z);
        active.GetComponent<player>().active = true;
    }
}

