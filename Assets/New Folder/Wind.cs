// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// Wind
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float springConstant = 0.015f;

    public float damping = 0.07f;

    public float windFactor = 1.2f;

    public float velocity;

    public float acceleration;

    private float springPosition;

    private float bendFactor = 0.05f;

    private MeshFilter mf;

    private void Start()
    {
        mf = GetComponent<MeshFilter>();
        velocity = 2f;
    }

    private float Simulate()
    {
        float num = springConstant * springPosition + velocity * damping;
        acceleration = 0f - num;
        springPosition += velocity;
        velocity += acceleration;
        return springPosition;
    }

    private void SetOffset(float offset)
    {
        Vector3[] vertices = mf.mesh.vertices;
        vertices[2].x = 0.5f + offset * bendFactor;
        vertices[0].x = -0.5f + offset * bendFactor;
        mf.mesh.vertices = vertices;
    }

    private void Update()
    {
        velocity += 0.005f - (Mathf.Sin(Time.time * 3f) * 0.7f * windFactor - 0.05f) * 0.05f * 1.05f;
        SetOffset(Simulate());
    }
}
