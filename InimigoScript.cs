using UnityEngine;
using System.Collections;

public class InimigoScript : MonoBehaviour {
	float veloc = 5f; 
	const float LIMITE_VERTICAL = 6.40f; 
	const float LIMITE_HORIZONTAL = 7.00f;
	public GameObject explosao;

	void Start () {
		Reposicionar();
	}

	void Update () {
		transform.Translate(0, veloc * Time.deltaTime, 0);

		if (transform.position.y <= -LIMITE_VERTICAL ){
			Reposicionar();
		}
	}

	void Reposicionar(){
		float x = Random.Range(-LIMITE_HORIZONTAL, LIMITE_HORIZONTAL);
		transform.position = new Vector3(x, LIMITE_VERTICAL ,0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag.Equals("Bala")){
			PlacarManager.placar++;
		} 
		Instantiate(explosao, transform.position, transform.rotation);
		Reposicionar();
	}
}
