using System.Collections;
using AYellowpaper.SerializedCollections;
using UnityEngine;
class Player{

    public int maxOozeLevel;
    int oozeLimit = 50;
    int score = 0;
    int currency =0;
    int maxTeamCap = 12;
    public ArrayList team = new ArrayList();
    public SerializedDictionary<Item, int> inventory = new SerializedDictionary<Item, int>();
    
    public Player(){ //initial party of 4 water slimes
        maxOozeLevel = 5;
        team.Add(new Slime(1));
        team.Add(new Slime(1));
        team.Add(new Slime(1));
        team.Add(new Slime(1));
        team.Capacity=6;
    }

    public bool increaseOoze(int amount){
        if(maxOozeLevel + amount <=oozeLimit){
            maxOozeLevel += amount;
            return true;
        }
        maxOozeLevel = oozeLimit;
        return false;
    }

    public bool increaseTeamCap(int capIncrease){
        int currentCap = team.Capacity;
        if(team.Capacity+capIncrease<=maxTeamCap){
            team.Capacity= currentCap + capIncrease;
            return true;
        } 
        team.Capacity = maxTeamCap;
        return false;
    }

    public bool addSlime(Slime newPartyMember){
        if(team.Count<team.Capacity){
            team.Add(newPartyMember);
            return true;
        } else
        return false; //failed (party size capped)
    }

    public bool removeSlime(Slime removedPartyMember){
        foreach(Slime s in team){
            if(s.Equals(removedPartyMember)){
                team.Remove(s);
                return true;
            }
        }
        return false; //not found
    }


    public bool consumeItem(int iD){

        foreach(var i in inventory ){
            Item checkedItem = (Item)i.Key;
            int quantity = i.Value;

            if(checkedItem.itemID==iD){
                inventory.Remove(checkedItem);
                if(quantity-1>0){
                inventory.Add(new Item(iD),quantity-1);
                } 
                return true;
            } 
        }
        return false; //item not found

    }

}