using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] int startingHelath = 100;
    int hp;
    int maxHP;
    // Start is called before the first frame update
    void Awake()
    {
        hp = startingHelath;
        maxHP = startingHelath;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log("Current HP:" + hp);
        if (hp <= 0)
            Die();

    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    public int getHp()
    {
        return hp;
    }
    public int getMaxHp()
    {
        return maxHP;
    }
}
