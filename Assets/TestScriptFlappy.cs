using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptFlappy : MonoBehaviour
{
    class PoolObject
    {
        public Transform transform;
        public bool inUse;

        public PoolObject(Transform t)
        {
            transform = t;
        }

        public void Use()
        {
            inUse = true;
        }

        public void Dispose()
        {
            inUse = false;
        }
    }

    // Other script components...

    void Configure()
    {
        // Configuration logic...
    }

    // Other methods...

    //Transform GetPoolObject()
    //{
    //    // Object pooling logic...
    //}
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
