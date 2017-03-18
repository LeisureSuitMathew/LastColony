using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HandManager : MonoBehaviour {

	public GameObject cardPrefab;
	public Transform handTransform;
	//public List<Transform> cardsInHand = new List<Transform> ();

	public float tickrateMin;
	public float tickrateMax;
	float lastTick;

	Transform tmpCard;

	void Start () 
	{

	}
	
	void Update () 
	{
		if (lastTick <= 0)
		{
			if (BaseController.Instance.cards < BaseController.Instance.maxCards)
			{
				BaseController.Instance.cards++;

				tmpCard = ((GameObject)(GameObject.Instantiate (cardPrefab))).transform;
				tmpCard.SetParent(handTransform);
				//cardsInHand.Add (tmpCard);
				tmpCard.GetComponent<Toggle> ().group = GetComponent<ToggleGroup> ();
			}

			lastTick = Random.Range(tickrateMin, tickrateMax);

			//PLACEHOLDER! dodawanie wartości decay dla FOOD przy wpuszczaniu kosmity na stację
			BaseController.Instance.needs[0].ChangeMe();
		}

		lastTick -= Time.deltaTime;
	}
}
