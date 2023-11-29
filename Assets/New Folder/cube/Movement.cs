// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Movement
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 10f;

    private Transform cube;

    private void Start()
    {
        cube = GameObject.Find("Cube").transform;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            base.transform.position -= new Vector3(Time.deltaTime * speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            base.transform.position += new Vector3(Time.deltaTime * speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                base.transform.position += new Vector3(0f, 0f, Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                base.transform.position -= new Vector3(0f, 0f, Time.deltaTime * speed);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            base.transform.position += new Vector3(0f, Time.deltaTime * speed, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            base.transform.position -= new Vector3(0f, Time.deltaTime * speed, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cube.GetComponent<CubeRotation>().enabled = !cube.GetComponent<CubeRotation>().isActiveAndEnabled;
        }
    }

    private void SetFOV()
    {
        Transform child = base.transform.GetChild(0);
        Vector3 lhs = child.position - Camera.main.transform.position;
        float num = Vector3.Dot(lhs, Camera.main.transform.forward);
        float num2 = Mathf.Atan(child.GetComponent<Camera>().orthographicSize / num);
        Camera.main.fieldOfView = num2 * 2f * 57.29578f;
    }
}
