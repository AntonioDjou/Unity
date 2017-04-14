using UnityEngine;
using System.Collections;

public class TiroLaserScript : MonoBehaviour {

	public float taxaTiro = 0.25f;									// Tempo em segs de controle do disparo
	public Transform ponta;											// Referência a ponteira da arma

	private LineRenderer laser;										// Mira Laser
	private Camera fpsCamera;										// Referência à câmera do FPS
	private WaitForSeconds duracao = new WaitForSeconds(0.07f);		// Determina o tempo do tiro
	private AudioSource tiroAudio;									// Referência ao audio do tiro
	private float proxTiro;											// Tempo que o jogador poderá atirar novamente

	private float impacto = 100f;
	private float alcance = 30f;


	void Start () {
		tiroAudio = GetComponent<AudioSource>();
		fpsCamera = GetComponentInParent<Camera>();
		laser = GetComponent<LineRenderer>();
		laser.enabled = false;
	}


	void FixedUpdate () {
		Vector3 origem = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		laser.SetPosition(0, ponta.position);

		if (Input.GetButtonDown("Fire1") && Time.time > proxTiro) {
			proxTiro = Time.time + taxaTiro;

			RaycastHit contato;
			if (Physics.Raycast(origem, fpsCamera.transform.forward, out contato, alcance)) {
				laser.SetPosition(1, contato.point);
				if (contato.rigidbody != null) {
					contato.rigidbody.AddForce(-contato.normal * impacto);
				}
			} else {
				laser.SetPosition(1, origem + (fpsCamera.transform.forward * alcance));
			}

			StartCoroutine (ShotEffect());
		}
	}

	private IEnumerator ShotEffect() {
		laser.enabled = true;
		tiroAudio.Play();
		yield return duracao;
		laser.enabled = false;
	}
}
