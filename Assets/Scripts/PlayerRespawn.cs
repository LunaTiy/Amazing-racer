using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
	[SerializeField] GameManager _gameManager; 

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player")
			_gameManager.PositionPlayer();
	}
}
