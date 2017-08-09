using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;
    private bool dead = false;
    public Animator anim;
    private Color color;

    public float fadeSpeed = 0.1f; // 얼마나 빨리 사라지게 할 것인지.
    //이 fade효과는 타워에는 사용하지 않기로 한다.
    //fadeSpeed는 0 초과, 1 미만으로 지정한다. alpha값을 1초마다 fadeSpeed만큼 줄이는것이다.

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        color = GetComponent<Color>();
    }

    public void OnDamage(float Damage)
    {
        currentHealth -= Damage;
        if (currentHealth <= 0f && dead == false) // 세이프티로 dead == false도 조건에 걸어줌.
        {
            OnDead();
        }
    }

    public void OnDead()
    {
        dead = true;
        //애니메이터에서 죽는 애니메이션을 실행시킴.
        StartCoroutine("ObjectFade");
        //오브젝트 페이드 함수.
        if(color.a <= 0f)
        {
            Destroy(gameObject);
        }
        //지금은 일단 Destroy를 했지만, 오브젝트 풀로 옮기는 방법도 적용하는게 좋을 것같음.
    }

    IEnumerator ObjectFade()
    {
        for(float f = 1.0f; ;)
        {
            f = color.a;
            f -= fadeSpeed * Time.deltaTime;
            if(f > 0f)
            {
                color.a = f;
            } else if(f <= 0f) {
                color.a = 0f;
                break; 
            }   
        }
        yield return null;
    }
}
