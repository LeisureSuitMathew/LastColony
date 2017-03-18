using UnityEngine;
using System.Collections;

public class BaseController : MonoBehaviour {

	public BaseNeeds[] needs;
	public Panic panic;
	public SurvivedTime survivedTime;
	public Card activeCard;

	public int cards;
	public int maxCards;

	public bool[] criticalLevels;

	public bool dead;

	private static BaseController instance = null;

	public static BaseController Instance
	{
		get
		{ 
			return instance; 
		}
	}

	private void Awake()
	{
		if (instance != null && instance != this) 
		{
			Destroy(this.gameObject);
		}

		instance = this;
		DontDestroyOnLoad( this.gameObject );
	}

	void Start () 
	{
		dead = false;
		criticalLevels = new bool[needs.Length];
	}
	
	void Update () 
	{
		for (int i=0; i < needs.Length; i++)
		{
			criticalLevels[i] = needs[i].CheckCriticalLevel();
		}
	}

	public float GiveNeed (int need)
	{
		return needs[need].value;
	}
}
