// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// CubeRotation
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private float speed = 60f;

    private float rot;

    private void Start()
    {
    }

    private void Update()
    {
        rot += Time.deltaTime * speed;
        base.transform.localEulerAngles = new Vector3(1f, 1f, 1f) * rot;
    }
}
