using UnityEngine;
using UnityEditor;
using System.Collections;

public class PositionManager : MonoBehaviour {
		
	//Define a menu option in the editor to create the new asset
	[MenuItem("Assets/Create/PositionManager")]
	public static void CreateAsset(){
		//Create a new instance of our scriptable object
		ScriptingObjects positionManager = ScriptableObject.CreateInstance<ScriptingObjects>();

		AssetDatabase.CreateAsset(positionManager, "Assets/newPositionManager.asset");
		AssetDatabase.SaveAssets();

		//Now switch the inspector to our new object
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = positionManager;
	}

	public static PositionManager ReadPositionsFromAsset(string Name){
		string path = "/";
		object o = Resources.Load (path + Name);
		PositionManager retrievedPositions = (PositionManager)o;
		return retrievedPositions;
	}

}
