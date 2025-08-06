using UnityEngine;

public class Player : StateMachine
{
    public Rigidbody rb;
    public Animator animator;
    public LayerMask groundLayer;
    private InputSystem_Actions m_InputActions;
    public bool isGrounded()
    {
        
        return Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);
    }
    public Vector3 MoveDirection()
    {
        Vector3 vector = new Vector3(m_InputActions.Player.Move.ReadValue<Vector2>().x, 0, m_InputActions.Player.Move.ReadValue<Vector2>().y);
        return vector.normalized;
    }
    void Start()
    {
        m_InputActions = new InputSystem_Actions();
        m_InputActions.Enable();

       rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        m_CurrentState = new PlayerIdle(this);
    }
}

public class PlayerIdle : State
{
    Player m_Player;

    public PlayerIdle(Player player)
    {
        m_Player = player;
    }
    public override void Enter()
    {
        Debug.Log("Player is now idle. ");
        // m_Player.animator?.CrossFadeInFixedTime("Idle", 0.2f);
        m_Player.rb.linearVelocity = Vector3.zero;
        m_Player.rb.useGravity = true;
    }
    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        if (m_Player.MoveDirection().magnitude > 0f)
        {
            m_Player.ChangeState(new PlayerMove(m_Player));
        }
    }
    public override void Exit() 
    {
        Debug.Log("Player is leaving idle state");
    }
}

public class PlayerMove : State
{
    Player m_Player;
    public PlayerMove(Player player)
    {
        m_Player = player;
    }

    public override void Enter() { Debug.Log("Player is now moving");

        //m_Player.animator?.CrossFadeInFixedTime("Move", 0.2f);
    }
    public override void Update() { }
    public override void FixedUpdate()
    {
        if (m_Player.MoveDirection().magnitude < 0.1f) { m_Player.ChangeState(new PlayerIdle(m_Player)); }

        m_Player.rb.linearVelocity = m_Player.MoveDirection() * 5f;
    }
    public override void Exit()
    {
        Debug.Log("Player is now leaving move state");
    }
}

public class PlayerFalling : State
{
    Player m_Player;

    public PlayerFalling(Player player)
    {
        m_Player = player;
    }

    public override void Enter()
    {

    }
    public override void Update()
    {

    }
    public override void FixedUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }

}

public class  Ambushed : State
{
    public override void Enter()
    {
        Debug.Log("Player is now ambushed");
    }
    public override void Update()
    {

    }
    public override void FixedUpdate()
    {

    }
    public override void Exit()
    {
        Debug.Log("Player is now leaving ambushed state");
    }
}


