using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class unit : MonoBehaviour
{
    public bool inCombat = false;
    bool canAttack = true;
    bool inRange = false;
    Vector3 targetLocation;
    Animator animator;
    NavMeshAgent agent;
    GameObject target;
    health targetHP;
    [SerializeField] int damage = 1;
    [SerializeField] float attackCD;
    [SerializeField] float stopDistance = .4f;
    public GameObject targetedMark;
    unitControl unitControl;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (GameObject.Find("unitControl"))
            unitControl = GameObject.Find("unitControl").GetComponent<unitControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inCombat)
        {
            followEnemy();
            attack();
        }
        else
            stopRunningCheck();
    }

    void stopRunningCheck()
    {
        inRange = (agent.remainingDistance <= stopDistance);
        if (inRange)
            animator.SetBool("run", false);
    }
    void attack()
    {
        if (canAttack && inRange)
        {
            animator.SetBool("attack", true);
            transform.LookAt(target.transform);
            targetHP.TakeDamage(damage);
            canAttack = false;
            StartCoroutine(attackCoolDown());
            if (!target.activeSelf)
            {
                inCombat = false;
                animator.SetBool("attack", false);
            }
        }
    }
    void followEnemy()
    {
        targetLocation = target.transform.position;
        targetLocation.y = transform.position.y;
        agent.destination = targetLocation;
        inRange = (agent.remainingDistance <= stopDistance);
        if (!inRange)
            moveTo(targetLocation);
    }


    void moveTo(Vector3 destination)
    {
        animator.SetBool("attack", false);
        agent.destination = destination;
        targetLocation = destination;
        animator.SetBool("run", true);
    }
    IEnumerator attackCoolDown()
    {
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
    }

    public void move(Vector3 destination)
    {
        moveTo(destination);
        inCombat = false;
    }

    public void attack(GameObject newTarget)
    {
        inCombat = true;
        target = newTarget;
        targetHP = target.GetComponent<health>();
    }

    public void addUnit()
    {
        unitControl.addUnit(this);
    }
}
