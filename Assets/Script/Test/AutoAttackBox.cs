using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackBox : MonoBehaviour
{
    public Collider collider;
    public GameObject redbox ;
    void Start()
    {
        collider = GetComponent<Collider>();
        redbox = transform.Find("Cube").gameObject;
    }

    float loopTime = 2;
    float lastingTime = 0.3f;
    float timeCnt = 0;
    void Update()
    {
        timeCnt += Time.deltaTime ;
        if(timeCnt > loopTime)
        {
            timeCnt = 0;
            Show();
        }
        if(timeCnt > lastingTime)
        {
            Hid();
        }
    }
    private void Hid()
    {
        collider.enabled = false ;
        redbox.SetActive(false);
    }
    private void Show()
    {
        collider.enabled = true ;
        redbox.SetActive(true);
    }

   
   void OnTriggerEnter(Collider other)
   {
       if(other.tag == "Player" || other.tag == "Enemy")
       {
            Creature creature = other.GetComponent<Creature>();
            if(creature != null)
            {
                Debug.Log("Attack on");
                creature.BeAttacked(new Structs.AttackAttribute(1,1) , null);
            }

       }
   }
}
