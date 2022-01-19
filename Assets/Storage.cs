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
	private float TimeForDeliver = 1f;

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
		resource = Instantiate(resource,transform);
		ProducedResourcesList.Add(resource);
		while (timer > 0){
			resource.transform.localPosition = Vector3.Lerp(new Vector3(-3, 3, 2),new Vector3(row, 0, column),(TimeForDeliver - timer) / TimeForDeliver);
			timer -= Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator AddResourceToInventory(){
		
		yield return null;
	}
}

