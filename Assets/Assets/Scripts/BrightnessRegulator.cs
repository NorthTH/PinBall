using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BrightnessRegulator : MonoBehaviour {

	// Materialを入れる
	Material myMaterial;

	// Emissionの最小値
	private float minEmission = 0.3f;
	// Emissionの強度
	private float magEmission = 2.0f;
	// 角度
	private int degree = 0;
	//発光速度
	private int speed = 10;
	// ターゲットのデフォルトの色
	Color defaultColor = Color.white;

	// 得点を表示課題追加
	private ScoreTextController STC;

	// Use this for initialization
	void Start () {

		// タグによって光らせる色を変える
		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		}else if(tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.defaultColor = Color.blue;
		}

		//オブジェクトにアタッチしているMaterialを取得
		this.myMaterial = GetComponent<Renderer> ().material;

		//オブジェクトの最初の色を設定
		myMaterial.SetColor ("_EmissionColor", this.defaultColor*minEmission);

		// 得点を表示課題追加
		STC = GameObject.Find("ScoreText").GetComponent<ScoreTextController> ();
	}

	// Update is called once per frame
	void Update () {

		if (this.degree >= 0) {
			// 光らせる強度を計算する
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);

			// エミッションに色を設定する
			myMaterial.SetColor ("_EmissionColor", emissionColor);

			//現在の角度を小さくする
			this.degree -= this.speed;
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		//角度を180に設定
		this.degree = 180;

		getScore (); // 得点を表示課題追加
	}

	void getScore() // 得点を表示課題追加
	{
		//ScoreTextControllerの「AddScore」の関数を呼び出し、Scoreを加算する
		if (tag == "SmallStarTag") {
			STC.AddScore (10);
		} else if (tag == "LargeStarTag") {
			STC.AddScore (20);
		}else if(tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			STC.AddScore (30);
		}
	}
}
