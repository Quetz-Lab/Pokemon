using System.Collections.Generic;
using UnityEngine;

public class CombatManager : StateMachine
{
    #region Singleton
    public static CombatManager Instance => GetInstance();
    private static CombatManager m_instance;
    public Queue<Turn> turnQueue = new Queue<Turn>();
    public PokemonComponent playerPokemon;
    public PokemonComponent enemyPokemon;
    public PokemonMove m_PlayerMove;
    public NewCombatUI m_combatUI;

    private static CombatManager GetInstance()
    {
        if (m_instance == null)
        {
            m_instance = FindObjectOfType<CombatManager>();
            if (m_instance == null)
            {
                GameObject combatManagerObject = new GameObject("Combat Manager");
                m_instance = combatManagerObject.AddComponent<CombatManager>();
            }
        }
        return m_instance;
    }
    #endregion

    public static void StartCombat(PokemonDefinition p_Pokemon1, PokemonDefinition p_Pokemon2)
    {
        GameObject combatArena = GameManager.newCombatArena;
        Instance.playerPokemon = GameManager.SpawnPokemon(p_Pokemon1, Vector3.zero);
        Instance.enemyPokemon = GameManager.SpawnPokemon(p_Pokemon2, new Vector3(5, 0, 0));
       Instance.playerPokemon.transform.LookAt(Instance.enemyPokemon.transform, Vector3.up);
        Instance.enemyPokemon.transform.LookAt(Instance.playerPokemon.transform, Vector3.up);
        Instance.m_combatUI = GameManager.NewCombatUI;
        Instance.m_combatUI.Initialized(Instance.playerPokemon.Information);

        StartNewRound();

    }

    public static void StartNewRound()
    {
        Instance.turnQueue.Clear();
        Instance.m_PlayerMove = null; // Reset the player's move for the new round
        Instance.ChangeState(new WaitForActionState());
        Debug.Log("New round started. Waiting for player action. Pok");
    }
    public static void BuildTurnQueue()
    {
        PokemonComponent fastestestPokemon;
        PokemonComponent slowestPokemon;
        PokemonMove fastestMove, slowestMove;
        if (Instance.playerPokemon.Information.Speed > Instance.enemyPokemon.Information.Speed)
        {
            fastestestPokemon = Instance.playerPokemon;
            fastestMove = Instance.m_PlayerMove;
            slowestPokemon = Instance.enemyPokemon;
            slowestMove = Instance.enemyPokemon.UseRandomMove();
        }
        else
        {
            fastestestPokemon = Instance.enemyPokemon;
            fastestMove = Instance.enemyPokemon.UseRandomMove();
            slowestPokemon = Instance.playerPokemon;
            slowestMove = Instance.m_PlayerMove;

        }
        Instance.turnQueue.Enqueue(new Turn(fastestestPokemon, slowestPokemon, fastestMove));
        Instance.turnQueue.Enqueue(new Turn(slowestPokemon, fastestestPokemon, slowestMove));
        Instance.m_combatUI.UpdateHealth(Instance.playerPokemon.Information, Instance.enemyPokemon.Information);
        
    }
    public static void PlayNextTurn()
    {
        if (Instance.turnQueue.Count == 0)
        {
            StartNewRound();
        }
        else
        {
            Turn t_nextTurn = Instance.turnQueue.Dequeue();
            t_nextTurn.StartTurn();
        }

        if (Instance.playerPokemon.Information.CurrentHealth <= 0)
        {
            Debug.Log("Player's Pokemon has fainted!");
            Instance.m_combatUI.ShowLoseScreen();
            GameManager.EndCombat();
        }
        else if (Instance.enemyPokemon.Information.CurrentHealth <= 0)
        {
            Instance.m_combatUI.ShowWinScreen();
            
            GameManager.EndCombat();
            Debug.Log("Enemy's Pokemon has fainted!");
        }
    }
    public static int CalculateDamage(PokemonMove move, PokemonInformation attacker, PokemonInformation receiver)
    {
        if (move.IsSpecial)
        {
            return 5 + move.Power * (attacker.SpecialAttack / receiver.SpecialDefense);
        }
        else
        {
            return 5 + move.Power * (attacker.Attack / receiver.Defense);
        }
    }
    public static void SetPlayerMove(PokemonMove p_Move)
    {
        Instance.m_PlayerMove = p_Move;
        Debug.Log("Player selected move:" + p_Move.MoveName);
        BuildTurnQueue();
        PlayNextTurn();
    }
  
}
