public abstract class GameManagerState : IManagerState
{
	protected GameManagerStateMachine _stateMachine;
	protected GameManager _owner;
	protected UIScriptableObject _uiScriptableObject;
	protected DeckScriptableObject _deckScriptableObject;
	protected PlayerScriptableObject _playerScriptableObject;
	protected NpcScriptableObject[] _npcScriptableObjects;
	protected GunScriptableObject _gunScriptableObject;

	public GameManagerState(GameManager owner)
	{
		_owner = owner;
		_stateMachine = owner.stateMachine;
		_uiScriptableObject = owner.uiScriptableObject;
		_deckScriptableObject = owner.deckScriptableObject;
		_playerScriptableObject = owner.playerScriptableObject;
		_npcScriptableObjects = owner.npcScriptableObjects;
		_gunScriptableObject = owner.gunScriptableObject;
	}
	public virtual void Enter() {}
	public virtual void Execute() {}
	public virtual void Exit() {}
	protected void changeState(GameManagerState newState)
	{
		_stateMachine.ChangeState(newState);
	}
	public virtual void OnGUI(){}
}