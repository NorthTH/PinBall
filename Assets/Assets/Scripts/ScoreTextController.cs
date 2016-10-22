using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour {

	int CurrentScore = 0; //現在得点

	//得点を表示するテキスト
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		//シーン中のscoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		//CurrentScoreをシーンに表示する
		this.scoreText.GetComponent<Text> ().text = "Score : " + CurrentScore;
	}

	//CurrentScoreに加算する関数
	public void AddScore(int score)
	{
		//CurrentScoreにをsScore加算する
		this.CurrentScore += score;
	}
}
