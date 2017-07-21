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
    protected float atkRange;

    protected int def;

    protected float sightRange;

    protected bool isStructue;

    protected Transform target;

    protected LayerMask enemyLayer;

    
    public int currentHp
    {
        protected set
        {
            if (value>0)
            {
                hp = value;
                if (hp > maxHp)
                {
                    hp = maxHp;
                }
            }
            else
            {
                hp = 0;
                Destroyed();
            }
        }
        get
        { 
            return hp;
        }
    }

    public void RestoreHp(int amount)
    {
        currentHp += amount;
    }

    public void OnDamage(int damage)
    {
        currentHp -= damage;
    }

    public int currentMp
    {
        protected set
        {
            if (value>0)
            {
                mp = value;
                if (mp > maxMp)
                {
                    mp = maxMp;
                }
            }
            else
            {
                mp = 0;
            }
        }
        get
        { 
            return mp;
        }
    }

    public void RestoreMp(int amount)
    {
        currentMp += amount;
    }
    

    public bool IsStructure()
    {
        return isStructue;
    }

    protected void UpdateAttackTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, atkRange, enemyLayer);
        //자신의 위치를 기준으로 range를 반지름으로 하는 구의 반경에 잡힌 whatIsEnemy에 넣어진 layer를 가진 Collider를 반환

        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Collider currentCollider in colliders)
        {
            float distance = Vector3.Distance(transform.position, currentCollider.transform.position);
            //이 Minion과 읽고있는 currentCollider과의 거리
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = currentCollider.transform;
            }
        }

        target = nearestEnemy;
    }

    protected void Attack()
    {
        if (target == null)
        {
            Debug.Log("Null target.");
        }
        else if (Vector3.Distance(target.transform.position,transform.position)>atkRange)
        {
            Debug.Log("Out of sight; Chasing.");
         }
        else
        {
            Debug.Log("Attaking target: " + target.ToString());
            StatusControls targetStatus=target.GetComponent<StatusControls>();
            if (targetStatus==null)
            {
                return;
            }
            targetStatus.OnDamage(atk);
        }

    }

    public virtual void Destroyed()
    {

    }

}
