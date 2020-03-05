using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class updateScore : MonoBehaviour
{
    [SerializeField] GameObject[] buildings;
    [SerializeField] TextMeshPro text;

    // Update is called once per frame
    void Update()
    {
        text.text = "Buildings left: " + buildingsAlive().ToString();
    }

    int buildingsAlive()
    {
        int num = 0;
        foreach (GameObject building in buildings)
        {
            if (building.activeSelf)
                num++;
        }
        return num;
    }
}
