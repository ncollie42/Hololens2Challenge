using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class powerBar : MonoBehaviour
{
    public Slider slider;
    bool positive = true;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            var tmp = Time.deltaTime * 3;
            slider.value += (positive ? tmp : -tmp);
            if (slider.value == 10)
                positive = false;
            else if (slider.value == 0)
                positive = true;
        }
        else
            slider.value = 0;
    }
}
