using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class buildings : MonoBehaviour,IGvrGazeResponder {
	private Color startColor;
	private Color newColor;
	private GameController gameController;
	void Update(){
	//	Debug.Log("Script0 ========= Update");
	}
	void Awake(){
		Debug.Log("Script0 ========= Awake");

	}
	void Start () {
		Debug.Log("Script0 ========= Start");
		//获取初始的颜色
		startColor = GetComponent<Renderer>().material.color;
		//模拟器的console打印颜色信息；
		Debug.Log(startColor);
		//获取Game Controller对象
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		} else {
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	//当用户注视物体时的主要业务逻辑
	public void SetGazedAt(bool gazedAt) {
		if (gazedAt) {
			TriggerColorToGreen (true); 
			TellMyName (true);
		} else {
			TriggerColorToGreen (false);
			TellMyName (false);
		}
	}

	//颜色改变触发器，true 变绿色，false 恢复初始值
	public void TriggerColorToGreen (bool triggered) {
		GetComponent<Renderer> ().material.color = triggered ? Color.green : startColor;
	}

	//说出本对象的名称
	public void TellMyName (bool asked) {
		if (asked) {
			gameController.showBuildingName (this.name);

		} else {
			Debug.Log ("don‘t tell you");
		}
	}
	#region 这里实现IGvrGazeResponder要求的方法

	//焦点注视物体的时候执行
	public void OnGazeEnter(){
		Debug.Log("Script0 ========= Onin");
		SetGazedAt(true);
		Debug.Log (name);
	}
	//焦点已开物体的时候执行
	public void OnGazeExit(){
		SetGazedAt (false);
		Debug.Log ("out");
	}
	//点击眼镜盒的触发器，也就是触摸屏幕的时候
	public void OnGazeTrigger(){
		Debug.Log ("触发");
	}
	#endregion
}
