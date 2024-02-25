# "World Conquest" Low-Level Design Document

## 1. Introduction

- **Game Name**: World Conquest
- **Overview**: A strategy board game where players compete to dominate the world by occupying territories and establishing diplomatic policies.
- **Genre**: Board Game
- **Target Audience**: Desktop users, especially PC users.
- **Purpose**: To provide a detailed low-level design for the "World Conquest" game, guiding the development team in accurately implementing game components and functionalities.
- **Scope**: Covers map generation, player setup, game mechanics, data modeling, interface design, algorithm development, testing plan, and runtime environment.

## 2. Component and Class Design

1. **StartGame**
   - Methods:
     - `startNewGame()`: Starts a new game session without parameters.
     - `continueGame(gameData)`: Continues a previous game using saved `gameData`.
2. **Setting**
   - Methods:
     - `opensetting()`: Opens the game's settings menu.
3. **AdjustResolution**
   - Methods:
     - `setResolution(width, height)`: Sets the game's resolution.
4. **AdjustVolume**
   - Methods:
     - `setVolume(volumeLevel)`: Sets the overall volume level of the game.
     - `adjustMusicVolume(volumeLevel)`: Adjusts the game's music volume independently.
5. **ExitGame**
   - Methods:
     - `exitGame()`: Safely exits the game.
6. **MapGenerator**
   - Methods:
     - `GenerateMap()`: Creates a new game map with continents and countries.
     - `LoadContinents(continentsData)`: Loads preset continent information into the map.
     - `LoadCountries(countriesData)`: Loads countries based on continent information.
7. **PlayerSetup**
   - Methods:
     - `DetermineOrder(players)`: Randomly determines the order of players.
     - `SelectColor(player, color)`: Allows players to select their color.
     - `DistributeArmies(players)`: Distributes initial armies to players according to game rules.
8. **ConscriptionService**
   - Methods:
     - `CalculateReinforcements(player)`: Calculates new army units for players based on controlled territories.
     - `DeployReinforcements(player, territory, quantity)`: Distributes new army units to player-controlled territories.
9. **AttackService**
   - Methods:
     - `InitiateAttack(attacker, defender, territory)`: Manages attacks between players.
     - `CalculateVictoryChance(attacker, defender)`: Calculates the chance of victory in an attack.
     - `OccupyTerritory(winner, territory)`: Manages territory occupation after an attack.
10. **CardRewardSystem**
    - Methods:
      - `IssueCard(player)`: Assigns cards to players who conquer territories.
      - `ValidateCardSet(cards)`: Validates the set of cards a player has.
      - `RedeemCardSet(player, cards)`: Allows players to exchange sets of cards for bonuses.
11. **ExpansionService**
    - Methods:
      - `ExpandTerritory(player, territory)`: Manages the acquisition and deployment of territories after battles.
      - `FortifyTerritory(player, territory, armies)`: Strengthens a player's hold on a territory.
12. **VictoryScreen**
    - Methods:
      - `showVictoryMessage(winner)`: Displays victory message to the winner.
13. **StatisticsDisplay**
    - Methods:
      - `displayStats(gameStats)`: Shows game statistics.
14. **RewardManager**
    - Methods:
      - `calculateRewards(winner)`: Calculates and displays rewards for the winner.
15. **MainMenuRedirect**
    - Methods:
      - `redirectToMainMenu()`: Provides an option to return to the main menu.
16. **Color**
    - Attributes:
      - `red`: Integer value for the red component (0-255).
      - `green`: Integer value for the green component (0-255).
      - `blue`: Integer value for the blue component (0-255).
    - Methods:
      - `setColor(red, green, blue)`: Sets the RGB values of the color.
      - `getColor()`: Returns the RGB values as a tuple.
      - `blend(otherColor)`: Blends this color with another color.

## 3. Interface Design

### IGameControl

- Links with: `StartGame`, `Setting`, `ExitGame`
- Methods:
  - `startNewGame()`
  - `openSettings()`
  - `exitGame()`

### IGameSettings

- Links with: `AdjustResolution` and `AdjustVolume`
- Methods:
  - `setResolution(width, height)`
  - `setVolume(volumeLevel)`

##### IGameplayMechanics

- Links with: `MapGenerator`, `PlayerSetup`, `ConscriptionService`, `AttackService`, `CardRewardSystem`, `ExpansionService`
- Methods:
  - `GenerateMap()`
  - `DetermineOrder(players)`
  - `CalculateReinforcements(player)`
  - `InitiateAttack(attacker, defender, territory)`
  - `IssueCard(player)`
  - `ExpandTerritory(player, territory)`

##### IGameEnd

- Links with: `VictoryScreen`, `StatisticsDisplay`, `RewardManager`
- Methods:
  - `showVictoryMessage(winner)`
  - `displayStats(gameStats)`
  - `calculateRewards(winner)`

##### INavigation

- Links with: `MainMenuRedirect`
- Methods:
  - `redirectToMainMenu()`

##### IMapSelector

- Methods:

  - ```
    SelectMap(mapId)
    ```

    : Selects a map by its unique ID.

    - Parameter: `mapId` (string) - The unique identifier for the map.
    - Returns: bool - Indicates whether the operation was successful.

  - ```
    ListMaps()
    ```

    : Lists all available maps.

    - Parameters: None.
    - Returns: List<string> - A list of IDs for available maps.

  - ```
    GetMapDetails(mapId)
    ```

    : Gets detailed information about a specific map.

    - Parameter: `mapId` (string) - The unique identifier for the map.
    - Returns: MapDetails - An object containing detailed information about the map.

  - ```
    LoadMap(mapId)
    ```

    : Loads and prepares a map by its unique ID.

    - Parameter: `mapId` (string) - The unique identifier for the map.
    - Returns: bool - Indicates whether the map was successfully loaded.