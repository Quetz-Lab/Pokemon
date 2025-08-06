using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PokemonInformation
{

    public PokemonInformation(PokemonDefinition definition)
    {
        m_Definition = definition;
        m_MaxHealth = definition.Health;
        m_CurrentHealth = m_MaxHealth;
        m_Moves = new List<PokemonMove>(4);
        foreach (PokemonMove move in definition.Moves)
        {
            if (move == null) {  continue; }
            m_Moves.Add(move);
        }
    }
    public string Name => m_Definition.name;
    public int MaxHealth => m_Definition.Health +2 * m_Level;
    public int Attack => m_Definition.Attack + m_Level;
    public int SpecialAttack => m_Definition.SpecialAttack + m_Level;
    public int Defense => m_Definition.Defense + m_Level;
    public int SpecialDefense => m_Definition.SepcialDefense + m_Level;
    public int Speed => m_Definition.Speed + m_Level;

    public PokemonTypes.TypeList mainType => m_Definition.MainType;
    public PokemonTypes.TypeList secondaryType => m_Definition.SecondaryType;
    public PokemonMove[] Moves => m_Moves.ToArray();

    private PokemonDefinition m_Definition;


    private string m_Name;
    private int m_Level;
    private int m_Xp;
    private int m_MaxHealth;
    private int m_CurrentHealth;
    private List<PokemonMove> m_Moves;

    public void GetDamaged(int damage)
    {
        m_CurrentHealth -= damage;
        if (m_CurrentHealth > MaxHealth)
        {
            m_CurrentHealth = MaxHealth;
        }
    }
    public void Health(int amount)
    {
        m_CurrentHealth += amount;
        if (m_CurrentHealth > MaxHealth)
        {
            m_CurrentHealth = MaxHealth;
        }
    }
    public void Gain(int amount)
    {
        m_Xp += amount;
        if (m_Xp >= GetXpForNextLevel())
        {
            m_Xp -= GetXpForNextLevel();
            LevelUp();
        }
    }

    private int GetXpForNextLevel()
    {
        return(int)(Mathf.Pow(m_Level + 1, 1.25F) * 10);
    }
   private void LevelUp()
    {
        m_Level++;
    }
    public void Rename(string newName)
    {
        if (string.IsNullOrEmpty(newName))
        { 
            Debug.LogError("Pokemon model is not set in the definition");
            return;
        }
        m_Name = newName;
    }
    public void LearnMove(PokemonMove newMove)
    {
        if (m_Moves.Count >= 4)
        {
            Debug.LogWarning("Cannot learn more than 4 moves. Please forget an existing move first.");
            return;
        }
        m_Moves.Add(newMove);
    }

    public void ForgetMove(PokemonMove moveToForget)
    {
        if (m_Moves.Contains(moveToForget))
        {
            m_Moves.Remove(moveToForget);
        }
        else
        {
            Debug.LogWarning("Move not found in the current moveset");
        }
    }

    public GameObject SpawnModel(Transform p_Parent)
    {
        if (m_Definition.Model == null)
        {
            Debug.LogError("Pokemon model is not set in the definition");
            return null;
        }
        GameObject t_Model = UnityEngine.Object.Instantiate(m_Definition.Model, p_Parent);
        t_Model.transform.localPosition = Vector3.zero;
        t_Model.transform.localRotation = Quaternion.identity;
        t_Model.transform.localScale = Vector3.one;
        t_Model.name = "Model1";
        return t_Model;
    }

}
