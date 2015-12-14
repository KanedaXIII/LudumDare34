using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbsorbController : MonoBehaviour
{
	public List<Transform> spawnPoints;
	public float spawnRadius = 0.20f;
	public float effectForce = 0.10f;

	public Sprite particleSprite;

	private List<Transform> particleList = new List<Transform>();

	public bool active = false;

	private void Update()
	{
		if (active) {
			GameObject newParticle = new GameObject ("Absorb particle");
			SpriteRenderer newRenderer = newParticle.AddComponent<SpriteRenderer> ();
            newRenderer.sortingOrder=21;
			newRenderer.sprite = this.particleSprite;
			newRenderer.color = Color.Lerp (new Color(0.2f, 0.2f, 0.2f, 0.666f), new Color(0.8f, 0.8f, 0.8f, 0.666f), Random.value);

			newParticle.transform.position = this.GetRandomPoint ();
			this.particleList.Add (newParticle.transform);
		}

		// Mover y eliminar partículas
		for (int i = this.particleList.Count - 1; i >= 0; i--) {
			Transform particleTransform = this.particleList [i];
			particleTransform.position = Vector3.Lerp (particleTransform.position, this.transform.position, this.effectForce);
			particleTransform.localScale = Vector3.Lerp (particleTransform.localScale, Vector3.zero, this.effectForce * 0.5f);
			Vector3 positionDelta = this.transform.position - particleTransform.position;

			if (positionDelta.sqrMagnitude < 0.01f) {
				this.particleList.RemoveAt (i);
				GameObject.Destroy (particleTransform.gameObject);
			}
		}
	}

	private Vector3 GetRandomPoint()
	{
		return this.spawnPoints [Random.Range (0, this.spawnPoints.Count)].position +
			(Random.insideUnitSphere * this.spawnRadius);
	}
}
