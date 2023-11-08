using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    private Rigidbody2D[] rb;
    public int forceX;
    public int forceY;
    public float torque;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentsInChildren<Rigidbody2D>();
        foreach(var item in rb)
        {
           
            item.AddForce(new Vector2(Random.Range(-forceX, forceX), Random.Range(-forceY, forceY)));
            item.AddTorque(Random.Range(torque,-torque));
        }
    
        Invoke("DestroyPieces", 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyPieces()
    {
        Destroy(gameObject);
    }
}
