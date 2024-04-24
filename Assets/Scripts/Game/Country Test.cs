// using UnityEngine;

// public class CountryTest : MonoBehaviour
// {
//     void Start()
//     {
//         TestCountryInitialization();
//         TestSetOwner();
//     }

//     void TestCountryInitialization()
//     {
//         Debug.Log("Starting Country Initialization Test...");

//         Country country = new GameObject().AddComponent<Country>();

//         // Test default values after initialization
//         Debug.Log(country.isEnable == true
//             ? "isEnable is correct."
//             : "isEnable is incorrect!");

//         Debug.Log(country.color == Color.white
//             ? "Color is correct."
//             : "Color is incorrect!");

//         Debug.Log(country.getTroops() == 0
//             ? "Troops is correct."
//             : "Troops is incorrect!");

//         Debug.Log("Country Initialization Test complete.");
//     }

//     void TestSetOwner()
//     {
//         Debug.Log("Starting SetOwner Test...");

//         Country country = new GameObject().AddComponent<Country>();
//         Player player = new Player();

//         country.setOwner(player);

//         // Test if owner is set correctly
//         Debug.Log(country.getOwner() == player
//             ? "Owner is set correctly."
//             : "Owner is not set correctly!");

//         // Test if color is set correctly
//         Debug.Log(country.color == player.color
//             ? "Color is set correctly."
//             : "Color is not set correctly!");

//         Debug.Log("SetOwner Test complete.");
//     }
// }
