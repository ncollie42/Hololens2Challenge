using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] float inninertia = 0;
    int holeLocation = 16;
    int direction = 1;
    // Start is called before the first frame update
    GameObject club;

    void Start()
    {
        club = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (inninertia > 0)
        {
            if (transform.position.y > 18)
                direction *= -1;
            if (transform.position.y <= 0)
                direction *= -1;
            transform.Translate(Vector3.up * direction * Time.deltaTime * 1.5f * inninertia);
            inninertia--;
        }
        if (inninertia < 0)
            inninertia = 0;
        if (inninertia == 0 && club.activeSelf == false)
            club.SetActive(true);
        else if (inninertia != 0)
            club.SetActive(false);
        if (Mathf.FloorToInt(transform.position.y) == holeLocation && inninertia < 5)
        {
            gameObject.SetActive(false);
        }
   
    }
    public void Hit(float amount)
    {
        inninertia = amount;
    }
}
