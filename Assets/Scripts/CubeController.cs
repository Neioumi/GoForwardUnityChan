using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	// キューブの移動速度
	private float speed = -0.2f;
	// 消滅位置
	private float deadLine = -10;
	// 効果音用のコンポーネントを入れる
	private AudioSource cubeSound;

	// Use this for initialization
	void Start () {
		// AudioSourceのコンポーネントを取得
		cubeSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate(this.speed, 0, 0);
		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy(gameObject);
		}
	}

	// キューブが接触した時
	void OnCollisionEnter2D(Collision2D other) {
		// キューブが、キューブまたは地面と接触した時（タグで判定）
		if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Ground") {
			Debug.Log("キューブまたは地面と接触");
			// 音声ファイルを再生
			cubeSound.PlayOneShot(cubeSound.clip);
		} else if (other.gameObject.tag == "UnityChan") {
			Debug.Log("Unityちゃんと接触");
		}
	}
}
