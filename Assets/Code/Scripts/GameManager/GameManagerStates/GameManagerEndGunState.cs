using UnityEngine;

public class GameManagerEndGunState : GameManagerState
{
	
	GamePlayerScriptableObject _targetPlayerScriptableObject;
	
	public GameManagerEndGunState(GameManager owner, GamePlayerScriptableObject targetPlayer) : base(owner) { 
		_targetPlayerScriptableObject = targetPlayer;
	}

	public override void Enter()
	{
		Debug.LogError($"Done with gun phase! New dealer will be: {_targetPlayerScriptableObject.GetPlayerName()}");
	}

	override public void Execute() 
	{ 

		

	}
	
	public override void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10, 10, 500, 500));
		GUILayout.Label($"EndGunState with Target: {_targetPlayerScriptableObject.GetPlayerName()}");
		GUILayout.EndArea();
	}
	
	
}