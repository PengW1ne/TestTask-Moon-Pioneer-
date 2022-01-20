using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour{
	private Vector2Int GridSize = new Vector2Int(5, 3);
	public Factory Factory;
	public int MaxResourceCount;

	public List<Resource> ProducedResourcesList;
	private int row;
	private int column;
	[HideInInspector] public float TimeForDeliver = 1f;
	[HideInInspector] public bool isDeliver;


	public void Start(){
		TimeForDeliver /= Factory.Level;
		row = 0;
		column = 0;
	}

	public IEnumerator AddResource(Resource resource){
		column = (1 * Factory.currentResourceCount) % GridSize.x;
		if (Factory.currentResourceCount % 5 == 0 && Factory.currentResourceCount != 0){
			row += 1;
		}
		var timer = TimeForDeliver;
		resource = Instantiate(resource, transform);
		while (timer > 0){
			resource.transform.position = Vector3.Lerp(Factory.transform.localPosition, new Vector3(transform.position.x + row, 0, transform.position.z + column), (TimeForDeliver - timer) / TimeForDeliver);
			timer -= Time.deltaTime;
			yield return null;
		}
		ProducedResourcesList.Add(resource);
		Factory.currentResourceCount += 1;
	}




	private void OnTriggerStay(Collider other){
		if (other.TryGetComponent(out Inventory playerInventory)){
			if (ProducedResourcesList.Count > 0 && !isDeliver){
				if (playerInventory.currentResourceCount < playerInventory.MaxResourceCount){
					StartCoroutine(playerInventory.AddResourceToInventory(this, playerInventory.currentResourceCount));
					isDeliver = true;
				}
			}
		}
	}
}