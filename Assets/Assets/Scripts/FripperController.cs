using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {

	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoynt;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HinjiJointコンポーネント取得
		this.myHingeJoynt = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす //左タップした時を追加
		if ((Input.GetKeyDown (KeyCode.LeftArrow) || TouchController.isLeftTouchBegin ()) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす　//右タップした時を追加
		if ((Input.GetKeyDown (KeyCode.RightArrow) || TouchController.isRightTouchBegin ()) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow) ||
			(TouchController.isLeftTouchEnd () && tag == "LeftFripperTag") ||  //左タップが終わった時を追加
			TouchController.isRightTouchEnd () && tag == "RightFripperTag") {  //右タップが終わった時を追加
			SetAngle (this.defaultAngle);
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoynt.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoynt.spring = jointSpr;
	}
}
