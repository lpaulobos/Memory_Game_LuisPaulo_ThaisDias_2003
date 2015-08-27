using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSort : MonoBehaviour {
	
	public List<CardObject> cards = new List<CardObject>();
	public Sprite[] imagesAnimals = new Sprite[10];
	public Sprite[] imagesPlaces = new Sprite[10];
	int random;

	void Start()
	{
		PutCardImage (); 
	}
	public void PutCardImage(){
		for(int i = 0; i < 10;i++) {
			random = Random.Range (0, cards.Count);
			int random2 = Random.Range (0, cards.Count);
			
			if(random2 == random) 
			{
				random2 = Random.Range (0, cards.Count);
				Debug.Log("Randomico igual");
				i-=1;
			}
			else 
			{
				Debug.Log (random.ToString() + " : " + random2.ToString());
				int animal =  random;
				int habitat = random2;
				
				if(cards[animal].valueNull && 
				   cards[habitat].valueNull)
				{
					SortImagePar(animal,habitat, cards);
					cards[animal].valueNull = false;
					cards[habitat].valueNull = false;
					Debug.Log ("Colocou");
				}
				else
				{
					random = Random.Range (0, cards.Count);
					random2 = Random.Range (0, cards.Count);
					Debug.Log("Gerou novo");
					i-=1;
				}
			}
			Debug.Log(i);
		}
	}
	void SortImagePar(int animals, int places, List<CardObject> cards){
		
		int randomSprite = Random.Range (0, 10);
		
		cards[animals].thisSprite = imagesAnimals[randomSprite];
		cards[places].thisSprite = imagesPlaces[randomSprite];
		cards[animals].index = randomSprite;
		cards[places].index = randomSprite;
		cards[animals].valueNull = false;
		cards[places].valueNull = false;
	}

		 
}
