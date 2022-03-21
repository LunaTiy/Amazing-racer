using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject _player;
	[SerializeField] private GameObject _spawnPoint;

	private Transform _playerTransform;
	private Transform _spawnPointTransform;

	private float elapsedTime = 0;
	private bool isRunning = false;
	private bool isFinished = false;

	void Start ()
	{
		_playerTransform = _player.GetComponent<Transform>();
		_spawnPointTransform = _spawnPoint.GetComponent<Transform>();

		_player.SetActive(false);
	}

	private void Update()
	{
		if (isRunning)
		{
			elapsedTime = elapsedTime + Time.deltaTime;
		}
	}

	private void OnGUI()
	{
		if (!isRunning)
		{
			string message;

			if (isFinished)
			{
				message = "Click or Press Enter to Play Again";
			}
			else
			{
				message = "Click or Press Enter to Play";
			}

			Rect startButton = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

			if (GUI.Button(startButton, message) || Input.GetKeyDown(KeyCode.Return))
			{
				StartGame();
			}
		}

		if (isFinished)
		{
			GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "Your Time Was");
			GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)elapsedTime).ToString());
		}
		else if (isRunning)
		{
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
		}
	}

	private void StartGame()
	{
		elapsedTime = 0;
		isRunning = true;
		isFinished = false;

		_player.SetActive(true);
		PositionPlayer();
	}	

	public void PositionPlayer()
	{
		_playerTransform.position = _spawnPointTransform.position;
	}

	public void FinishedGame()
	{
		isRunning = false;
		isFinished = true;
		_player.SetActive(false);
	}
}
