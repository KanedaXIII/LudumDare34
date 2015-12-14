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
    
    public Animator animator;
    
    private Color[] shirtColorList = { Color.white, Color.blue, Color.cyan, Color.red, Color.grey, Color.green, Color.yellow };
    private Color[] pantsColorList = { Color.blue, Color.grey, new Color(0.25f, 0.25f, 0.25f), new Color(0.0f, 0.0f, 0.5f) };
    private Color[] shoeColorList = { Color.white, Color.grey, new Color(0.25f, 0.25f, 0.25f) };
    
	private float timeToNextAnimation;
    private float timeCounter = 0.0f;
    
    private void Start()
    {
		this.timeToNextAnimation = Random.Range(0.8f, 3.2f);
		this.Randomize();
        //this.animator = this.GetComponent<Animator> ();
    }
    
    private void Update()
    {
        this.timeCounter += Time.deltaTime;
        if (this.timeCounter > this.timeToNextAnimation) {
            this.timeCounter = 0.0f;
            this.timeToNextAnimation = Random.Range(1.6f, 4.0f);
            
            this.animator.CrossFade(this.GetRandomStateName(), 0.1f);
        }
    }
    
    private string GetRandomStateName()
    {
        List<string> stateNameList = new List<string>();
        stateNameList.Add("Wave");
        stateNameList.Add("Dance");
        stateNameList.Add("Jump");
        
        return stateNameList[Random.Range(0, stateNameList.Count)];
    }
    
    private void Randomize()
    {
        bool isMale = Random.value > 0.5f;
        
        if (isMale)
        {
            this.bodySpriteRenderer.sprite = this.maleBodySprite;
            this.headSpriteRenderer.sprite = this.maleHeadSprites[Random.Range(0, this.maleHeadSprites.Count)];
        }
        else
        {
            this.bodySpriteRenderer.sprite = this.femaleBodySprite;
            this.headSpriteRenderer.sprite = this.femaleHeadSprites[Random.Range(0, this.maleHeadSprites.Count)];
        }
        
        Color shirtColor = this.shirtColorList[Random.Range(0, this.shirtColorList.Length)];
        this.bodySpriteRenderer.color = shirtColor;
        this.armSpriteRenderer1.color = shirtColor;
        this.armSpriteRenderer2.color = shirtColor;
        
        Color pantsColor = this.pantsColorList[Random.Range(0, this.pantsColorList.Length)];
        this.pantsSpriteRenderer.color = pantsColor;
        
        Color shoeColor = this.shoeColorList[Random.Range(0, this.shoeColorList.Length)];
        this.shoesSpriteRenderer.color = shoeColor;
    }
    
}