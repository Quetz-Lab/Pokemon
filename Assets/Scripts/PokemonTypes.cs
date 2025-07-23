using UnityEngine;

public class PokemonTypes
{
    public enum TypeList
    {
        Fire,
        Water,
        Air,
        Stone,
        Fairy,
        none
    }

    public float[,] typeStrengths = new float[,]
{
    {1f, 0.5f, 1f, 2f, 1f},
    {2f, 1f, 0.5f, 1f, 1f},
    {1f, 2f, 1f, 0.5f, 1f},
    {0.5f, 1f, 2f, 1f, 1f},
    {1f, 1f, 1f, 1f, 1f}
};
}
