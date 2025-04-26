using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move{
    int moveID;
    public string moveType = "Attack";
    string moveDescription = "This is a Move";
    double attackMulti = 0F;
    int healingValue = 0;
    double statChangeMulti = 0F;
    string element = "None";
    string name = "Move";
    string targetedStat = "Atk";

    int moveTargetingCase =0;

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
                    name = "Splash";
                    moveType = "Splash";
                    attackMulti = 0.7F;
                    element = "Water";
                    //secondary effect: 30% chance convert to water slime
                
                }
                break;
            case 2:
                {
                    name = "Wave Crash";
                    moveType = "Attack Opponents";
                    attackMulti = 0.4F;
                    element = "Water";                
                }
                break;
            case 3:
                {
                    name = "Stabilize";
                    moveType = "Self Heal";
                    healingValue = 2;               
                }
                break;
            case 4:
                {
                    name = "Burn";
                    moveType = "Attack";
                    attackMulti = 1F;
                    element = "Fire";                 
                }
                break;
            case 5:
                {
                    name = "Heat Wave";
                    moveType = "Attack Opponents";
                    attackMulti = 0.6F;
                    element = "Fire";                
                }
                break;
            case 6:
                {
                    name = "Rock Slam";
                    moveType = "Attack";
                    attackMulti = 1.2F;
                }
                break;
            case 7:
                {
                    name = "Rock Slide";
                    moveType = "Attack Opponents";
                    attackMulti = 1F;             
                }
                break;
            case 8:
                {
                    name = "Roll";
                    moveType = "Self Stat Change";
                    statChangeMulti = 1.2F;
                    targetedStat = "Spd";           
                }
                break;
            case 9:
                {
                    name = "Absorb";
                    moveType = "Attack";
                    attackMulti = 0.8F;
          
                }
                break;
            case 10:
                {
                    name = "Vine Wrap";
                    moveType = "Attack";
                    attackMulti = 1.4F;
          
                }
                break;
            case 11:
                {
                    name = "Photosynthesis";
                    moveType = "Self Heal";
                    healingValue = 4;               
                }
                break;
            case 12:
                {
                    name = "Chill";
                    moveType = "Stat Change";
                    statChangeMulti = 0.8;
                    targetedStat = "Spd";            
                }
                break;
            case 13:
                {
                    name = "Freeze";
                    moveType = "Attack";
                    attackMulti = 1.1F;
                    element = "Ice";                 
                }
                break;
            case 14:
                {
                    name = "Freeze Burn";
                    moveType = "Attack Opponents";
                    attackMulti = 0.6F;   
                    element = "Ice";      
                }
                break;
            case 15:
                {
                    name = "Lightning Strike";
                    moveType = "Attack";
                    attackMulti = 1.8F;
                    element = "Lightning";                 
                }
                break;
            case 16:
                {
                    name = "Shock";
                    moveType = "Attack Opponents";
                    attackMulti = 1F;   
                    element = "Lightning";      
                }
                break;
            case 17:
                {
                    name = "Charge";
                    moveType = "Self Stat Change";
                    statChangeMulti = 1.2F;
                    targetedStat = "Atk";           
                }
                break;
            case 18: ///duplicate. replace
                {
                    name = "Chill";
                    moveType = "Stat Change";
                    statChangeMulti = 0.8;
                    targetedStat = "Spd";            
                }
                break;
            case 19:
                {
                    name = "Mud Slap";
                    moveType = "Stat Change";
                    statChangeMulti = 0.80;
                    targetedStat = "Acc";            
                }
                break;
            case 20:
                {
                    name = "Mud Slide";
                    moveType = "Opponents Stat Change";
                    statChangeMulti = 0.80;
                    targetedStat = "Spd";            
                }
                break;
            case 21:
                {
                    name = "Festive Spirit";
                    moveType = "Team Stat Change";
                    statChangeMulti = 1.15;
                    targetedStat = "Atk";            
                }
                break;
            case 22:
                {
                    name = "Snowball";
                    moveType = "Attack";
                    attackMulti = 1.4F;
                    element = "Ice";                 
                }
                break;
            case 23:
                {
                    name = "Embers";
                    moveType = "Attack";
                    attackMulti = 0.7F;
                    element = "Fire";                 
                }
                break;
            case 24:
                {
                    name = "Scatter";
                    moveType = "Self Destruct";               
                }
                break;
            


            default:
                    name = "Struggle";
                    moveType = "Useless";
                break;

        }
    }

    public void setMoveTarget(Slime t){
        target = t;
    }
    
    public bool checkAccuracy(List<Slime> pSlimes,List<Slime> eSlimes){
        if(UnityEngine.Random.Range(0.0f,1.0f)>owner.accuracy){
            return false;
        }
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