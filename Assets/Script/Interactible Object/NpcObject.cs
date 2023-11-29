using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcObject : MonoBehaviour,IInteractible
{
    public SpriteRenderer dialogBox;
    public GameObject dialogPlayer;
    public float yPos = 0.1f;
    bool canhide = false;
    public float hide;
    public void Interact()
    {
       //
    }

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    private float CalculateY()
    {
        return yPos *=MathF.Sin(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        yPos = CalculateY();
        hide -= Time.deltaTime;
        if(hide < 0)
        {
            dialogBox.gameObject.SetActive(false);
        }
       
    }

    public void ActiveDialog()
    {
        dialogBox.enabled = false;
    }
    public void DeActiveDialog()
    {
        dialogBox.enabled=true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && hide < 0)
        {
            hide = 10.0f;
            dialogBox.gameObject.SetActive(true);
          //  dialogBox.gameObject.transform.position = new Vector2(dialogPlayer.transform.position.x, dialogPlayer.transform.position.y * yPos);
        }
       
           

      
    }
    
}
