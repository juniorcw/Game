using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour 
{
	[SerializeField] private string loadLevel;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) 
		{
			SceneManager.LoadScene (loadLevel);
		}
	}
}
