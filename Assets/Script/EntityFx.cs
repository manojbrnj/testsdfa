using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFx : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Material fx;
    private Material orignal;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        orignal = spriteRenderer.material;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FlashFx()
     {
        spriteRenderer.material = fx;
         yield return new WaitForSeconds(.2f);
        spriteRenderer.material = orignal;

    }



    private void Blinking()
    {
        if(spriteRenderer.color != Color.white)
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }
    private void StopBlinking()
    {
       
        CancelInvoke();
        spriteRenderer.color = Color.white;
    }

  
}
