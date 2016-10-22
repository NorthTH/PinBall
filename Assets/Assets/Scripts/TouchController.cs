using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	//画面の真ん中より左側でタップしたこと確認する
	public static bool isLeftTouchBegin()
	{
		foreach (Touch touch in Input.touches) {
			//1つのtouchが真ん中より左側にあるが確認できれば当てはまる。
			if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began)
				return true;
		}
		return false;
	}

	//画面の真ん中より右側でタップしたこと確認する
	public static bool isRightTouchBegin()
	{
		foreach (Touch touch in Input.touches) {
			//1つのtouchが真ん中より右側にあるが確認できれば当てはまる。
			if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began)
				return true;
		}
		return false;
	}

	//画面の真ん中より左側でタップが終わったこと確認する
	public static bool isLeftTouchEnd()
	{
		foreach (Touch touch in Input.touches) {
			//1つのtouchが真ん中より左側に離れたが確認できれば当てはまる。
			if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Ended)
				return true;
		}
		return false;
	}

	//画面の真ん中より右側でタップが終わったこと確認する
	public static bool isRightTouchEnd()
	{
		foreach (Touch touch in Input.touches) {
			//1つのtouchが真ん中より右側に離れたが確認できれば当てはまる。
			if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Ended)
				return true;
		}
		return false;
	}
}
