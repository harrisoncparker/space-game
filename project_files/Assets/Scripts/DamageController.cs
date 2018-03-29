using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour 
{
	public int totalHealth;
	private int currentHealth;
	private void Start() 
	{
		currentHealth = totalHealth;
	}

	public void takeDamage(int damage) 
	{
		currentHealth = currentHealth - damage;
		if(currentHealth <= 0) {
			this.destroySelf();
		}
	}

	private void destroySelf ()
	{
		Object.Destroy(this.gameObject);
	}

}
