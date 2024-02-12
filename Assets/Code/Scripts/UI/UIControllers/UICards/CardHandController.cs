using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHandController : MonoBehaviour
{
	
	
	[SerializeField]
	GameObject handCard;
	
	[SerializeField]
	UIScriptableObject uiScriptableObject;
	
	private List<GameObject> _cardsInHand;
	
	int _numCards = 0;
	
	// Start is called before the first frame update
	void Start()
	{
		_cardsInHand = new List<GameObject>();
		uiScriptableObject.drawButtonClick.AddListener(DrawButtonClickEventHandler);
	}

	// Update is called once per frame
	void Update()
	{
		
		
	}
	
	void DrawButtonClickEventHandler()
	{
		_numCards++;
		GenerateCards();
	}
	
	void GenerateCards()
	{
		int cardSpreadDistance = 100 * _numCards;
		int distanceBetweenCards = cardSpreadDistance / _numCards;
		float currentCardPositionX = distanceBetweenCards * 0.5f;
		int startingOffset = cardSpreadDistance / 2;
		
		
		int maxShiftDown = 20 * _numCards;
		int minShiftDown = -1 * (maxShiftDown / 2);
		int shiftBetweenCards = maxShiftDown / _numCards;
		float currentCardPositionY = minShiftDown;
		

		int maxRotationDegrees = -60;
		int rotationBetweenCards = maxRotationDegrees / _numCards;
		float firstCardRotation = transform.rotation.z - (maxRotationDegrees / 2);
		float currentCardRotation = rotationBetweenCards * 0.5f;

		
		for(int i = 0; i < _numCards; i++)
		{
			
			GameObject card = Instantiate(handCard, Vector3.zero, Quaternion.identity);
			card.transform.SetParent(transform,false);
			
			
			card.transform.position += Vector3.right * (currentCardPositionX - startingOffset) ;
			card.transform.rotation = Quaternion.Euler(0f,0f,firstCardRotation + currentCardRotation);
			
			currentCardPositionX += distanceBetweenCards;
			currentCardPositionY += shiftBetweenCards;
			currentCardRotation += rotationBetweenCards;
			
			_cardsInHand.Add(card);
		}
		
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width - 150, Screen.height - 150, 150, 150));
		if (GUILayout.Button("Add Card"))
		{
			// Delete all old card game objects
			foreach(GameObject card in _cardsInHand)
			{
				Destroy(card);
			}
			_cardsInHand.Clear();
			
			_numCards =  (_numCards + 1) % 7;
			
			if (_numCards > 0)
			{
				GenerateCards();
			}
		}
		GUILayout.EndArea();
	}
	
	
}