using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Transform tri;
    public Transform cir;
    // Start is called before the first frame update
    void Start()
    {

        cir.SetParent(tri);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
