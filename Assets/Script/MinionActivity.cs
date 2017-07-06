using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionActivity : StatusControls
{
    
    //All publics here are used for balacing.
    public int maximumHp=20;
    public int maximumMp=0;

    public int attackPower;
    // public float moveSpeed = 10f;
    
    public float attackDistance = 0.5f;
    public float attackSpeed = 1f;
    public int defencePower = 0;

    public float sightDistace = 1.5f;

    private Rigidbody rd;
    private Animator anim;
    private NavMeshAgent nav;
    
	// Use this for initialization
	void Start ()
	{
	    rd = GetComponent<Rigidbody>();
	    anim = GetComponent<Animator>();
	    nav = GetComponent<NavMeshAgent>();
	    this.maxHp = maximumHp;
	    this.maxMp = maximumMp;
	    this.atk = attackPower;
	    this.atkSpeed = attackSpeed;
	    this.atkDistance = attackDistance;
	    this.def = defencePower;
	    this.sight = sightDistace;
	}
	
	// Update is called once per frame
	void Update () {
	    

	}

    void Idle()
    {
        nav.SetDestination(new Vector3(4, 7.5f, 4));
    }

    void chase()
    {
        
    }
}
