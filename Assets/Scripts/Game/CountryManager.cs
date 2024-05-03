using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryManager{


    public static bool checkCountryOwner(Player player, Country country){
        if (country.getOwner() == player){
            return true;
        }

        return false;
    }

    // public static bool checkCountryOthers(Player player, Country country){
    //     if (country.getOwner() != player){
    //         return true;
    //     }

    //     return false;
    // }

    public static bool isNearBy(Country country1, Country country2){
        List<string> value = Neighbors[country1.name];
        // Debug.Log(country1.name + " " +value.Contains(country2.name) + " " + country2.name);
        return value.Contains(country2.name);
    }

    public static bool isPathway(Player player,Country country1, Country country2){

        Debug.Log("Path Finder:" + country1.name + " to " + country2.name);
        

        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(country1.name);
        visited.Add(country1.name);

        while (queue.Count > 0){
            string currentCountry = queue.Dequeue();
            List<string> neighbors = Neighbors[currentCountry];
            HashSet<string> neighborCountrys = new HashSet<string>();

            foreach(string neighborName in neighbors){
                neighborCountrys.Add(neighborName);
            }

            foreach (string neighbor in neighborCountrys){

                Debug.Log("Finging:" + neighbor);
                if (!visited.Contains(neighbor) && checkCountryOwner(player, GameObject.Find(neighbor).GetComponent<Country>())){
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);

                    if (neighbor == country2.name){
                        return true;
                    }
                }
            }
        }

        return false;
    }

        public static Dictionary<string, List<string>> Neighbors = new Dictionary<string, List<string>>(){
        //Asian
        { "Kamchatka", new List<string>{"Yakutsk", "Irkutsk", "Mongolia", "Japan", "Alaska"}},
        { "Yakutsk", new List<string>{"Kamchatka", "Irkutsk", "Siberia"}},
        { "Irkutsk", new List<string>{"Kamchatka", "Yakutsk", "Siberia", "Mongolia"}},
        { "Siberia", new List<string>{"Yakutsk", "Irkutsk", "Ural", "Mongolia", "China"}},
        { "Ural", new List<string>{"Siberia", "Russia", "Afghanistan", "China"}},
        { "Mongolia", new List<string>{"Irkutsk", "Siberia", "Kamchatka", "China", "Japan"}},
        { "Japan", new List<string>{"Mongolia", "Kamchatka"}},
        { "China", new List<string>{"Mongolia", "Afghanistan", "Southeast Asia", "India", "Siberia","Ural"}},
        { "Afghanistan", new List<string>{"Russia", "Ural", "China", "India", "Middle East"}},
        { "Middle East", new List<string>{"Russia", "Southern Europe", "Egypt", "Afghanistan", "India"}},
        { "India", new List<string>{"Southeast Asia", "Afghanistan", "Middle East", "China"}},
        { "Southeast Asia", new List<string>{"Indonesia", "China", "India"}},

        //Australia
        { "Indonesia", new List<string>{"Southeast Asia", "Western Australia"}},
        { "New Guinea", new List<string>{"Indonesia", "Eastern Australia"}},
        { "Western Australia", new List<string>{"Indonesia", "Eastern Australia"}},
        { "Eastern Australia", new List<string>{"New Guinea", "Western Australia"}},

        //Africa
        { "North Africa", new List<string>{"Egypt", "Western Europe", "East Africa", "Central Africa", "Brazil"}},
        { "Egypt", new List<string>{"Middle East", "Southern Europe", "North Africa", "East Africa"}},
        { "East Africa", new List<string>{"Egypt", "North Africa", "Central Africa", "South Africa", "Madagascar"}},
        { "Central Africa", new List<string>{"North Africa", "East Africa", "South Africa"}},
        { "South Africa", new List<string>{"Central Africa", "East Africa", "Madagascar"}},
        { "Madagascar", new List<string>{"South Africa", "East Africa"}},

        //Europe
        { "Russia", new List<string>{"Ural", "Afghanistan", "Middle East", "Scandinavia", "Northern Europe", "Southern Europe"}},
        { "Scandinavia", new List<string>{"Russia", "Iceland", "Great Britain", "Northern Europe"}},
        { "Iceland", new List<string>{"Greenland", "Scandinavia", "Great Britain"}},
        { "Great Britain", new List<string>{"Iceland", "Scandinavia", "Northern Europe", "Western Europe"}},
        { "Northern Europe", new List<string>{"Scandinavia", "Great Britain", "Southern Europe", "Western Europe", "Russia"}},
        { "Southern Europe", new List<string>{"Russia", "Northern Europe", "Western Europe", "Middle East", "Egypt", "North Africa"}},
        { "Western Europe", new List<string>{"Northern Europe", "Southern Europe", "Great Britain", "North Africa"}},

        //NorthAmerica
        { "Greenland", new List<string>{"Northwest Territory", "Ontario", "Eastern Canada", "Iceland"}},
        { "Northwest Territory", new List<string>{"Alaska", "Alberta", "Ontario", "Greenland"}},
        { "Alaska", new List<string>{"Northwest Territory", "Alberta", "Kamchatka"}},
        { "Alberta", new List<string>{"Alaska", "Northwest Territory", "Ontario", "Western United States"}},
        { "Ontario", new List<string>{"Alberta", "Western United States", "Eastern United States", "Eastern Canada", "Greenland", "Northwest Territory"}},
        { "Eastern Canada", new List<string>{"Ontario", "Eastern United States", "Greenland"}},
        { "Western United States", new List<string>{"Alberta", "Ontario", "Eastern United States", "Central America"}},
        { "Eastern United States", new List<string>{"Central America", "Ontario", "Eastern Canada", "Western United States"}},
        { "Central America", new List<string>{"Western United States", "Eastern United States", "Venezuela"}},

        //SouthAmerica
        { "Venezuela", new List<string>{"Central America", "Brazil", "Peru"}},
        { "Brazil", new List<string>{"Venezuela", "Peru", "Argentina"}},
        { "Peru", new List<string>{"Venezuela", "Brazil", "Argentina"}},
        { "Argentina", new List<string>{"Peru", "Brazil"}}
    };

}
