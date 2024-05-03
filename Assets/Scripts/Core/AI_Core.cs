using System;
using System.Collections.Generic;
using UnityEngine;

public class AI_Core : MonoBehaviour
{
    private Player[] players;
    private Country[] countries;

    /// <summary>
    /// The difficulty level of the AI.
    /// Determines how smart and aggressive the AI behaves.
    /// </summary>
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    /// <summary>
    /// The current difficulty level of the AI.
    /// </summary>
    public DifficultyLevel difficultyLevel;

    /// <summary>
    /// The list of countries owned by the AI player.
    /// </summary>
    private List<Country> ownedCountries;

    /// <summary>
    /// The list of neighboring countries of enemy players.
    /// </summary>
    private List<Country> enemyNeighbors;

    /// <summary>
    /// The list of continents where the AI player has presence.
    /// </summary>
    private List<int> ownedContinents;

    /// <summary>
    /// The target country for the current turn's action.
    /// </summary>
    private Country targetCountry;

    /// <summary>
    /// Initializes the AI player with default settings.
    /// </summary>
    private void Initialize()
    {
        difficultyLevel = DifficultyLevel.Medium;
        ownedCountries = new List<Country>();
        enemyNeighbors = new List<Country>();
        ownedContinents = new List<int>();
    }

    /// <summary>
    /// Updates the AI's decision-making process.
    /// </summary>
    private void Update()
    {
        MakeDecision();
    }

    /// <summary>
    /// Makes a strategic decision based on the current game state.
    /// </summary>
    private void MakeDecision()
    {
        switch (difficultyLevel)
        {
            case DifficultyLevel.Easy:
                PlayRandom();
                break;
            case DifficultyLevel.Medium:
                PlaySmart();
                break;
            case DifficultyLevel.Hard:
                PlayAggressive();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Plays randomly without much strategic thinking.
    /// </summary>
    private void PlayRandom()
    {
        // Implement random decision-making logic here
        // For example, randomly select a country to attack or reinforce
        int randomIndex = UnityEngine.Random.Range(0, ownedCountries.Count);
        targetCountry = ownedCountries[randomIndex];
        // Simulate an attack or reinforcement
        AttackOrReinforce();
    }

    /// <summary>
    /// Plays smartly by considering strategic advantages.
    /// </summary>
    private void PlaySmart()
    {
        // Implement smart decision-making logic here
        // For example, prioritize reinforcing countries with weaker defenses
        Country weakestCountry = GetWeakestCountry();
        if (weakestCountry != null)
        {
            targetCountry = weakestCountry;
            // Reinforce the weakest country
            Reinforce();
        }
    }

    /// <summary>
    /// Plays aggressively by prioritizing attacks and expansions.
    /// </summary>
    private void PlayAggressive()
    {
        FindTargetCountry();
        AttackTargetCountry();
    }

    /// <summary>
    /// Finds a suitable target country for an attack.
    /// </summary>
    private void FindTargetCountry()
    {
        foreach (Country enemyCountry in enemyNeighbors)
        {
            if (IsAttackFeasible(enemyCountry))
            {
                targetCountry = enemyCountry;
                return;
            }
        }
    }

    /// <summary>
    /// Determines if attacking the specified country is feasible.
    /// </summary>
    /// <param name="country">The target country to attack.</param>
    /// <returns>True if attacking the country is feasible; otherwise, false.</returns>
    private bool IsAttackFeasible(Country country)
    {
        return country.getTroops() < GetOwnStrongestCountry().getTroops();
    }

    /// <summary>
    /// Attacks the target country.
    /// </summary>
    private void AttackTargetCountry()
    {
        Country strongestCountry = GetOwnStrongestCountry();
        if (strongestCountry != null)
        {
            // Move troops from the strongest country to attack the target
            strongestCountry.zbbTroops(targetCountry.getTroops() + 1);
            targetCountry.setOwner(strongestCountry.getOwner());
        }
    }

    /// <summary>
    /// Retrieves the weakest country owned by the AI player.
    /// </summary>
    /// <returns>The weakest country owned by the AI player.</returns>
    private Country GetWeakestCountry()
    {
        Country weakestCountry = null;
        foreach (Country country in ownedCountries)
        {
            if (weakestCountry == null || country.getTroops() < weakestCountry.getTroops())
            {
                weakestCountry = country;
            }
        }
        return weakestCountry;
    }

    /// <summary>
    /// Retrieves the strongest country owned by the AI player.
    /// </summary>
    /// <returns>The strongest country owned by the AI player.</returns>
    private Country GetOwnStrongestCountry()
    {
        Country strongestCountry = null;
        foreach (Country country in ownedCountries)
        {
            if (strongestCountry == null || country.getTroops() > strongestCountry.getTroops())
            {
                strongestCountry = country;
            }
        }
        return strongestCountry;
    }

    /// <summary>
    /// Attacks or reinforces the target country.
    /// </summary>
    private void AttackOrReinforce()
    {
        if (targetCountry != null)
        {
            if (targetCountry.isOwned())
            {
                Reinforce();
            }
            else
            {
                AttackTargetCountry();
            }
        }
    }

    /// <summary>
    /// Reinforces the target country.
    /// </summary>
    private void Reinforce()
    {
        targetCountry.addTroops(5);
    }

    /// <summary>
    /// Retrieves the list of countries owned by the AI player.
    /// </summary>
    /// <returns>The list of owned countries.</returns>
    public List<Country> GetOwnedCountries()
    {
        return ownedCountries;
    }

    /// <summary>
    /// Retrieves the list of neighboring countries of enemy players.
    /// </summary>
    /// <returns>The list of enemy neighboring countries.</returns>
    public List<Country> GetEnemyNeighbors()
    {
        return enemyNeighbors;
    }

    /// <summary>
    /// Adds a country to the list of owned countries.
    /// </summary>
    /// <param name="country">The country to add.</param>
    public void AddOwnedCountry(Country country)
    {
        ownedCountries.Add(country);
    }

    /// <summary>
    /// Removes a country from the list of owned countries.
    /// </summary>
    /// <param name="country">The country to remove.</param>
    public void RemoveOwnedCountry(Country country)
    {
        ownedCountries.Remove(country);
    }

    /// <summary>
    /// Adds a continent to the list of owned continents.
    /// </summary>
    /// <param name="continent">The continent to add.</param>
    public void AddOwnedContinent(int continent)
    {
        ownedContinents.Add(continent);
    }

    /// <summary>
    /// Removes a continent from the list of owned continents.
    /// </summary>
    /// <param name="continent">The continent to remove.</param>
    public void RemoveOwnedContinent(int continent)
    {
        ownedContinents.Remove(continent);
    }

}