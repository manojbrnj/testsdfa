// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// ExplosionEffect
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
	private Material m_Material;

	public Shader shader;

	public float radius = 0.3f;

	public Vector2 center = new Vector2(0.5f, 0.5f);

	private float finalRadius;

	private float amp;

	private float ampChange = -0.001f;

	private float radiusChange = 0.02f;

	protected Material material
	{
		get
		{
			if (m_Material == null)
			{
				m_Material = new Material(shader);
				m_Material.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_Material;
		}
	}

	public void Init(Vector2 pos, float radius, float intensity, float speedMultiplier = 1f, float wavesize = 0.1f)
	{
		amp = 0.02f * intensity;
		ampChange = (0f - 1f / radius) * 0.2f;
		radiusChange *= speedMultiplier;
		ampChange *= speedMultiplier;
		//shader = Shader.Find("Custom/Shockwave");
		this.radius = 0f;
		amp = 0.05f;
		center = Camera.main.WorldToScreenPoint(pos);
		center.x /= Screen.width;
		center.y /= Screen.height;
		material.SetFloat("_Ratio", (float)Screen.height / (float)Screen.width);
		material.SetFloat("_Wavesize", wavesize);
	}

	private void Update()
	{
		radius += 0.002f;
		amp -= 0.002f;
		if (amp <= 0f)
		{
			Object.Destroy(this);
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderDistortion(material, source, destination, center, radius, amp);
	}

	private void RenderDistortion(Material material, RenderTexture source, RenderTexture destination, Vector2 center, float radius, float amplitude)
	{
		if (source.texelSize.y < 0f)
		{
			center.y = 1f - center.y;
		}
		material.SetFloat("_Amplitude", amplitude);
		material.SetFloat("_Radius", radius);
		material.SetFloat("_CenterX", center.x);
		material.SetFloat("_CenterY", center.y);
		Graphics.Blit(source, destination, material);
	}
}
