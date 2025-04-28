using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class Slime {
    public int speciesID;
    public string speciesName="Slime";

    public string speciesDescription = "This is a Slime";

    public int hitPointModifier=1;
    public int maxHP=10;
    public int currentHP;
    public int attackModifier=1;
    public int baseAttack=1;
    public int currentAttack;
    public int baseSpeed=1;
    public int currentSpeed;
    public int damageTaken=0;
    public int oozeLevel=1;
    public double accuracy=1;
    public Move[] moves;
    public int ability = 0;
    public Slime(int iD=0, int oLvl=1, int dmgTaken=0){

        speciesID = iD;
        damageTaken = dmgTaken;

        switch(iD){

            case 1:
                {
                    speciesName = "Water";
                    hitPointModifier = 5;
                    attackModifier = 2;
                    baseSpeed = 3;
                    moves = new Move[] {new Move(1,this),new Move(2,this),new Move(3,this)};
                }

                break;

            case 2:
                {
                    speciesName = "Magma";
                    hitPointModifier = 4;
                    attackModifier = 3;
                    baseSpeed = 4;
                    moves = new Move[] {new Move(4,this),new Move(5,this),new Move(3,this)};
                }

                break;
            case 3:
                {
                    speciesName = "Rock";
                    hitPointModifier = 6;
                    attackModifier = 3;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(6,this),new Move(7,this),new Move(8,this)};
                }

                break;
            case 4:
                {
                    speciesName = "Grass";
                    hitPointModifier = 9;
                    attackModifier = 1;
                    baseSpeed = 5;
                    moves = new Move[] {new Move(9,this),new Move(10,this),new Move(11,this)};
                }

                break;
            case 5:
                {
                    speciesName = "Ice";
                    hitPointModifier = 4;
                    attackModifier = 5;
                    baseSpeed = 4;
                    moves = new Move[] {new Move(12,this),new Move(13,this),new Move(14,this)};
                }

                break;
            case 6:
                {
                    speciesName = "Cloudy";
                    hitPointModifier = 4;
                    attackModifier = 2;
                    baseSpeed = 8;
                    moves = new Move[] {new Move(1,this),new Move(14,this),new Move(15,this)};
                }

                break;
            case 7:
                {
                    speciesName = "Electric";
                    hitPointModifier = 4;
                    attackModifier = 6;
                    baseSpeed = 7;
                    accuracy = 0.55F;
                    moves = new Move[] {new Move(15,this),new Move(16,this),new Move(17,this)};
                }

                break;
            case 8:
                {
                    speciesName = "Muddy";
                    hitPointModifier = 8;
                    attackModifier = 1;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(19,this),new Move(20,this),new Move(3,this)};
                }

                break;
            case 9:
                {
                    speciesName = "Snow";
                    hitPointModifier = 6;
                    attackModifier = 4;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(18,this),new Move(21,this),new Move(22,this)};
                }

                break;
            case 10:
                {
                    speciesName = "Ash";
                    hitPointModifier = 2;
                    attackModifier = 1;
                    baseSpeed = 5;
                    moves = new Move[] {new Move(23,this),new Move(24,this),new Move(17,this)};
                }

                break;
            default:
                    speciesName = "Water";
                    hitPointModifier = 5;
                    attackModifier = 2;
                    baseSpeed = 3;
                    moves = new Move[] {new Move(1,this),new Move(2,this),new Move(3,this)};
                    break;
        }

        maxHP = hitPointModifier * oozeLevel;
        currentHP = maxHP - damageTaken;
        //Ensure that a conversion process does not instantly kill a slime if it had taken damage that exceeds its new maxHP
        if (currentHP == 0){
            currentHP = 1;
        }

        baseAttack = attackModifier * oozeLevel;
        currentAttack = baseAttack;

        currentSpeed = baseSpeed;
       
    }

    public void resetSlime(){ //reset slime stat changes and full heals
        oozeLevel = 1;
        maxHP = hitPointModifier * oozeLevel;
        baseAttack = attackModifier * oozeLevel;

        currentSpeed = baseSpeed;
        currentAttack = baseAttack;
        currentHP = maxHP;

        damageTaken = 0;
        
        if(speciesID!=7)
            accuracy = 1F;
        else
            accuracy = 0.55F;
    }

    public void increaseOoze(int addedOoze){

        oozeLevel+=addedOoze;

        maxHP = hitPointModifier * oozeLevel;
        baseAttack = attackModifier * oozeLevel;
        currentAttack = baseAttack;

    }
    
    
    public bool convertSlime(int newID){ //this is such an ineffecient and probably incorrect way to do this :(

        Slime s = new Slime(newID);
        this.speciesID = s.speciesID;
        this.speciesName = s.speciesName;
        this.speciesDescription = s.speciesDescription;
        this.hitPointModifier = s.hitPointModifier;
        this.attackModifier = s.attackModifier;
        this.baseSpeed = s.baseSpeed;
        this.accuracy = s.accuracy;
        //copy moves too

        maxHP = hitPointModifier * oozeLevel;
        currentHP = maxHP - damageTaken;

        //Ensure that a conversion process does not instantly kill a slime if it had taken damage that exceeds its new maxHP
        if (currentHP <= 0){
            currentHP = 1;
        }

        baseAttack = attackModifier * oozeLevel;
        currentAttack = baseAttack;
        currentSpeed = baseSpeed;

        return true;

    }
   

    public bool takeDamage(int dmg,string element = "None", bool checkIfHPLow = false){ //returns true if slime had been defeated

        currentHP -= dmg;
        if (currentHP<=0){
            currentHP=0;
            Debug.Log(this.speciesName + " Slime took fatal damage");
            return true;
        }

        Debug.Log(this.speciesName + " Slime took some damage");
        return false;
        
    }
    public void healDamage(int healAmount){

        currentHP += healAmount;
        if (currentHP>maxHP){
            currentHP=maxHP;
        }
        Debug.Log(this.speciesName + " Slime Recived healing");
        
    }

    public void changeStat(double statChangeModifier, string targetStat){
        switch (targetStat){
            case "Atk":
                currentAttack = (int) (currentAttack * statChangeModifier);
                break;
             case "Acc":
                accuracy = (int) (accuracy * statChangeModifier);
                break;
             case "Spd":
                currentSpeed = (int) (currentSpeed * statChangeModifier);
                break;
        }

        Debug.Log(this.speciesName + " Slime's stats changed");

    }

    

}