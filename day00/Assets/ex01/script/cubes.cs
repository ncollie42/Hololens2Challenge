using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubes : MonoBehaviour
{
    float speed = 2;
    //int position = 0;
    public Queue<GameObject> que = new Queue<GameObject>();
    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("spawnerObject"))
        {            
            spawner = GameObject.Find("spawnerObject");
            getQueFromSpawner();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * -Time.deltaTime * speed); //make 2 a random number?
        if (transform.position.y < -10)
        {
            GameObject tmp = que.Dequeue();
            Restart();
            que.Enqueue(tmp);
            spawner.GetComponent<spawner>().score -= 10;
        }
    }

    public void Restart()
    {
        speed = Random.Range(2.5f, 9.5f);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }


    void getQueFromSpawner()
    {
            if (transform.tag.Equals("A"))
            {          
                que = spawner.GetComponent<spawner>().A;
            }
            else if (transform.tag.Equals("S"))
            {
                que = spawner.GetComponent<spawner>().S;
            }
            else if (transform.tag.Equals("D"))
            {
                que = spawner.GetComponent<spawner>().D;
            }
    }
    // if at hight disable? reset and go again?
}