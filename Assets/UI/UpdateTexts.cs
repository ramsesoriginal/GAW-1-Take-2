using UnityEngine;
using System.Collections;

public class UpdateTexts : MonoBehaviour {
	
	private string news;
	public string url = "https://gist.githubusercontent.com/ramsesoriginal/3b467c8e6b7e68bc898d/raw/GAW";
	public string defaultText = "";
	
	IEnumerator Start() {
		var UI = GetComponent<UnityEngine.UI.Text> ();
		defaultText = UI.text;
		news = PlayerPrefs.GetString ("News", defaultText);
		UI.text = news;
		WWW www = new WWW(url);
		yield return www;
		news = www.text;
		UI.text = news;
		PlayerPrefs.SetString ("News", news);
	}
}
