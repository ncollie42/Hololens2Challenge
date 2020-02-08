using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ballPong : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text p1;
    [SerializeField] Text p2;
    [SerializeField] GameObject bar1;
    [SerializeField] GameObject bar2;
    int score1 = 0;
    int score2 = 0;
    int dic = 1;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 45, 0);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        score();
    }
    //Work on ball bounce off wall && off player
    void move()
    {
        Vector3 tmp = transform.position;
        if (tmp.z > 8.5)
            transform.position = new Vector3(tmp.x, tmp.y, 8.5f);
        if (tmp.z < -8.5)
            transform.position = new Vector3(tmp.x, tmp.y, -8.5f);

        if (Mathf.Abs(transform.position.z) == 8.5)
        {
            rotationAngleWalls();
        }

        if (inSideBars())
            rotationAngleBars();

        transform.Translate(Vector3.forward * Time.deltaTime * 15);
    }


    bool inSideBars()
    {
        if (Mathf.Abs(transform.position.x) >= 13.5)
        {
            if ((transform.position.z < (bar2.transform.position.z + 1.3f)) && (transform.position.z > (bar2.transform.position.z - 1.3f)))
            {
                return true;
            }
            if ((transform.position.z < (bar1.transform.position.z + 1.3f)) && (transform.position.z > (bar1.transform.position.z - 1.3f)))
            {
                return true;
            }
        }
        return false;
    }

    void score()
    {
        if (transform.position.x > 15)
        {
            score1++;
            p1.text = score1.ToString();
            transform.position = new Vector3(0, 0, 0);
        }
        if (transform.position.x < -15)
        {
            score2++;
            p2.text = score2.ToString();
            transform.position = new Vector3(0, 0, 0);
        }
    }

    void rotationAngleWalls()
    {
        switch (dic)
        {
            case 0:
                transform.rotation = Quaternion.Euler(0, -135, 0);
                dic = 2;
                break;
            case 1:
                transform.rotation = Quaternion.Euler(0, 135, 0);
                dic = 3;
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, -45, 0);
                dic = 0;
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, 45, 0);
                dic = 1;
                break;
        }
    }
    void rotationAngleBars()
    {
        int extra = Random.Range(-20, 20);
        switch (dic)
        {
            case 0:
                transform.rotation = Quaternion.Euler(0, 45 + extra, 0);
                dic = 1;
                break;
            case 1:
                transform.rotation = Quaternion.Euler(0, -45 + extra, 0);
                dic = 0;
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0, 135 + extra, 0);
                dic = 3;
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0, -135 + extra, 0);
                dic = 2;
                break;
        }
    }
}
