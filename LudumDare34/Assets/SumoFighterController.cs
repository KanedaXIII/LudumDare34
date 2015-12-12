using UnityEngine;
using System.Collections;

public class SumoFighterController : MonoBehaviour
{
	public float bellyScale = 1.0f;
	public Transform bellyTransform;
	public Transform chestTransform;

	public void Update()
	{
		this.bellyTransform.localScale = new Vector3(this.bellyScale, this.bellyScale);
		this.chestTransform.localScale = Vector3.one / this.bellyScale;
	}
}