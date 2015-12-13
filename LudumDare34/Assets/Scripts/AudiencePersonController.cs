using UnityEngine;
using System.Collections.Generic;

public class AudiencePersonController : MonoBehaviour
{
	public Sprite maleBodySprite;
	public Sprite femaleBodySprite;

	public List<Sprite> maleHeadSprites;
	public List<Sprite> femaleHeadSprites;

	public SpriteRenderer bodySpriteRenderer;
	public SpriteRenderer armSpriteRenderer1;
	public SpriteRenderer armSpriteRenderer2;
	public SpriteRenderer headSpriteRenderer;
	public SpriteRenderer pantsSpriteRenderer;
	public SpriteRenderer shoesSpriteRenderer;

	private Color[] shirtColorList = { Color.white, Color.blue, Color.cyan, Color.red, Color.grey, Color.green,Color.yellow };
	private Color[] pantsColorList = { Color.blue, Color.grey, new Color(0.25f, 0.25f, 0.25f) };
	private Color[] shoeColorList = { Color.grey, new Color(0.25f, 0.25f, 0.25f) };

	private void Start()
	{
		this.Randomize();
	}
	
	private void Randomize()
	{
		bool isMale = Random.value > 0.5f;

		if (isMale)
		{
			this.bodySpriteRenderer.sprite = this.maleBodySprite;
			this.headSpriteRenderer.sprite = this.maleHeadSprites [Random.Range (0, this.maleHeadSprites.Count)];
		}
		else
		{
			this.bodySpriteRenderer.sprite = this.femaleBodySprite;
			this.headSpriteRenderer.sprite = this.femaleHeadSprites [Random.Range (0, this.maleHeadSprites.Count)];
		}

		Color shirtColor = this.shirtColorList [Random.Range (0, this.shirtColorList.Length)];
		this.bodySpriteRenderer.color = shirtColor;
		this.armSpriteRenderer1.color = shirtColor;
		this.armSpriteRenderer2.color = shirtColor;

		Color pantsColor = this.pantsColorList [Random.Range (0, this.pantsColorList.Length)];
		this.pantsSpriteRenderer.color = pantsColor;

		Color shoeColor = this.shoeColorList [Random.Range (0, this.shoeColorList.Length)];
		this.shoesSpriteRenderer.color = shoeColor;
	}
}
