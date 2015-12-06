using UnityEngine;
using System.Collections;

public class Switch: MonoBehaviour{

	public void SwitchLevel (int level)
	{
		Application.LoadLevel (level);
	}
}
