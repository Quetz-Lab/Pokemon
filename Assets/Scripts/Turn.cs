using UnityEngine;

public class Turn
{
    PokemonComponent m_Attacker;
    PokemonComponent m_Receiver;
    PokemonMove m_MoveUsed;

    State m_Attack;
    State m_GetDamaged;

    public Turn(PokemonComponent p_Attacker,PokemonComponent p_Receiver, PokemonMove p_MoveUsed)
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
        Timer timer;

        public AttackState(Turn p_Turn)
        {
            m_Turn = p_Turn;
        }
        public override void Enter()
        {
            Debug.Log($"{m_Turn.m_MoveUsed.name} used {m_Turn.m_MoveUsed.MoveName} on {m_Turn.m_Receiver.Information.Name}!");
            m_Turn.m_Attacker.PlayAnimation("Attack");
            timer = new Timer(1f);
        }
        public override void Update()
        {
           
        }

        public override void FixedUpdate()
        {
          
            timer.Tick(Time.fixedDeltaTime);
              if (timer.IsFinished)
            {
                CombatManager.Instance.ChangeState(m_Turn.m_GetDamaged);
            }
        }
        public override void Exit()
        {

        }
    }

    public class GetDamagedState : State
    {
        Turn m_Turn;
        Timer timer;
        public GetDamagedState(Turn p_Turn)
        {
            m_Turn = p_Turn;
        }
        public override void Enter()
        {
            int damage = CombatManager.CalculateDamage(m_Turn.m_MoveUsed, m_Turn.m_Attacker.Information, m_Turn.m_Receiver.Information);
            m_Turn.m_Receiver.Information.GetDamaged(damage);
            Debug.Log($"{m_Turn.m_Receiver.Information.Name} took {damage} damage!");
            m_Turn.m_Receiver.PlayAnimation("GetHit");
        }
        public override void Update()
        {

        }
        public override void FixedUpdate()
        {
            timer = new Timer(1f);
            timer.Tick(Time.fixedDeltaTime);
            if (timer.IsFinished)
            {
                CombatManager.Instance.ChangeState(new WaitForActionState());
            }
            if (m_Turn.m_Receiver.Information.CurrentHealth <= 0)
            {
                Debug.Log($"{m_Turn.m_Receiver.Information.Name} fainted!");
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
