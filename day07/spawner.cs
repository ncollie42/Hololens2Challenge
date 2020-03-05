using UnityEngine;

public class spawner : MonoBehaviour
{

    [SerializeField] GameObject spawningUnit;
    [SerializeField] int spawnTime;
    [SerializeField] int spawnDelay;
    [SerializeField] LayerMask targetType;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnUnit", spawnTime, spawnDelay);
    }


    public void spawnUnit()
    {

        Collider[] units = Physics.OverlapSphere(transform.position, .1f, targetType);
        if (units.Length == 0)
            Instantiate(spawningUnit, transform.position, transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, .1f);
    }
}
