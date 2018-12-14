using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void LoadScene(string Instruction){

		SceneManager.LoadScene (Instruction);
	}
}
