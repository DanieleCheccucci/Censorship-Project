using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewsDisplay : MonoBehaviour {

	public News news;
	public Image header;
	public Text title;
	public Image image;
	public	static int newsTrust;
	public static int newsKnowledge;


	// Use this for initialization
	void Start () {

		header.sprite = news.header;
		title.text = news.title;
		image.sprite = news.image;
		newsTrust = news.trust;
		newsKnowledge = news.knowledge;
	}
}
