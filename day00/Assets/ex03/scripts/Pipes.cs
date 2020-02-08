using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    
    [SerializeField] GameObject bird;
    bool hasPassed = true;
    float offsetCenter = 1.3f;
    float offsetVertical = 1.3f;
    static float dificulty = 3.0f;

    // Update is called once per frame
    void Update()
    {
        if (Bird.running)
        {
            transform.Translate(Vector3.left * Time.deltaTime * dificulty);
            if (transform.position.x < -4)
            {
                restart();
            }

            if (hasPassed && transform.position.x <= 0)
            {
                Bird.upScore();
                hasPassed = false;
            }
            collision();
        }
        else
        {
            dificulty = 3.0f;
            Vector3 tmp = transform.position;
            tmp.x = Random.Range(5f, dificulty * 3f);
            transform.position = tmp;
        }
    }

    void collision()
    {
        float birdX = bird.transform.position.x;
        float birdY = bird.transform.position.y;
        float pipeX = transform.position.x;
        float pipeY = transform.position.y;
        if ((birdX > pipeX - offsetCenter) && (birdX < pipeX + offsetCenter))
        {
            if ((birdY > (pipeY + offsetVertical)) || (birdY < (pipeY - offsetVertical)))
            {
                Bird.running = false;
                Debug.Log(Time.realtimeSinceStartup);
            }
        }
    }

    void restart()
    {
        Vector3 tmp = transform.position;
        tmp.x = Random.Range(5f, dificulty * 3f);
        if (dificulty < 25)
            dificulty += .5f;
        transform.position = tmp;
        hasPassed = true;
    }
}
