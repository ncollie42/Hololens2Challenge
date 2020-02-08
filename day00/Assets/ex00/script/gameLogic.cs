using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
    const int maxBreath = 500;
    public GameObject breathBar;
    public GameObject ballon;
    public GameObject button;
    bool hasPrinted = false;
    int breath = maxBreath;
    public float gameTime;
    bool running = true;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = Time.time;
        print("logic script");
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            gameTime = Time.time;
            if (Input.GetKeyDown(KeyCode.Space) && breath >= 75)
            {
                breath -= 75;
                updateBreathBar(breath);

                changeBallonSize(1.9f);
                if (checkBallonLimit())
                    running = false;
            }
            else
            {
                breath += 1;
                if (breath > maxBreath)
                    breath = maxBreath;
                updateBreathBar(breath);
                changeBallonSize(.99f);
                if (checkBallonLimit())
                    running = false;
            }
        }
        else
        {
            breathBar.SetActive(false);
            ballon.SetActive(false);
            if (!hasPrinted)
            {
                Debug.Log(gameTime);
                hasPrinted = true;
            }
            
            button.SetActive(true);
        }
    }

    public void restart()
    {
        ballon.transform.localScale = new Vector3(1f, 1f, 1f);
        ballon.SetActive(true);
        updateBreathBar(maxBreath);
        breathBar.SetActive(true);
        running = true;
        button.SetActive(false);
    }
    void updateBreathBar(float height)
    {
        RectTransform ui = breathBar.GetComponent<RectTransform>();
        ui.sizeDelta = new Vector2(30, height);
    }
    void changeBallonSize(float scale)
    {
        Vector3 last = ballon.transform.localScale;
        ballon.transform.localScale = new Vector3(last.x * scale, last.y * scale, last.z * scale);
    }
    bool checkBallonLimit()
    {
        if (ballon.transform.localScale.x <= 0.5 || ballon.transform.localScale.x >= 8)
            return true;
        return false;
    }
}
