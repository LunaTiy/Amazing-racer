using UnityEngine;

public class FinishZone : MonoBehaviour
{
	[SerializeField] private GameManager _gameManager;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player")
			_gameManager.FinishedGame();
	}
}
