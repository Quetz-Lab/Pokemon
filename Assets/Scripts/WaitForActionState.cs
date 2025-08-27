using UnityEngine;

public class WaitForActionState : State
{
    
    public override void Enter()
    {
        CombatManager.Instance.turnQueue.Clear();
        CombatManager.Instance.playerPokemon.m_Animator.CrossFadeInFixedTime("Idle", 0.2f);
        CombatManager.Instance.enemyPokemon.m_Animator.CrossFadeInFixedTime("Idle", 0.2f);
        CombatManager.Instance.m_PlayerMove = null;
        // Logic for entering the wait for action state
    }
    public override void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {  
            CombatManager.Instance.m_PlayerMove = CombatManager.Instance.playerPokemon.UseRandomMove();
            CombatManager.BuildTurnQueue();
            Debug.Log("Action chosen by player.");
        }
    }
    public override void FixedUpdate()
    {
      if (IsActionChosen())
        {
            CombatManager.PlayNextTurn();
        }
       
    }
    public override void Exit()
    {
        // Logic for exiting the wait for action state
    }
    public bool IsActionChosen() => CombatManager.Instance.m_PlayerMove != null;
}
