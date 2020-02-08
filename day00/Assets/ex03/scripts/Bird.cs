using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    static int score = 0;
    public int gravity = 1;
    static public bool running = true;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject button;
    // Update is called once per frame
    void Update()
    {      
        scoreText.text = score.ToString();
        if (running)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(Vector3.up * 2 * Time.deltaTime * 4);
            }
            transform.Translate(Vector3.down * Time.deltaTime * 4);
        }
        else
        {
            button.SetActive(true);
            
        }


    }

    public static void upScore()
    {
        score++;
    }

    public void RestartGame()
    {
        score = 0;
        transform.position = new Vector3(0, 0, 0);
        running = true;
        button.SetActive(false);
    }
}
