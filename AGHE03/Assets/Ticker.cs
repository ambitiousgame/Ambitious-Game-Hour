using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ticker : MonoBehaviour {
	public Text ticker;
	public string[] items;
	public float[] MinMoney;
	public float[] MaxMoney;
	public float[] MinHoes;
	public float[] MaxHoes;
	public float[] MinHustler;
	public float[] MaxHustler;
	public float[] WinMoney;
	public float[] WinHoes;
	public float[] WinHustler;
	public float multiplier;
	public float speedIncrease;
	public float minTick;
	public float maxTick;
	public Clicker Money;
	public Clicker Hoes;
	public Clicker Hustler;
	private float since;
	private float till;
	private int numTicks;

	// Use this for initialization
	void Start () {
		since = 0;
		till = Random.Range(minTick,maxTick);
		numTicks = 0;
	}
	
	// Update is called once per frame
	void Update () {
		multiplier += speedIncrease * Time.deltaTime;
		if(since > till) {
			AddTick();
			since = 0;
		}
		since += Time.deltaTime;
	}
	public void AddTick() {
		int item = Random.Range(0,items.Length);
		if(numTicks > 4) {
			ticker.text = "";
			numTicks = 0;
		}
		var needMoney =  GetValue(MinMoney[item],MaxMoney[item]);
		var needHoes = GetValue(MinHoes[item],MaxHoes[item]);
		var needHustler = GetValue(MinHustler[item],MaxHustler[item]);
		ticker.text = ticker.text + "\n" + string.Format(items[item],
		                                   needMoney,
		                                   needHoes ,
		                                   needHustler );
		Debug.Log(string.Format("{0} {1} {2} {3}",needMoney,
		          needHoes ,
		          needHustler,
		                        Hustler.numberOfObjects));
		if (Money.numberOfObjects > needMoney &&
		    Hoes.numberOfObjects > needHoes &&
		    Hustler.numberOfObjects > needHustler) {
			Debug.Log(string.Format("HERE"));
			Money.AddValue(WinMoney[item]);
			Hoes.AddValue(WinHoes[item]);
			Hustler.AddValue(WinHustler[item]);
		}

		numTicks++;
	}

	public float GetValue(float min, float max) {
		return Random.Range(min,max);
	}
}
