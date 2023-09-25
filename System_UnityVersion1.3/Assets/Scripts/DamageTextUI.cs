using UnityEngine;

public class DamageTextUI : MonoBehaviour
{
	private TextMesh damageText;

	[HideInInspector]
	public int damage = 100;

	[HideInInspector]
	public float fadeOutSpeed = 1f;

	[HideInInspector]
	public float textSpeed = 0.4f;

	void Start()
	{
		damageText = GetComponent<TextMesh>();
		damageText.text = damage.ToString();
	}

	void Update()
	{
		transform.rotation = Camera.main.transform.rotation;
		transform.position += Vector3.up * textSpeed * Time.deltaTime;

		damageText.color = Color.Lerp(damageText.color, new Color(damageText.color.r, damageText.color.g, damageText.color.b, 0f), fadeOutSpeed * Time.deltaTime);

		if (damageText.color.a <= 0.2f) Destroy(gameObject);
	}
}
