using UnityEngine;
using UnityEditor;

// Editor Script that multiplies the scale of the current selected GameObject

public class AlphaControl : MonoBehaviour
{
	public float transparency;

	public void ApplyTransparency(){
		Color c = this.GetComponent<SpriteRenderer>().color;
		c.a = transparency;
		this.GetComponent<SpriteRenderer>().color = c;
	}

}