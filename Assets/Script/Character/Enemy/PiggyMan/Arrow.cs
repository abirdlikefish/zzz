using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float lastingTime = 0;
    Rigidbody rb ;
    private void Awake() 
    {
        lastingTime = 3;
        rb = transform.GetComponent<Rigidbody>();
    }
    private void Update() 
    {
        lastingTime -= Time.deltaTime;
        if(lastingTime < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag != "Player")   return ;
        // Debug.Log("be attacked by arrow");
        other.GetComponent<Player>().BeAttacked( Structs.attackAttribute_null, null);
    }
    public void Init(Vector3 position , Vector3 direction)
    {
        direction += Vector3.down * 3;
        // Debug.Log( "speed= "+ direction);
        transform.position = position;
        transform.LookAt(position + direction );
        rb.velocity = direction;
    }
}
