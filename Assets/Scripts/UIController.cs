using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	// ゲームオーバーテキスト
	private GameObject gameOverText;
	// 走行距離テキスト
	private GameObject runLengthText;
	// 最高記録テキスト
	private GameObject bestRecordText;
	// 走行距離
	private float len = 0;
	// 最高記録
	private float bestRecord = 0;
	// 走る速度
	private float speed = 0.03f;
	// ゲームオーバー判定
	private bool isGameOver = false;
	// ハイスコア保存用キー
	private string key = "BestRecord";

	// Use this for initialization
	void Start () {
		// シーンビューからオブジェクトの実体を検索
		this.gameOverText = GameObject.Find("GameOver");
		this.runLengthText = GameObject.Find("RunLength");
		this.bestRecordText = GameObject.Find("RecordText");

		// 最高記録の値を、PlayerPrefsから読み出し。nullだったら0を返す
		this.bestRecord = PlayerPrefs.GetFloat(key, 0);
		// 最高記録を表示
		this.bestRecordText.GetComponent<Text>().text = "Best Record: " + bestRecord.ToString("F2") + "m";
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			// 走行距離を更新
			this.len += this.speed;
			// 走行距離を表示
			// ToString("F2")で、小数以下第2位まで表示
			this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
		}

		// 走行距離が最高記録を超えていたら
		if (len > bestRecord) {
			Debug.Log("最高記録更新！");
			Debug.Log("bestRecord: "+ bestRecord);
			// 最高記録を更新
			bestRecord = len;
			// Player Prefsに値を保存
			PlayerPrefs.SetFloat(key, bestRecord);
			// 最高記録を表示
			this.bestRecordText.GetComponent<Text>().text = "Best Record: " + bestRecord.ToString("F2") + "m";
		}

		// ゲームオーバー時
		if (this.isGameOver) {
			// 画面をクリックしたら
			if (Input.GetMouseButtonDown(0)) {
				// GameSceneを読み込む
				SceneManager.LoadScene("GameScene");
			}
		}
	}

	public void GameOver () { // public が無いと、他から参照できない
		this.gameOverText.GetComponent<Text>().text = "GameOver";
		this.isGameOver = true;
	}
}
