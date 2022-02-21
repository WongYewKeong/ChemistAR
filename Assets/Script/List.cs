using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonExtension
{
	public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener (delegate() {
			OnClick (param);
		});
	}
}

public class List : MonoBehaviour
{
   [Serializable]
	public struct Experiment
	{
		public string Exp;
		public string Name;
		
	}

	[SerializeField] Experiment[] allExp;

	void Start ()
	{
		GameObject buttonTemplate = transform.GetChild (0).gameObject;
		GameObject g;

		int N = allExp.Length;

		for (int i = 0; i < N; i++) {
			g = Instantiate (buttonTemplate, transform);
			g.transform.GetChild (0).GetComponent <Text> ().text = allExp [i].Exp;
			g.transform.GetChild (1).GetComponent <Text> ().text = allExp [i].Name;

			/*g.GetComponent <Button> ().onClick.AddListener (delegate() {
				ItemClicked (i);
			});*/
			g.GetComponent <Button> ().AddEventListener (i, ItemClicked);
		}

		Destroy (buttonTemplate);
	}

	void ItemClicked (int itemIndex)
	{
		Debug.Log ("------------item " + itemIndex + " clicked---------------");
		Debug.Log ("exp " + allExp[itemIndex].Exp);
		Debug.Log ("name " + allExp [itemIndex].Name);
	}
}
