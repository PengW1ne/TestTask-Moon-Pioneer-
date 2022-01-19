using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour{
	public int Level;
	[SerializeField]private float DefTimeForProduced;
	[HideInInspector]public float TimeForProduced;
	[HideInInspector]public int currentResourceCount;
	public Resource producedResourcePrefab;

	public Storage StorageForProduced;
	private bool isProduced;
	private void Start(){
		TimeForProduced = DefTimeForProduced / Level;
		currentResourceCount = 0;
	}
	
	private void FixedUpdate(){
		if (currentResourceCount < StorageForProduced.MaxResourceCount && !isProduced){
			StartCoroutine(StartWork());
		}
	}

	public IEnumerator StartWork(){
		isProduced = true;
		while (currentResourceCount < StorageForProduced.MaxResourceCount){
			yield return new WaitForSeconds(TimeForProduced);
			StartCoroutine(StorageForProduced.AddResource(producedResourcePrefab));
			currentResourceCount += 1;
		}
		isProduced = false;
	}
}
