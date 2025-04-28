using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move{
    public int moveID;

    public static String[] singleTargetMoves = {"Splash","Attack","Double Attack","Heal","Stat Change"};
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
                    moveType = "Attack";
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
                    moveType = "Stat Change";
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
                    moveType = "Stat Change";
                    statChangeMulti = 0.8;
                    targetedStat = "Spd";            
                }
                break;
            case 19:
                {
                    moveName = "Mud Slap";
                    moveType = "Stat Change";
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
        useMove(pSlimes,eSlimes);
        return true;
    }
    public void useMove(List<Slime> pSlimes,List<Slime> eSlimes){

        


        switch(moveType){

            case "Attack":
                target.takeDamage((int) (owner.currentAttack * attackMulti));
                break;
            case "Double Attack":
                target.takeDamage((int) (owner.currentAttack * attackMulti));
                target.takeDamage((int) (owner.currentAttack * attackMulti));
                break;
            case "Self Heal":
                owner.healDamage(healingValue);
                break;

            case "Heal":
                target.healDamage(healingValue);
                break;

            case "Self Stat Change":
                owner.changeStat(statChangeMulti,targetedStat);
                break;
            case "Stat Change":
                target.changeStat(statChangeMulti,targetedStat);
                break;
            case "Self Destruct":
                owner.takeDamage(owner.currentHP);
                break;
            case "Full Heal":
                owner.healDamage(owner.damageTaken);
                break;
            case "Team Stat Change":
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    target.changeStat(statChangeMulti,targetedStat);
                }
                break;
            case "Team Heal":
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    target.healDamage(healingValue);
                }
                
                break;


                

            case "Attack Opponents":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.takeDamage((int) (owner.currentAttack * attackMulti));
                }
                break;

            case "Opponents Stat Change":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.changeStat(statChangeMulti,targetedStat);
                }
                break;
            case "Heal Opponents": //just covering all cases
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.healDamage(healingValue);
                }   
                break;

                

            case "Attack Others":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.takeDamage((int) (owner.currentAttack * attackMulti));
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    if(!target.Equals(owner))
                        target.takeDamage((int) (owner.currentAttack * attackMulti));
                }   
                break;
            
            case "Heal All":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.healDamage(healingValue);
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    target.healDamage(healingValue);
                }   
                break;

            case "Others Stat Change":
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.changeStat(statChangeMulti,targetedStat);
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    if(!target.Equals(owner))
                        target.changeStat(statChangeMulti,targetedStat);
                }   
                break;
            case "Self Destruct And Damage":
                
                for(int i=0; i<eSlimes.Count;i++){
                    target = eSlimes[i];
                    target.takeDamage((int) (owner.currentAttack * attackMulti));
                }   
                for(int i=0; i<pSlimes.Count;i++){
                    target = pSlimes[i];
                    if(!target.Equals(owner))
                        target.takeDamage((int) (owner.currentAttack * attackMulti));
                }   
                owner.takeDamage(owner.currentHP);

                break;
            //Special Moves
            case "Splash":
                target.takeDamage((int) (owner.currentAttack * attackMulti));
                //chang to water slime
                break;
            default:
                //Text: move was used, nothing happened
                break;
        }

        

    }


    
}