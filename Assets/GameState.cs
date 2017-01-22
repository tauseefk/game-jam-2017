using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameState : MonoBehaviour
{

	public static GameState instance;

	public static int devilScore { get; private set; }
	public static int angelScore { get; private set; }
    public static float audioTime { get; set; }


	void Start()
	{
		instance = this;
		devilScore = 0;
		angelScore = 0;
	}

	public static void incrementAngelScore()
	{
		angelScore++;
	}

	public static void incrementDevilScore()
	{
		devilScore++;
	}
}
