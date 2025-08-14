using UnityEngine;

public class WaitForActionState : State
{
    
    public override void Enter()
    {
        // Logic for entering the wait for action state
    }
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CombatManager.Instance.m_PlayerMove = CombatManager.Instance.playerPokemon.UseRandomMove();
        }
    }
    public override void FixedUpdate()
    {
      if (IsActionChosen())
        {
            CombatManager.BuildTurnQueue();
        }
       
    }
    public override void Exit()
    {
        // Logic for exiting the wait for action state
    }
    public bool IsActionChosen() => CombatManager.Instance.m_PlayerMove != null;
}
