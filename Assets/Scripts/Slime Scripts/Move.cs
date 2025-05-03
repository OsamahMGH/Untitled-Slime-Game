using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move{
    public int moveID;

    public static String[] singleTargetMovesNegative = {"Forage","Mimic","Trash","Acid","Bubble","D Stat Change N","Absorb","Splash","Attack","Double Attack","Stat Change N"};
    public static String[] singleTargetMovesPositive = {"Heal","Stat Change P"};
    public string moveType = "Attack";
    public string moveDescription = "This is a Move";
    public double attackMulti = 0F;
    public int healingValue = 0;
    public double statChangeMulti = 0F;
    public string element = "None";
    public string moveName = "Move";
    public string targetedStat = "Atk";

    public int moveTargetingCase =0;

    public Slime owner;
    public Slime target;

    

    //secondary effects of certain moves are handled in the useMove method

    //Constructor
    public Move(int iD, Slime s){
        moveID =iD;
        owner = s;
        target = owner;

        switch(moveID){

            case 1:
                {
                    moveName = "Splash";
                    moveType = "Splash";
                    attackMulti = 0.7F;
                    element = "Water";
                    //secondary effect: 30% chance convert to water slime
                
                }
                break;
            case 2:
                {
                    moveName = "Wave Crash";
                    moveType = "Attack Opponents";
                    attackMulti = 0.4F;
                    element = "Water";                
                }
                break;
            case 3:
                {
                    moveName = "Stabilize";
                    moveType = "Self Heal";
                    healingValue = 2;               
                }
                break;
            case 4:
                {
                    moveName = "Burn";
                    moveType = "Attack";
                    attackMulti = 1F;
                    element = "Fire";                 
                }
                break;
            case 5:
                {
                    moveName = "Heat Wave";
                    moveType = "Attack Opponents";
                    attackMulti = 0.6F;
                    element = "Fire";                
                }
                break;
            case 6:
                {
                    moveName = "Rock Slam";
                    moveType = "Attack";
                    attackMulti = 1.2F;
                }
                break;
            case 7:
                {
                    moveName = "Rock Slide";
                    moveType = "Attack Opponents";
                    attackMulti = 1F;             
                }
                break;
            case 8:
                {
                    moveName = "Roll";
                    moveType = "Self Stat Change";
                    statChangeMulti = 1.2F;
                    targetedStat = "Spd";           
                }
                break;
            case 9:
                {
                    moveName = "Absorb";
                    moveType = "Absorb"; //uniqe
                    attackMulti = 0.8F;
          
                }
                break;
            case 10:
                {
                    moveName = "Vine Wrap";
                    moveType = "Attack";
                    attackMulti = 1.4F;
          
                }
                break;
            case 11:
                {
                    moveName = "Photosynthesis";
                    moveType = "Self Heal";
                    healingValue = 4;               
                }
                break;
            case 12:
                {
                    moveName = "Chill";
                    moveType = "Stat Change N";
                    statChangeMulti = 0.8;
                    targetedStat = "Spd";            
                }
                break;
            case 13:
                {
                    moveName = "Freeze";
                    moveType = "Attack";
                    attackMulti = 1.1F;
                    element = "Ice";                 
                }
                break;
            case 14:
                {
                    moveName = "Freeze Burn";
                    moveType = "Attack Opponents";
                    attackMulti = 0.6F;   
                    element = "Ice";      
                }
                break;
            case 15:
                {
                    moveName = "Lightning Strike";
                    moveType = "Attack";
                    attackMulti = 1.8F;
                    element = "Lightning";                 
                }
                break;
            case 16:
                {
                    moveName = "Shock";
                    moveType = "Attack Opponents";
                    attackMulti = 1F;   
                    element = "Lightning";      
                }
                break;
            case 17:
                {
                    moveName = "Charge";
                    moveType = "Self Stat Change";
                    statChangeMulti = 1.2F;
                    targetedStat = "Atk";           
                }
                break;
            case 18: ///duplicate. replace
                {
                    moveName = "Chill";
                    moveType = "Stat Change N";
                    statChangeMulti = 0.8;
                    targetedStat = "Spd";            
                }
                break;
            case 19:
                {
                    moveName = "Mud Slap";
                    moveType = "Stat Change N";
                    statChangeMulti = 0.80;
                    targetedStat = "Acc";            
                }
                break;
            case 20:
                {
                    moveName = "Mud Slide";
                    moveType = "Opponents Stat Change";
                    statChangeMulti = 0.80;
                    targetedStat = "Spd";            
                }
                break;
            case 21:
                {
                    moveName = "Festive Spirit";
                    moveType = "Team Stat Change";
                    statChangeMulti = 1.15;
                    targetedStat = "Atk";            
                }
                break;
            case 22:
                {
                    moveName = "Snowball";
                    moveType = "Attack";
                    attackMulti = 1.4F;
                    element = "Ice";                 
                }
                break;
            case 23:
                {
                    moveName = "Embers";
                    moveType = "Attack";
                    attackMulti = 0.7F;
                    element = "Fire";                 
                }
                break;
            case 24:
                {
                    moveName = "Scatter";
                    moveType = "Self Destruct";               
                }
                break;
            case 25:
                {
                    moveName = "Polish";
                    moveType = "Self Stat Change";   
                    statChangeMulti=1.2;   
                    targetedStat = "Atk" ;        
                }
                break;
            case 26:
                {
                    moveName = "Sharpen";
                    moveType = "Stat Change P";   
                    statChangeMulti = 1.3;   
                    targetedStat = "Atk";         
                }
                break;
            case 27:
                {
                    moveName = "Bash";
                    moveType = "Attack";  
                    attackMulti = 1.5f;             
                }
                break;
            case 28:
                {
                    moveName = "Mushroom Journey";
                    moveType = "Random Stat Change";  ///Unique 
                    statChangeMulti =1.5f;            
                }
                break;
            case 29:
                {
                    moveName = "Infection";
                    moveType = "Attack";   
                    attackMulti = 1.8f;            
                }
                break;
            case 30:
                {
                    moveName = "Sand Gust";
                    moveType = "D Stat Change N"; //uniqe   
                    targetedStat = "Acc";      
                    statChangeMulti = 0.85f;     
                }
                break;
            case 31:
                {
                    moveName = "Sand Castle";
                    moveType = "D Self Heal"; //uniqe   
                    healingValue = 3;          
                }
                break;
            case 32:
                {
                    moveName = "Tides";
                    moveType = "Double Attack"; //uniqe   
                    attackMulti = 0.6f;          
                }
                break;
            case 33:
                {
                    moveName = "Bubble Beam";
                    moveType = "Bubble"; //uniqe   
                    attackMulti = 0.7f;          
                }
                break;
            case 34:
                {
                    moveName = "Slippery Soap";
                    moveType = "Stat Change N"; 
                    targetedStat = "Acc";      
                    statChangeMulti = 0.9f;     
                }
                break;
            case 35:
                {
                    moveName = "Bubble Pop";
                    moveType = "Attack";   
                    attackMulti = 0.5f;            
                }
                break;
            case 36:
                {
                    moveName = "Poisonous Gas";
                    moveType = "Attack Opponents";
                    attackMulti = 0.4F;       
                }
                break;
            case 37:
                {
                    moveName = "Venomous Bite";
                    moveType = "Attack";
                    attackMulti = 1.4F;       
                }
                break;
            case 38:
                {
                    moveName = "Acid Spray";
                    moveType = "Acid"; //Uniqe
                    attackMulti = 0.3F;       
                }
                break;
            case 39:
                {
                    moveName = "Tackle";
                    moveType = "Attack"; 
                    attackMulti = 0.3F;       
                }
                break;
            case 40:
                {
                    moveName = "Smoke Screen";
                    moveType = "Stat Change N"; 
                    targetedStat = "Acc";      
                    statChangeMulti = 0.85f;     
                }
                break;
             case 41:
                {
                    moveName = "Strong Aroma";
                    moveType = "Stat Change P"; 
                    targetedStat = "Atk";      
                    statChangeMulti = 1.2f;     
                }
                break;
            case 42:
                {
                    moveName = "Strong Odor";
                    moveType = "Stat Change N"; 
                    targetedStat = "Atk";      
                    statChangeMulti = 0.8f;     
                }
                break;
            case 43:
                {
                   moveName = "Suffocation";
                    moveType = "Attack Opponents";
                    attackMulti = 0.5F;      
                }
                break;
            case 44:
                {
                    moveName = "Pollute";
                    moveType = "Attack"; 
                    attackMulti = 1F;       
                }
                break;
            case 45:
                {
                    moveName = "Controlled Explosion";
                    moveType = "Attack Opponents"; 
                    attackMulti = 1F;       
                }
                break;
            case 46:
                {
                    moveName = "Mass Explosion";
                    moveType = "Self Destruct And Damage"; 
                    attackMulti = 1.2F;       
                }
                break;

            case 47:
                {
                    moveName = "Sticky";
                    moveType = "Stat Change N"; 
                    targetedStat = "Spd";      
                    statChangeMulti = 0.7f;        
                }
                break;
            case 48:
                {
                    moveName = "Oil Slap";
                    moveType = "Stat Change N"; 
                    targetedStat = "Acc";      
                    statChangeMulti = 0.9f;        
                }
                break;
            case 49:
                {
                    moveName = "Sap";
                    moveType = "Stat Change N"; 
                    targetedStat = "Spd";      
                    statChangeMulti = 0.9f;        
                }
                break;
            case 50:
                {
                    moveName = "Habitat";
                    moveType = "Habitat"; //Uniqe       
                }
                break;
            case 51:
                {
                    moveName = "Spoonful";
                    moveType = "Self Heal"; 
                    healingValue = 6;
                }
                break;
            case 52:
                {
                    moveName = "Sugar Rush";
                    moveType = "Stat Change P"; 
                    targetedStat = "Spd";      
                    statChangeMulti = 1.12f;        
                }
                break;
            case 53:
                {
                    moveName = "Picnic Time";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.5F;       
                }
                break;
            case 54:
                {
                    moveName = "Tasty Scoop";
                    moveType = "Stat Change P"; 
                    targetedStat = "Atk";      
                    statChangeMulti = 1.4f;  
                }
                break;
            case 55:
                {
                    moveName = "Summoning Circle";
                    moveType = "Summon Circle"; //uniqe
                     
                }
                break;
            case 56:
                {
                    moveName = "Stardust Burst";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.4F;       
                }
                break;
            case 57:
                {
                    moveName = "Practice";
                    moveType = "Self Stat Change";   
                    statChangeMulti=1.4f;   
                    targetedStat = "Atk" ;        
                }
                break;
            case 58:
                {
                    moveName = "Bite";
                    moveType = "Attack"; 
                    attackMulti = 1.7F;       
                }
                break;
            case 59:
                {
                    moveName = "Burrow";
                    moveType = "Opponents Stat Change";
                    statChangeMulti = 0.80f;
                    targetedStat = "Acc";            
                }
                break;
            case 60:
                {
                    moveName = "Leap";
                    moveType = "Self Stat Change";   
                    statChangeMulti=1.5f;   
                    targetedStat = "Spd" ;        
                }
                break;
            case 61:
                {
                    moveName = "School Fish";
                    moveType = "Attack Opponents"; 
                    attackMulti = 1.2F;       
                }
                break;
            case 62:
                {
                    moveName = "Eel Bite";
                    moveType = "Attack"; 
                    attackMulti = 1.7F;       
                }
                break;
            case 63:
                {
                    moveName = "Fish Nibbles";
                    moveType = "Attack"; 
                    attackMulti = 0.1F;       
                }
                break;
            case 64:
                {
                    moveName = "Glimmer";
                    moveType = "Useless";        
                }
                break;
            case 65:
                {
                    moveName = "Shine";
                    moveType = "Useless";        
                }
                break;
            case 66:
                {
                    moveName = "Shine";
                    moveType = "Useless";        
                }
                break;
            case 67:
                {
                    moveName = "Shine";
                    moveType = "Useless";        
                }
                break;
            case 68:
                {
                    moveName = "Investment";
                    moveType = "Self Heal";
                    healingValue = 10;               
                }
                break;
            case 69:
                {
                    moveName = "Brighten Up";
                    moveType = "Team Stat Change";
                    targetedStat = "Acc" ;
                    statChangeMulti = 1.6f;              
                }
                break;
            case 70:
                {
                    moveName = "Trash";
                    moveType = "Trash"; //uniqe
                    attackMulti = 0.1F;
                
                }
                break;
            case 71:
                {
                    moveName = "Swallow";
                    moveType = "Attack"; 
                    attackMulti = 10.0F;       
                }
                break;
            case 72:
                {
                    moveName = "Digest";
                    moveType = "Useless";        
                }
                break;
             case 73:
                {
                    moveName = "Mimic";
                    moveType = "Mimic";        //uniqe
                }
                break;
            case 74:
                {
                    moveName = "Meteor Shower";
                    moveType = "Attack Opponents"; 
                    attackMulti = 2.0F;       
                }
                break;
            case 75:
                {
                    moveName = "Pie Throw";
                    moveType = "Attack"; 
                    attackMulti = 2.2F;       
                }
                break;
            case 76:
                {
                    moveName = "Ballon Pop";
                    moveType = "Attack"; 
                    attackMulti = 0.4F;       
                }
                break;
            case 77:
                {
                    moveName = "Clown tears";
                    moveType = "Opponents Stat Change";
                    statChangeMulti = 0.60f;
                    targetedStat = "Atk";            
                }
                break;
            case 78:
                {
                    moveName = "Hail Storm";
                    element ="Ice";
                    moveType = "Attack Opponents"; 
                    attackMulti = 2.0F;       
                }
                break;
            case 79:
                {
                    moveName = "Lightning Strike";
                    element = "Lightning";
                    moveType = "Attack"; 
                    attackMulti = 3F;       
                }
                break;
            case 80:
                {
                    moveName = "Mighty Winds";
                    moveType = "Team Stat Change";
                    targetedStat = "Spd" ;
                    statChangeMulti = 1.5f;              
                }
                break;
            case 81:
                {
                    moveName = "Shell Crack";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.4F;       
                }
                break;
            case 82:
                {
                    moveName = "Tentacle Wrap";
                    moveType = "Attack"; 
                    attackMulti = 1.8F;       
                }
                break;
            case 83:
                {
                    moveName = "Camouflage";
                    moveType = "Self Stat Change";   
                    statChangeMulti=2.5f;   
                    targetedStat = "Atk" ;        
                }
                break;
            case 84:
                {
                    moveName = "Inky Escape";
                    moveType = "Stat Change N"; 
                    targetedStat = "Acc";      
                    statChangeMulti = 0.8f;  
                }
                break;
            case 85:
                {
                    moveName = "Forage";
                    moveType = "Forage";   //uniqe
                    statChangeMulti=1.4f;   
                    targetedStat = "Atk" ;   
                    healingValue = 8;     
                }
                break;
            case 86:
                {
                    moveName = "Claw";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.6F;       
                }
                break;
            case 87:
                {
                    moveName = "Alchemy";
                    moveType = "Alchemy"; //uniqe     
                }
                break;
            case 88:
                {
                    moveName = "Bounce";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.8F;       
                }
                break;
            case 89:
                {
                    moveName = "Belly Slam";
                    moveType = "Attack"; 
                    attackMulti = 1.8F;       
                }
                break;
            case 90:
                {
                    moveName = "Snack Time";
                    moveType = "Self Heal"; 
                    healingValue = 4;      
                }
                break;

            


            default:
                    moveName = "Struggle";
                    moveType = "Useless";
                break;
            


        }
    }

    public void setMoveTarget(Slime t){
        target = t;
    }
    
    public bool checkAccuracy(List<Slime> pSlimes,List<Slime> eSlimes){
        if(UnityEngine.Random.Range(0.0f,1.0f)>owner.accuracy){
            Debug.Log(owner.speciesName+ "Slime tried to use " + moveName + " but it missed");
            return false;
        }
        Debug.Log(this.owner.speciesName + " Slime used " + this.moveName);
        //useMove(pSlimes,eSlimes);
        return true;
    }
    public void useMove(List<Slime> pSlimes,List<Slime> eSlimes,BattleManager bm){

        


        switch(moveType){

            case "Attack":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                break;
            case "Double Attack":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                break;
            case "Self Heal":
                owner.healDamage(healingValue,bm);
                break;
            case "D Self Heal":
                owner.healDamage(healingValue,bm);
                owner.healDamage(healingValue,bm);
                break;

            case "Heal":
                target.healDamage(healingValue,bm);
                break;

            case "Self Stat Change":
                owner.changeStat(statChangeMulti,targetedStat,bm);
                break;
            case "Stat Change P":
                target.changeStat(statChangeMulti,targetedStat,bm);
                break;
            case "Stat Change N":
                target.changeStat(statChangeMulti,targetedStat,bm);
                break;
            case "D Stat Change N":
                target.changeStat(statChangeMulti,targetedStat,bm);
                target.changeStat(statChangeMulti,targetedStat,bm);
                break;
            case "Self Destruct":
                owner.takeDamage(owner.currentHP,bm);
                break;
            case "Full Heal":
                owner.healDamage(owner.damageTaken,bm);
                break;
            case "Team Stat Change":
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    target.changeStat(statChangeMulti,targetedStat,bm);
                }
                break;
            case "Team Heal":
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    target.healDamage(healingValue,bm);
                }
                
                break;


                

            case "Attack Opponents":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                }
                break;

            case "Opponents Stat Change":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.changeStat(statChangeMulti,targetedStat,bm);
                }
                break;
            case "Heal Opponents": //just covering all cases
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.healDamage(healingValue,bm);
                }   
                break;

                

            case "Attack Others":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    if(!target.Equals(owner))
                        target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                }   
                break;
            
            case "Heal All":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.healDamage(healingValue,bm);
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    target.healDamage(healingValue,bm);
                }   
                break;

            case "Others Stat Change":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.changeStat(statChangeMulti,targetedStat,bm);
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    if(!target.Equals(owner))
                        target.changeStat(statChangeMulti,targetedStat,bm);
                }   
                break;
            case "Self Destruct And Damage":
                
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.takeDamage((int) (owner.currentAttack * attackMulti), bm);
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    if(!target.Equals(owner))
                        target.takeDamage((int) (owner.currentAttack * attackMulti), bm);
                }   
                owner.takeDamage(owner.currentHP, bm);

                break;
            //Special Moves
            case "Splash":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                if(UnityEngine.Random.Range(0f,1f)>0.4f){
                    target.convertSlime(1);
                }
                break;

            case "Random Stat Change":
                string [] targetedStatList = {"Atk","Acc","Spd"};
                owner.changeStat(statChangeMulti,targetedStatList[UnityEngine.Random.Range(0,targetedStatList.Length)],bm);
                break;
            case "Bubble":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                if(UnityEngine.Random.Range(0f,1f)>0.5f){
                    target.convertSlime(14);
                }
                break;
            case "Acid":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                if(UnityEngine.Random.Range(0f,1f)>0.2f){
                    target.convertSlime(16);
                }
                break;
             case "Habitat":
                    int[] itemList = {4,12,22};
                    bm.player.reciveItem(itemList[UnityEngine.Random.Range(0,itemList.Length)]);

                break;
            case "Summon Circle":
                    int[] itemList2 = {15,25,26};
                    bm.player.reciveItem(itemList2[UnityEngine.Random.Range(0,itemList2.Length)]);
                break;
            case "Trash":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                    target.convertSlime(31);
                break;
            case "Mimic":
                    owner.convertSlime(target.speciesID);
                    
                break;
            case "Alchemy":
                int[] possibleConversions = {2,3,10,11,13,34,28,29};
                    target.convertSlime(possibleConversions[UnityEngine.Random.Range(0,possibleConversions.Length)]);
                break;
            case "Forage":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                owner.changeStat(statChangeMulti,targetedStat,bm);
                break;
             case "Absorb":
                target.takeDamage((int) (owner.currentAttack * attackMulti),bm);
                owner.healDamage((int)(owner.currentAttack * attackMulti),bm);
                break;





            default:
                //Text: move was used, nothing happened
                break;
        }

        

    }


    
}