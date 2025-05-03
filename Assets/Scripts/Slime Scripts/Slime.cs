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
        oozeLevel = oLvl;

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
            case 11:
                {
                    speciesName = "Metal";
                    hitPointModifier = 8;
                    attackModifier = 4;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(25,this),new Move(26,this),new Move(27,this)};
                }
                break;
            case 12:
                {
                    speciesName = "Fungal";
                    hitPointModifier = 8;
                    attackModifier = 4;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(9,this),new Move(28,this),new Move(29,this)};
                }

                break;
            case 13:
                {
                    speciesName = "Sandy";
                    hitPointModifier = 5;
                    attackModifier = 5;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(30,this),new Move(31,this),new Move(32,this)};
                }

                break;
            case 14:
                {
                    speciesName = "Bubbly";
                    hitPointModifier = 2;
                    attackModifier = 5;
                    baseSpeed = 9;
                    moves = new Move[] {new Move(33,this),new Move(34,this),new Move(35,this)};
                }

                break;
            case 15:
                {
                    speciesName = "Poisonous";
                    hitPointModifier = 6;
                    attackModifier = 3;
                    baseSpeed = 4;
                    moves = new Move[] {new Move(36,this),new Move(37,this),new Move(38,this)};
                }
                break;
            case 16:
                {
                    speciesName = "Worn-Out";
                    hitPointModifier = 3;
                    attackModifier = 1;
                    baseSpeed = 4;
                    moves = new Move[] {new Move(39,this)};
                }

                break;

             case 17:
                {
                    speciesName = "Incense";
                    hitPointModifier = 5;
                    attackModifier = 1;
                    baseSpeed = 8;
                    moves = new Move[] {new Move(40,this),new Move(41,this),new Move(42,this)};
                }
                break;
            case 18:
                {
                    speciesName = "Smoky";
                    hitPointModifier = 1;
                    attackModifier = 5;
                    baseSpeed = 8;
                    moves = new Move[] {new Move(40,this),new Move(43,this),new Move(44,this)};
                }
                break;
            case 19:
                {
                    speciesName = "Bomb";
                    hitPointModifier = 2;
                    attackModifier = 7;
                    baseSpeed = 5;
                    moves = new Move[] {new Move(45,this),new Move(46,this),new Move(17,this)};
                }
                break;
            case 20:
                {
                    speciesName = "Oily";
                    hitPointModifier = 5;
                    attackModifier = 4;
                    baseSpeed = 3;
                    moves = new Move[] {new Move(44,this),new Move(47,this),new Move(48,this)};
                }
                break;
            case 21:
                {
                    speciesName = "Oaky";
                    hitPointModifier = 6;
                    attackModifier = 2;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(49,this),new Move(50,this),new Move(11,this)};
                }
                break;
            case 22:
                {
                    speciesName = "Honey";
                    hitPointModifier = 5;
                    attackModifier = 1;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(47,this),new Move(51,this),new Move(52,this)};
                }
                break;
            case 23:
                {
                    speciesName = "Jamy";
                    hitPointModifier = 3;
                    attackModifier = 3;
                    baseSpeed = 5;
                    moves = new Move[] {new Move(53,this),new Move(51,this),new Move(52,this)};
                }
                break;
            case 24:
                {
                    speciesName = "Ice Cream";
                    hitPointModifier = 6;
                    attackModifier = 6;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(54,this),new Move(51,this),new Move(52,this)};
                }
                break;
            case 25:
                {
                    speciesName = "Magic";
                    hitPointModifier = 6;
                    attackModifier = 3;
                    baseSpeed = 5;
                    moves = new Move[] {new Move(55,this),new Move(56,this),new Move(57,this)};
                }
                break;
            case 26:
                {
                    speciesName = "Bunny";
                    hitPointModifier = 4;
                    attackModifier = 3;
                    baseSpeed = 11;
                    moves = new Move[] {new Move(58,this),new Move(59,this),new Move(60,this)};
                }
                break;
            case 27:
                {
                    speciesName = "Coral";
                    hitPointModifier = 3;
                    attackModifier = 8;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(60,this),new Move(61,this),new Move(62,this)};
                }
                break;
            case 28:
                {
                    speciesName = "Golden";
                    hitPointModifier = 10;
                    attackModifier = 1;
                    baseSpeed = 7;
                    moves = new Move[] {new Move(64,this),new Move(65,this),new Move(68,this)};
                }
                break;
            case 29:
                {
                    speciesName = "Golden"; //pyrite slime
                    hitPointModifier = 12;
                    attackModifier = 1;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(64,this),new Move(65,this),new Move(68,this)};
                }
                break;
            case 30:
                {
                    speciesName = "Luminous";
                    hitPointModifier = 10;
                    attackModifier = 1;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(69,this)};
                }
                break;
            case 31:
                {
                    speciesName = "Garbage";
                    hitPointModifier = 4;
                    attackModifier = 1;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(70,this),new Move(70,this),new Move(70,this)};
                }
                break;
            case 32:
                {
                    speciesName = "Hungry";
                    hitPointModifier = 8;
                    attackModifier = 5;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(71,this),new Move(72,this)};
                }
                break;
            case 33:
                {
                    speciesName = "Mimic";
                    hitPointModifier = 6;
                    attackModifier = 1;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(73,this),new Move(75,this),new Move(91,this)};
                }
                break;
            case 34:
                {
                    speciesName = "Cosmic";
                    hitPointModifier = 6;
                    attackModifier = 1;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(74,this)};
                }
                break;
            case 35:
                {
                    speciesName = "Clown";
                    hitPointModifier = 5;
                    attackModifier = 5;
                    baseSpeed = 15;
                    moves = new Move[] {new Move(75,this),new Move(76,this),new Move(77,this),new Move(73,this),new Move(16,this),new Move(88,this)};
                }
                break;
            case 36:
                {
                    speciesName = "Stormy";
                    hitPointModifier = 5;
                    attackModifier = 5;
                    baseSpeed = 10;
                    moves = new Move[] {new Move(78,this),new Move(79,this),new Move(80,this)};
                }
                break;
            case 37:
                {
                    speciesName = "Octo";
                    hitPointModifier = 6;
                    attackModifier = 6;
                    baseSpeed = 8;
                    moves = new Move[] {new Move(80,this),new Move(81,this),new Move(82,this)};
                }
                break;
            case 38:
                {
                    speciesName = "Inky";
                    hitPointModifier = 1;
                    attackModifier = 1;
                    baseSpeed = 4;
                    moves = new Move[] {new Move(84,this)};
                }
                break;
            case 39:
                {
                    speciesName = "Bear";
                    hitPointModifier = 8;
                    attackModifier = 6;
                    baseSpeed = 8;
                    moves = new Move[] {new Move(85,this),new Move(86,this),new Move(58,this)};
                }
                break;
            case 40:
                {
                    speciesName = "Arcane";
                    hitPointModifier = 6;
                    attackModifier = 6;
                    baseSpeed = 6;
                    moves = new Move[] {new Move(87,this),new Move(56,this),new Move(57,this)};
                }
                break;
            case 41:
                {
                    speciesName = "Large";
                    hitPointModifier = 10;
                    attackModifier = 2;
                    baseSpeed = 2;
                    moves = new Move[] {new Move(88,this),new Move(89,this),new Move(90,this)};
                }
                break;
            case 42:
                {
                    speciesName = "Average";
                    hitPointModifier = 6;
                    attackModifier = 5;
                    baseSpeed = 4;
                    moves = new Move[] {new Move(88,this),new Move(89,this),new Move(90,this)};
                }
                break;
            case 43:
                {
                    speciesName = "Mini";
                    hitPointModifier = 3;
                    attackModifier = 8;
                    baseSpeed = 8;
                    moves = new Move[] {new Move(89,this)};
                }
                break;
            default:
                    speciesName = "???";
                    hitPointModifier = 1;
                    attackModifier = 1;
                    baseSpeed = 1;
                    moves = new Move[] {new Move(1,this),new Move(1,this),new Move(1,this)};
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

    public void increaseOoze(int addedOoze,BattleManager bm){


        if(addedOoze>0){
            bm.bo.displayNotification(bm,1.5f,"Your " + speciesName + " Slime Increased it's Ooze. It has become stronger!");

        oozeLevel+=addedOoze;
        float hpPercentage = currentHP/maxHP;
        maxHP = hitPointModifier * oozeLevel;
        currentHP = (int)(hpPercentage * maxHP);
        baseAttack = attackModifier * oozeLevel;
        currentAttack = baseAttack;

        }
        
    }
    
    
    public bool convertSlime(int newID){ //this is such an ineffecient and probably incorrect way to do this :(

        Slime s = new Slime(newID);
        this.speciesID = s.speciesID;
        switch(newID){
            case 1:
                this.speciesName = "Wet " + this.speciesName;
                break;
            case 14:
                this.speciesName = "Soapy " + this.speciesName;
                break;
            case 16:
                this.speciesName = "Old "+ this.speciesName;
                break;
            case 2:
                this.speciesName = "Burning "+ this.speciesName;
                break;
            case 3:
                this.speciesName = "Rocky "+ this.speciesName;
                break;
            case 10:
                this.speciesName = "Ashy "+ this.speciesName;
                break;
            case 11:
                this.speciesName = "Coated "+ this.speciesName;
                break;
            case 13:
                this.speciesName = "Dusty "+ this.speciesName;
                break;
            case 34:
                this.speciesName = "Star Struck "+ this.speciesName;
                break;
            case 28:
                this.speciesName = "Shiny "+ this.speciesName;
                break;
            case 29:
                this.speciesName = "Fool's "+ this.speciesName;
                break;
        }
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
   

    public bool takeDamage(int dmg, BattleManager bm,string element = "None", bool checkIfHPLow = false){ //returns true if slime had been defeated
        if(dmg<=0){
            dmg=1;
        }
        currentHP -= dmg;
        if (currentHP<=0){
            currentHP=0;
            //Debug.Log(this.speciesName + " Slime took fatal damage");
            bm.textWindowUI(this.speciesName + " Slime took fatal damage");

            return true;
        }

        //Debug.Log(this.speciesName + " Slime took some damage");
        bm.textWindowUI(this.speciesName + " Slime took some damage");
        return false;
        
    }
    public void healDamage(int healAmount,BattleManager bm){

        currentHP += healAmount;
        if (currentHP>maxHP){
            currentHP=maxHP;
        }
        //Debug.Log(this.speciesName + " Slime Recived healing");
        bm.textWindowUI(this.speciesName + " Slime Recived healing");
        
    }

    public void changeStat(double statChangeModifier, string targetStat, BattleManager bm){
        bool increased = true;
        if(statChangeModifier<1.0f){
            increased=false;
        }
        switch (targetStat){
            case "Atk":
                currentAttack = (int) (currentAttack * statChangeModifier);
                if(increased){
                    bm.textWindowUI(this.speciesName + " Slime's Attack Increased");
                } else {
                    bm.textWindowUI(this.speciesName + " Slime's Attack Decreased");
                }
                break;
             case "Acc":
                accuracy = (int) (accuracy * statChangeModifier);
                if(increased){
                    bm.textWindowUI(this.speciesName + " Slime's Accuracy Increased");
                } else {
                    bm.textWindowUI(this.speciesName + " Slime's Accuracy Decreased");
                }
                break;
             case "Spd":
                currentSpeed = (int) (currentSpeed * statChangeModifier);
                if(increased){
                    bm.textWindowUI(this.speciesName + " Slime's Speed Increased");
                }else {
                    bm.textWindowUI(this.speciesName + " Slime's Speed Decreased");
                }
                break;
        }

        //Debug.Log(this.speciesName + " Slime's stats changed");

    }

    

}