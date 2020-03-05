using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    health hp;
    [SerializeField] GameObject container;
    [SerializeField] GameObject redBar;
    Transform cam;
    int maxHP;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<health>();
        maxHP = hp.getMaxHp();
        Debug.Log(maxHP);
        cam = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var tmpHP = hp.getHp();
        container.transform.LookAt(cam, Vector3.down);
        var tmp = redBar.transform.localScale;
        if (tmpHP <= 0)
            tmpHP = 1;
        tmp.x = (((float)tmpHP) / maxHP);
        redBar.transform.localScale = tmp;
    }
}
