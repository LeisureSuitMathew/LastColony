using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	//Toggle toggle;
	[HideInInspector] public Worker worker;
	public Text cardText;

	public float minDiscoveryTime;
	public float maxDiscoveryTime;

	float lastTick;

	string [] skillsDisplay;

	void Start () 
	{
		//toggle = GetComponent<Toggle>();
		worker = GetComponent<Worker>();

		lastTick = Random.Range (minDiscoveryTime, maxDiscoveryTime);

		skillsDisplay = new string[5];

		for (int i = 0; i < skillsDisplay.Length; i++) 
		{
			skillsDisplay [i] = "?";
		}
		cardText.text = "Cooking: " + skillsDisplay[0] + "\nElectr.: " + skillsDisplay[1] + "\nScience: " + skillsDisplay[2];
	}
	

	void Update ()
	{
		if (lastTick <= 0) 
		{
			DiscoverSkill ();
			lastTick = Random.Range (minDiscoveryTime, maxDiscoveryTime);
		}
		lastTick -= Time.deltaTime;

		cardText.text = "Cooking: " + skillsDisplay[0] + "\nElectr.: " + skillsDisplay[1] + "\nScience: " + skillsDisplay[2];
	}

	public void DiscoverSkill ()
	{
		bool leftToDiscover = false;
		for (int i = 0; i < skillsDisplay.Length; i++) 
		{
			if (skillsDisplay [i] == "?")
				leftToDiscover = true;
		}
		if (!leftToDiscover)
			return;

		bool done = false;
		while (!done) 
		{
			int r = Random.Range (0, skillsDisplay.Length);
			if (skillsDisplay [r] == "?") 
			{
				skillsDisplay [r] = ""+(int)worker.Skills () [r];
				done = true;
			}
		}
	}

	public void CardSelected(bool isOn)
	{
		Debug.Log ("Card selected " + transform.name + "    " + isOn);
		if (!isOn)
			BaseController.Instance.activeCard = null;
		if (isOn)
			BaseController.Instance.activeCard = this;
	}


}
