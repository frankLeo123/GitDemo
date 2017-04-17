using UnityEngine;
using UnityEngine.UI;//引入GUI
using System.Collections;
public class GameController : MonoBehaviour {
	// 显示文字
	public Text buildingName;
	//画布上显示文字
	public void showBuildingName(string name){
		buildingName.text =  name;
	}
}