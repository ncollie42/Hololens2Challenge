using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAI : MonoBehaviour
{

    [SerializeField] LayerMask AI;
    [SerializeField] float agrowArange = .2f;
    unit unit;
    // Start is called before the first frame update
    void Start()
    {
       unit = GetComponent<unit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!unit.inCombat)
            findTarget(AI);
    }


    bool findTarget(LayerMask targetType)
    {
        Collider[] Targets = Physics.OverlapSphere(transform.position, agrowArange, targetType);
        if (Targets.Length > 0)
        {
            unit.attack(Targets[0].gameObject);
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, agrowArange);
    }
}
