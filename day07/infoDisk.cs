using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoDisk : MonoBehaviour
{
    [SerializeField] Material yellow;
    [SerializeField] Material green;
    [SerializeField] GameObject disk;
    Renderer renderer;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        renderer = disk.GetComponent<Renderer>();
    }
    
    public void disableDisk()
    {
        isActive = false;
        disk.SetActive(false);
    }

    public void hoverOn()
    {
        if (!isActive)
            disk.SetActive(true);
        renderer.material = yellow;
    }

    public void hoverOff()
    {
        if (isActive)
            renderer.material = green;
        else
            disk.SetActive(false);
    }
}
