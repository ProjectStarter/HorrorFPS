using UnityEngine;
using UnityEditor;

public class DeletePlayerPrefs : EditorWindow
{
	[MenuItem ("Tools/Delete PlayerPrefs")]
	static void CreateWizard()
	{
		if (EditorUtility.DisplayDialog("Delete PlayerPrefs?", "This will delete all saved PlayerPrefs. Continue?", "Yes", "No"))
		{
			PlayerPrefs.DeleteAll();
			Debug.LogError ("[UnityEditor - DeletePlayerPrefs] Deleted playerprefs data.");
		}

		else
		{
			Debug.LogError("[UnityEditor - DeletePlayerPrefs] Deletion Cancelled.");
		}
	}
}