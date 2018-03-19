using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {
	public string aName;
	public float baseDamage;
	public abstract void Launch();
	
}
