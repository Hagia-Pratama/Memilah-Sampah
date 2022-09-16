using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPindah : MonoBehaviour {

	float speed = 1f;
	public Sprite[] sprites;
	private Vector3 screenPoint; //nilai mouse (X,y,z)
	private Vector3 offset; //selisih nilai mouse dengan object
	private float firstY;//nilai vertical awal

	// Use this for initialization
	void Start () {
		int index = Random.Range(0, sprites.Length); //nomor random
		gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index]; //render sprite random
	}
	
	// Update is called once per frame
	void Update () {
		float move = (speed * Time.deltaTime * -1f) + transform.position.x;
		transform.position = new Vector3(move, transform.position.y);
	}

	void OnMouseDown(){
		firstY = transform.position.y;
		screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
	private void OnMouseUp(){
		transform.position = new Vector3(transform.position.x,firstY, transform.position.z);
	}
}  
