using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    [SerializeField] GameObject[] endpoints;
    [SerializeField] string nextLevel;
    [SerializeField] bool allGood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(atAllExit())
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    bool atAllExit()
    {
        foreach (GameObject current in endpoints)
        {
            bool triggered = current.GetComponent<EndPoint>().triggered;
            if (triggered == false)
                return false;
        }
        return true;
    }
}
