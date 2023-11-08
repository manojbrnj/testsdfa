using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgrounds : MonoBehaviour
{



    private GameObject cam;

    [SerializeField] private float parallaxEffect;

    private float xPosition;
    private float length;

    void Start()
    {
         cam = GameObject.Find("Main Camera");

        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x; //20
        xPosition = transform.position.x; // 0,0
    }

    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect); //0.1=>  2
        float distanceToMove = cam.transform.position.x * parallaxEffect; //0.9 => 18  total 20

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);
        //(0,0) =>         = mana (2,0)  +  (2.x,0.y) ,0);
             //(21,0)   >   (18.x,0) + 20)
        if (distanceMoved > xPosition + length)
            xPosition = xPosition + length;
        else if (distanceMoved < xPosition - length)
            xPosition = xPosition - length;

    }
    //public GameObject cam;
    //public GameObject background;
    //private float length;
    //private float xPos;
    //public float parallax;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    length = background.gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    //    xPos = transform.position.x;
    //  cam = GameObject.Find("Main Camera");
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    transform.position = new Vector2(cam.transform.position.x * parallax,cam.transform.position.y);
    //    float distance = transform.position.x - cam.transform.position.x;

    //    if(Mathf.Abs(distance) > length)
    //    {
    //        transform.position = new Vector2(xPos - distance,cam.transform.position.y);
    //        distance = 0;
    //    }

    //}
}

