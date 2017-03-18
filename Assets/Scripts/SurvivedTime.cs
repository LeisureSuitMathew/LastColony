using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivedTime : MonoBehaviour {

	public float hourScale;
	public bool dead;

	float lastTick;

	int hours;
	int days;
	int months;
	int years;

	void Start ()
	{
		dead = false;
		hours = 0; days = 0; months = 0; years = 0;
		lastTick = hourScale;
	}
	
	void Update () 
	{
		dead = BaseController.Instance.dead;

		if (dead)
			return;

		if (lastTick <= 0) 
		{
			hours++;
			lastTick = hourScale;
		}

		if (hours == 24) 
		{
			hours = 0;
			days++;
		}
		if (days == 30) 
		{
			days = 0;
			months++;
		}
		if (months == 12) 
		{
			months = 0;
			years++;
		}

		lastTick -= Time.deltaTime;
	}

	public string GiveTime ()
	{
		return "" + years + " years " + months + " months " + days + " days " + hours + " hours";
	}
}
