using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AbilityCooldowns : MonoBehaviour {

	public List<Skill> skills;

	void Update() {
		foreach(Skill s in skills) {
			if(s.currentCooldown < s.cooldown) {
				s.currentCooldown += Time.deltaTime;
				s.abilityIcon.fillAmount = s.currentCooldown / s.cooldown;
			}
		}
	}
	public bool AbilityReady(int abilityIndex) {
		return(skills[abilityIndex].currentCooldown >= skills[0].cooldown);
	}
	public void StartCooldown(int abilityIndex) {
		skills[abilityIndex].currentCooldown = 0;
	}
}


[System.Serializable]
public class Skill {
	public float cooldown;
	public Image abilityIcon;
	public float currentCooldown;
}
