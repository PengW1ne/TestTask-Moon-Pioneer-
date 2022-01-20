using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{
	
	public int MaxResourceCount;
	public Transform InventoryHolder;
	[HideInInspector]public int currentResourceCount = 0;
	
	public IEnumerator AddResourceToInventory(Storage storage,int y){
		storage.Factory.currentResourceCount = Math.Max(storage.Factory.currentResourceCount - 1, 0);
		var timer = storage.TimeForDeliver;
		var resource = storage.ProducedResourcesList[storage.ProducedResourcesList.Count - 1];
		var startPosition = resource.transform.position;

		while (timer > 0){
			resource.transform.position = Vector3.Lerp(startPosition,new Vector3(InventoryHolder.position.x,y,InventoryHolder.position.z) , (storage.TimeForDeliver - timer) / storage.TimeForDeliver);
			resource.transform.parent = InventoryHolder;
			timer -= Time.deltaTime;
			yield return null;
		}
		currentResourceCount += 1;
		storage.ProducedResourcesList.Remove(resource);
		storage.isDeliver = false;
	}
}
