using UnityEngine;

public class Turn
{
    PokemonInformation m_Attacker;
    PokemonInformation m_Receiver;
    PokemonMove m_MoveUsed;

    State m_Attack;
    State m_GetDamaged;

    public Turn(PokemonInformation p_Attacker,PokemonInformation p_Receiver, PokemonMove p_MoveUsed)
    {
        m_Attacker = p_Attacker;
        m_Receiver = p_Receiver;
        m_MoveUsed = p_MoveUsed;
        m_Attack = new AttackState(this);
        m_GetDamaged = new GetDamagedState(this);
    }
     public void StartTurn()
    {

        CombatManager.Instance.ChangeState(m_Attack);
    }
    public class AttackState : State
    {
        Turn m_Turn;

        public AttackState(Turn p_Turn)
        {
            m_Turn = p_Turn;
        }
        public override void Enter()
        {
            Debug.Log($"{m_Turn.m_MoveUsed.name} used {m_Turn.m_MoveUsed.MoveName} on {m_Turn.m_Receiver.Name}!");
            
        }
        public override void Update()
        {

        }

        public override void FixedUpdate()
        {
           CombatManager.Instance.ChangeState(m_Turn.m_GetDamaged);
        }
        public override void Exit()
        {

        }
    }

    public class GetDamagedState : State
    {
        Turn m_Turn;
        public GetDamagedState(Turn p_Turn)
        {
            m_Turn = p_Turn;
        }
        public override void Enter()
        {
            int damage = CombatManager.CalculateDamage(m_Turn.m_MoveUsed, m_Turn.m_Attacker, m_Turn.m_Attacker);
            m_Turn.m_Receiver.GetDamaged(damage);
            Debug.Log($"{m_Turn.m_Receiver.Name} took {damage} damage!");
        }
        public override void Update()
        {

        }
        public override void FixedUpdate()
        {
            if (m_Turn.m_Receiver.CurrentHealth <= 0)
            {
                Debug.Log($"{m_Turn.m_Receiver.Name} fainted!");
                CombatManager.Instance.ChangeState(new WaitForActionState());
            }
            else
            {
                CombatManager.PlayNextTurn();
                CombatManager.Instance.ChangeState(new WaitForActionState());
            }
        }
        public override void Exit()
        {

        }
    }
}
