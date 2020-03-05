using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
public class unitControl : MonoBehaviour
{
    //player controller
    [SerializeField] List<unit> selected = new List<unit>();

    /*public void selectAll()
    {
        clearSelected();
        GameObject[] allUnits = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject curent in allUnits)
        {
            addUnit(curent.GetComponent<unit>());
        }
    }*/
    public void addUnit(unit curent)
    {
        if (selected.Contains(curent))
        {
            selected.Remove(curent);
            curent.GetComponent<infoDisk>().isActive = false;
        }
        else
        {
            selected.Add(curent);
            curent.GetComponent<infoDisk>().isActive = true;
        }
            
    }

    public void moveSelected(MixedRealityPointerEventData eventData)
    {
        Vector3 point = eventData.Pointer.Result.Details.Point;

        foreach (unit curent in selected)
        {
            curent.move(point);
        }
        Debug.Log("moving units to " + point);
      }


    void clearSelected()
    {
        foreach (unit curent in selected)
        {
            selected.Remove(curent);
            curent.GetComponent<infoDisk>().disableDisk();
        }
    }

    public void attackSelected(GameObject target)
    {
        foreach (unit curent in selected)
        {
            curent.attack(target);
        }
        clearSelected();
        Debug.Log("attacking stuff");
    }
}
