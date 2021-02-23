using UnityEngine;
using System.Collections.Generic;
public class WeaponSwapping : MonoBehaviour {
	public int selectedWeapon = 0;
	// Use this for initialization

	private Inventory guns; 
	void Start () {
		guns = GetComponent<Inventory>();
		selectWeapon();
	}
	
	// Update is called once per frame
	void Update () {

		int previousSelectedWeapon = selectedWeapon;
		if(Input.GetAxis("Mouse ScrollWheel") > 0f){
			if (selectedWeapon >= transform.childCount - 1) {
				selectedWeapon = 0;
			} else {
				selectedWeapon++;
			}

		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0f){
			if (selectedWeapon <= 0) {
				selectedWeapon = transform.childCount - 1;
			} else {
				selectedWeapon--;
			}

		}
		if(previousSelectedWeapon!= selectedWeapon){
			if(checkWeapon(selectedWeapon)){
				selectWeapon();
			}

			else{
				selectedWeapon = previousSelectedWeapon;
			}
			
		}

	}

	void selectWeapon(){

		int i = 0;
		foreach (Transform weapon in transform) {
			if (i == selectedWeapon && weapon.gameObject.GetComponent<Weapon>() && weapon.gameObject.GetComponent<Weapon>().found) {
				weapon.GetComponent<Weapon>().held = true;
				weapon.transform.GetComponent<MeshRenderer>().enabled = true;
			} else {
				weapon.GetComponent<Weapon>().held = false;
				weapon.transform.GetComponent<MeshRenderer>().enabled = false;
			}
			i++;
		}
	}

	bool checkWeapon(int _nextWeapon){
		if(guns.bag[_nextWeapon].GetComponent<Weapon>().found){
			return true;
		}
		else{
			return false;
		}
	}
	
}
