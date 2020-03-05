using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyAI : MonoBehaviour
{
    GameObject PlayerBase;
    [SerializeField] LayerMask player; 
    [SerializeField] LayerMask building;
    [SerializeField] float agrowRange = .2f;

    bool defending = false;
    unit unitScript;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        unitScript = GetComponent<unit>();
        PlayerBase = GameObject.Find("mainRed");
        agent = GetComponent<NavMeshAgent>();
    }
        //Walk to target
        // check pshere to attack enemy
        // if trigger is scalled, make it walk back to mainbase
    // Update is called once per frame
    void Update()
    {
        if (defending)
        {
            if (agent.remainingDistance <= .1)
                defending = false;
            return;
        }
        //if !incombat set target == enemy base
        if (findTarget(player))
            return;
        if (findTarget(building))
            return;
        unitScript.move(PlayerBase.transform.position);
    }

    public void Defend(Vector3 position)
    {
        unitScript.move(position);
        defending = true;
        //calls move to our own base
    }

    bool findTarget(LayerMask targetType)
    {
        Collider[] Targets = Physics.OverlapSphere(transform.position, .4f, targetType);
        if (Targets.Length > 0)
        {
            unitScript.attack(Targets[0].gameObject);
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, agrowRange);
    }
}
