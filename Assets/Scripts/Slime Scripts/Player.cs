using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
public class Player{

    public int maxOozeLevel;
    public int oozeLimit = 50;
    public int score = 0;
    public int currency =0;
    public int maxTeamCap = 12;
    public List<Slime> team = new List<Slime>();
    SerializedDictionary<Item, int> inventory = new SerializedDictionary<Item, int>();
    
    public Player(){ //initial party of 4 water slimes
        maxOozeLevel = 5;
        
        team.Add(new Slime(1));
        team.Add(new Slime(1));
        team.Add(new Slime(2));
        team.Add(new Slime(2));
        team.Capacity=6;
        reciveItem(3); //Stone Shard
    }

    public bool increaseMaxOoze(int amount){
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
            Debug.Log("" + newPartyMember.speciesName + " Slime Joined Your Party");
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

    public void receiveCurrency(int amountRecived){
        currency+=amountRecived;
    }

    public void payCurrency(int amountPayed){
        currency-=amountPayed;
    }

    public int getInventorySize(){
        return inventory.Count;
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
    public void resetTeam(){
        foreach(Slime s in team){
            s.resetSlime();
        }
    }
    public void reciveItem(int iD){
         Debug.Log("You Recived 1 " + new Item(iD).itemName);
        foreach(var i in inventory ){
            Item checkedItem = (Item)i.Key;
            int quantity = i.Value;

            if(checkedItem.itemID==iD){
                inventory.Remove(checkedItem);
                
                inventory.Add(new Item(iD),quantity+1);
                return;
            } 
        }
         inventory.Add(new Item(iD),1);
    }

}