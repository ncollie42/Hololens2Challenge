using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    //[SerializeField] GameObject holes[];
    //curent index / level
    [SerializeField] GameObject cam;
    [SerializeField] GameObject cam2;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject bar;
    //[SerializeField] GameObject directionArrow;
    [SerializeField] GameObject direction;
    [SerializeField] GameObject[] holes;
    [SerializeField] GameObject[] startpoints;

    [SerializeField] Text win;
    [SerializeField] Text curentHole;
    [SerializeField] GameObject tip;
    int index = -1;
    //int score;
    Rigidbody ballRB;

    bool end = false;
    bool tipActive = false;
    camera camScript;
    powerBar barScript;
    public enum State
    {
        watching = 0,
        flying,
        shooting,
        CheckingBall,

    }

    public State curentState;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = ball.GetComponent<Rigidbody>();
        camScript = cam.GetComponent<camera>();
        barScript = bar.GetComponent<powerBar>();

        nextLevel();
        curentState = State.flying;
        win.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tipActive = !tipActive;
            tip.SetActive(tipActive);
        }
        curentHole.text = "Hole " + (index + 1) + "/3";
        if (end)
        {
            //Show Hud
            win.text = "You win!";
            if (Input.GetKeyDown(KeyCode.R))
            {
                index = -1;
                nextLevel();
            }
            //REmove hud
        }
        else if (curentState == State.flying && Input.GetKeyDown(KeyCode.Space))
        {
            setWatching();
        }
        //reset if in watch mode and moved || or shooting
        else if ((curentState == State.watching || curentState == State.shooting) && (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.S)))
        {
            setFlying();
        }
        else if (curentState == State.watching && Input.GetKeyDown(KeyCode.Space))
        {
            barScript.active = true;
            //Start shooting state
            curentState = State.shooting;
        }
        else if (curentState == State.shooting && Input.GetKeyDown(KeyCode.Space))
        {            
            var power = barScript.slider.value;
            Vector3 forward = direction.transform.forward;
                   
            ballRB.AddForce(forward * power * 200);
            setFlying();
            curentState = State.CheckingBall;
        }
        else if (curentState == State.CheckingBall)
        {
            if (Mathf.Abs(ballRB.velocity.x) <= .2 && Mathf.Abs(ballRB.velocity.y) <= .2 && Mathf.Abs(ballRB.velocity.z) <= .2)
                setWatching();
        }

        if (Input.GetKeyDown(KeyCode.R) || ball.transform.position.y < -15)
        {
            resetLevel();
        }
    }


    public void nextLevel()
    {
       if (index == 2)
        {
            end = true;
            return;
        }
        if (index >= 0)
            holes[index].GetComponent<Collider>().enabled = false;
        index++;
        Debug.Log("Starting Level:" + index);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.LookAt(holes[index].transform);
        ball.transform.position = startpoints[index].transform.position;
        holes[index].GetComponent<Collider>().enabled = true;
        setWatching();
    }
    private void resetLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.LookAt(holes[index].transform);
        ball.transform.position = startpoints[index].transform.position;
    }
    private void setWatching()
    {
        Vector3 tmp = direction.transform.position;
        tmp.y += 4;

        cam.transform.position = tmp;
        cam.SetActive(false);
        bar.SetActive(true);
        barScript.active = false;
        cam2.SetActive(true);

        curentState = State.watching;
    }
    private void setFlying()
    {
        cam.SetActive(true);
        cam2.SetActive(false);
        camScript.active = true;

        //directionArrow.SetActive(false);
        bar.SetActive(false);
        curentState = State.flying;
    }
}