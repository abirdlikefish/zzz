using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DollParryAttack : MonoBehaviour
{
    float lastingTime ;
    Structs.AttackAttribute attackAttribute ;
    void Awake()
    {
        lastingTime = 1.5f;
    }
    void Update() 
    {
        lastingTime -= Time.deltaTime;
        if(lastingTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag != "Enemy")    return;
        Debug.Log("parry attack");
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.BeAttacked(attackAttribute , null);
    }
    public void Init(Vector3 position , Vector3 direction , Structs.AttackAttribute attackAttribute)
    {
        transform.position = position;
        float mid =Quaternion.LookRotation(direction).eulerAngles.y - 45;
        transform.rotation = Quaternion.Euler(new Vector3(0 , mid , 0));
        // transform.LookAt(position + direction);
        this.attackAttribute = attackAttribute;
    }
}
