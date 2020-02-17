using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective : MonoBehaviour
{
    [SerializeField] GameObject target;
    bool completed = false;
    [SerializeField] Transform player;
    [SerializeField] LayerMask playerMask;
    [SerializeField] string beforeText;
    [SerializeField] string AfterText;
    [SerializeField] Animator door;
    bool hasTarget;
    TextMesh infoText;
    bool playerNearBy = false;
    public float radious = 25;
    // Start is called before the first frame update
    void Start()
    {
        infoText = transform.GetChild(0).GetComponent<TextMesh>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            playerNearBy = Physics.CheckSphere(transform.position, radious, playerMask);
            if (playerNearBy)
            {
                infoText.gameObject.SetActive(true);
                infoText.transform.LookAt(infoText.transform.position - (player.position - infoText.transform.position));
                hasTarget = !target.activeSelf;
                infoText.text = (hasTarget ? AfterText : beforeText);
                if (Input.GetKeyDown(KeyCode.E) && hasTarget)
                {
                    //transform.GetChild(1).GetComponent<Material>().color = Color.red;
                    //Do action
                    door.SetTrigger("Open");
                    completed = true;
                    infoText.gameObject.SetActive(false);
                }
            }
            else
            {
                infoText.gameObject.SetActive(false);
            }

            
        }
    }
}

//TODO: Put this script on something [objective]
// if notOpened / completed
// check if gameobject[objective] isEnabled if true do action[open door ext...;
