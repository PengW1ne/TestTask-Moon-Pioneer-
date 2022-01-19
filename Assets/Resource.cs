using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour{
	public Vector2Int Size;

	private void OnDrawGizmosSelected(){
		for (int y = 0; y < Size.x; y++){
			for (int x = 0; x < Size.y; x++){
				Gizmos.color = new Color(0f, 0f, 1f, 0.39f);
				Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1,.1f,1));
			}
		}
	}
}