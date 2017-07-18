using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusControls : MonoBehaviour
{
    
    private int hp;
    protected int maxHp;
    private int mp;
    protected int maxMp;

    protected int atk;
    protected float atkSpeed;
    protected float atkDistance;

    protected int def;

    protected float sight;

    protected bool isStructue;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int CurrentHp
    {
        get
        {
            return hp;
        }
    }

    public void HpIncrease(int amount)
    {
        hp += amount;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        else if (hp < 0)
        {
            hp = 0;
        }
    }

    public int CurrentMp
    {
        get
        {
            return mp;
        }
    }


    public void MpIncrease(int amount)
    {
        mp += amount;
        if (mp > maxMp)
        {
            mp = maxMp;
        }
        else if (hp < 0)
        {
            mp = 0;
        }
    }

    public bool IsStructure()
    {
        return isStructue;
    }

    void SetAttackTarget()
    {
        
    }

    void Attack()
    {

    }

}
