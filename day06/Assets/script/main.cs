using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class main : MonoBehaviour
{
    AudioSource Sound;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject gameOverCam;
    [SerializeField] Text text;
    enum soundEffect
    {
        backGround = 0,
        panic,
        restarting,

    }

    public enum gameSate
    {
        running = 1,
        pause,
        panic,
        lost,
    }
    static public gameSate curentState;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        Sound = GetComponent<AudioSource>();
        playSound(soundEffect.backGround);
        curentState = gameSate.running;
    }

    // Update is called once per frame
    void Update()
    {
        loopMusic();
        if (curentState == gameSate.lost)
        {
            if (Input.anyKeyDown)
                restart();
        }
        if (Input.GetKeyDown(KeyCode.R))
            restart();
    }

    void loopMusic()
    {
        if (Sound.isPlaying)
            return;
        if (curentState == gameSate.running)
            playSound(soundEffect.backGround);
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void playSound(soundEffect sound)
    {
        Sound.clip = clips[(int)sound];
        Sound.Play();
    }


    public void normalMode()
    {
        playSound(soundEffect.backGround);
        curentState = gameSate.running;
    }
    public void panicMode()
    {
        playSound(soundEffect.panic);
        curentState = gameSate.panic;
    }
    public void gameLost()
    {
        text.text = "Press any key to restart...";
        gameOverCam.SetActive(true);
        playSound(soundEffect.restarting);
        curentState = gameSate.lost;
    }

}