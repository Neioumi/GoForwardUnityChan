using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {
	// キューブのPrefab
	public GameObject cubePrefab;
	// 時間計測用
	private float delta = 0;
	// キューブの生成間隔
	private float span = 1.0f;
	// キューブの生成位置（X座標）
	private float genPosX = 12;
	// キューブの生成位置オフセット
	private float offsetY = 0.3f;
	// キューブの縦方向の間隔
	private float spaceY = 6.9f;
	// キューブの生成位置オフセット
	private float offsetX = 0.5f;
	// キューブの横方向の間隔
	private float spaceX = 0.4f;
	// キューブの生成個数上限
	private int maxBlockNum = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// フレーム間の時間の差分（Time.deltaTime）をdeltaに足す
		this.delta += Time.deltaTime;
		if (this.delta > this.span) {
			this.delta = 0;
			// 生成数をランダムに決める
			int n = Random.Range(1, maxBlockNum+1);

			for (int i = 0; i < n; i++) {
				GameObject go = Instantiate(cubePrefab) as GameObject;
				go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
			}
			// 次のキューブまでの生成時間を決める
			this.span = this.offsetX + this.spaceX * n;
		}
	}
}
