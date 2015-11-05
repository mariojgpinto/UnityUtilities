using UnityEngine;
using System.Collections;

public class Tools{
	public static IEnumerator LerpGUIText(GUIText text, Color color_start, Color color_end, float duration)
	{
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.1
		
		while(progress < 1)
		{
			text.color = Color.Lerp(color_start, color_end, progress);
			progress += Time.deltaTime/duration;
			yield return true;//new WaitForSeconds(smoothness);
		}

		text.color = color_end;

		yield break;
	}

	public static IEnumerator LerpGUITexture(GUITexture text, Color color_start, Color color_end, float duration)
	{
		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.1

		while(progress < 1)
		{
			text.color = Color.Lerp(color_start, color_end, progress);
			progress += Time.deltaTime/duration;
			yield return true;//new WaitForSeconds(smoothness);
		}

		text.color = color_end;

		yield break;
	}


	public static IEnumerator ScreenFadeIn(string gui_texture_name, float duration)
	{
		if(duration > 0){
			GUITexture text = GameObject.Find("ScreenFade").guiTexture;
			text.pixelInset = new Rect(-Screen.width/2-1, -Screen.height/2-1, Screen.width+2, Screen.height+2);
			Color color_start = text.color;//new Color(0,0,0,0);
			color_start.a = 0.0f;
			Color color_end = text.color;//new Color(0,0,0,.5f);
			color_end.a = 0.5f;

			float progress = 1; //This float will serve as the 3rd parameter of the lerp function.1
			
			while(progress >= 0)
			{
				text.color = Color.Lerp(color_start, color_end, progress);
				progress -= Time.deltaTime/duration;
				yield return true;//new WaitForSeconds(smoothness);
			}
		}
		yield break;
	}

	public static IEnumerator ScreenFadeOut(string gui_texture_name, float duration)
	{
		if(duration > 0){
			GUITexture text = GameObject.Find("ScreenFade").guiTexture;
			text.pixelInset = new Rect(-Screen.width/2-1, -Screen.height/2-1, Screen.width+2, Screen.height+2);
			Color color_start = text.color;//new Color(0,0,0,0);
			color_start.a = 0.0f;
			Color color_end = text.color;//new Color(0,0,0,.5f);
			color_end.a = 0.5f;
			
			float progress = 0; //This float will serve as the 3rd parameter of the lerp function.1
			
			while(progress < 1)
			{
				text.color = Color.Lerp(color_start, color_end, progress);
				progress += Time.deltaTime/duration;
				yield return true;//new WaitForSeconds(smoothness);
			}
		}
		yield break;
	}
	
	public static System.Collections.Generic.List<T> Randomize<T>(System.Collections.Generic.List<T> list)
	{
		System.Collections.Generic.List<T> randomizedList = new System.Collections.Generic.List<T>();
		Random rnd = new Random();
		while (list.Count > 0)
		{
			int index = rnd.Next(0, list.Count); //pick a random item from the master list
			randomizedList.Add(list[index]); //place it at the end of the randomized list
			list.RemoveAt(index);
		}
		return randomizedList;
	}
}