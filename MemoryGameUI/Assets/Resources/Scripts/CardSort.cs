using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSort : MonoBehaviour {
	
	public List<CardObject> cards = new List<CardObject>();
	public Sprite[] imagesAnimals = new Sprite[10];
	public Sprite[] imagesPlaces = new Sprite[10];
	public List<int> numbers = new List<int>();
	int random;
	int MAX;

	void Start()
	{
		MAX = 10;
		PutCardImage (); 
	}
	public void PutCardImage(){
		for(int i = 0; i < MAX;i++) {

			random = Random.Range (0, cards.Count);
			int random2 = Random.Range (0, cards.Count);
			
			if(random2 == random) 
			{
				random2 = Random.Range (0, cards.Count);
				i-= 1;
			}
			else 
			{
				int animal =  random;
				int habitat = random2;
				
				if(cards[animal].valueNull && 
				   cards[habitat].valueNull)
				{
					SortImagePar(animal,habitat, cards, numbers);
					Debug.Log ("Colocou");
				}
				else
				{
					random = Random.Range (0, cards.Count);
					random2 = Random.Range (0, cards.Count);
					i-= 1;
				}
			}
			Debug.Log("Executou: " + (i+1).ToString() + " vezes");

		}
	}
	void SortImagePar(int animals, int places, List<CardObject> cartas, List<int> num){

		bool notEqual = true;
		int randomSprite = Random.Range (0, 10);
		Debug.Log ("RandomSprite: " + randomSprite.ToString ());

		for (int i = 0; i< num.Count; i++) {
				if (randomSprite == num [i]) {
					notEqual = false;
				}
			}
			
		if (notEqual) {
				cartas [animals].thisSprite = imagesAnimals [randomSprite];
				cartas [places].thisSprite = imagesPlaces [randomSprite];
				cartas [animals].index = randomSprite + 1;
				cartas [places].index = randomSprite + 1;
				cartas [animals].valueNull = false;
				cartas [places].valueNull = false;
				num.Add (randomSprite);
			} 
		else {
				randomSprite = Random.Range (0, 10);

			}
	} 
}
