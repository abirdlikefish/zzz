using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    Player father ;
    Collider collider ;
    int maxFindDepth = 30; 

    void Awake() 
    {
        maxFindDepth = 30; 
        // if(father == null)
        GetFather(transform);
        collider = gameObject.GetComponent<Collider>();
        collider.enabled = false;
        
    }
    private void GetFather(Transform mid)
    {
        maxFindDepth --;
        if(maxFindDepth == 0)
        {
            Debug.Log("can't find father");
            return ;
        }
        if(mid == null)
        {
            Debug.Log("can't find father");
            return ;
        }
        if(mid.tag == "Player")
        {
            father = mid.GetComponent<Player>();
            father.SetWeapon(this);
            return ;
        }
        else
        {
            GetFather(mid.parent);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        father.WeaponCollide(other);
        Debug.Log("attack " + other.name);
    }

    public void WeaponOn()
    {
        // gameObject.SetActive(true);
        collider.enabled = true;
    }
    public void WeaponOff()
    {
        // gameObject.SetActive(false);
        collider.enabled = false;
    }


}

