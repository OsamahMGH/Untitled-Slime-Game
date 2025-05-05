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
                    moveDescription = "Splashes the target with water, dealing damage with a chance to convert their base stats into that of a Water Slime\n"+"Power: "+Math.Round(attackMulti*100)+"";
                    //secondary effect: 30% chance convert to water slime
                
                }
                break;
            case 2:
                {
                    moveName = "Wave Crash";
                    moveType = "Attack Opponents";
                    attackMulti = 0.4F;
                    moveDescription = "Unleashes a wave that damges all opponents\n"+"Power: "+Math.Round(attackMulti*100)+"";
                    element = "Water";                
                }
                break;
            case 3:
                {
                    moveName = "Stabilize";
                    moveType = "Self Heal";
                    moveDescription = "Slightly recovers health";
                    healingValue = 2;               
                }
                break;
            case 4:
                {
                    moveName = "Burn";
                    moveType = "Attack";
                    attackMulti = 1F;
                    element = "Fire";
                    moveDescription = "A scorching blast that damages the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
                 
                }
                break;
            case 5:
                {
                    moveName = "Heat Wave";
                    moveType = "Attack Opponents";
                    attackMulti = 0.6F;
                    element = "Fire";      
                    moveDescription = "Unleashes a hot wave that damges all opponents\n"+"Power: "+Math.Round(attackMulti*100)+"";
          
                }
                break;
            case 6:
                {
                    moveName = "Rock Slam";
                    moveType = "Attack";
                    attackMulti = 1.2F;
                    moveDescription = "Slams the target with this Slime's hard body\n"+"Power: "+Math.Round(attackMulti*100)+"";

                }
                break;
            case 7:
                {
                    moveName = "Rock Slide";
                    moveType = "Attack Opponents";
                    attackMulti = 1F;       
                    moveDescription = "Crushes the opponents with several rocks\n"+"Power: "+Math.Round(attackMulti*100)+"";
      
                }
                break;
            case 8:
                {
                    moveName = "Roll";
                    moveType = "Self Stat Change";
                    statChangeMulti = 1.2F;
                    targetedStat = "Spd";   
                    moveDescription = "Increases speed by rolling in place\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
        
                }
                break;
            case 9:
                {
                    moveName = "Absorb";
                    moveType = "Absorb"; //uniqe
                    attackMulti = 0.8F;
                    moveDescription = "Absorbs the target's health and convert some of it into healing\n"+"Power: "+Math.Round(attackMulti*100)+"";

          
                }
                break;
            case 10:
                {
                    moveName = "Vine Wrap";
                    moveType = "Attack";
                    attackMulti = 1.4F;
                    moveDescription = "Tightly wraps several vines around the target to deal damage\n"+"Power: "+Math.Round(attackMulti*100)+"";

          
                }
                break;
            case 11:
                {
                    moveName = "Photosynthesis";
                    moveType = "Self Heal";
                    healingValue = 4;   
                    moveDescription = "Recovers health through a biological process we are all familiar with\n";            
                }
                break;
            case 12:
                {
                    moveName = "Chill";
                    moveType = "Stat Change N";
                    statChangeMulti = 0.8;
                    targetedStat = "Spd";   
                    moveDescription = "Decreases the target's speed by releasing a chiling wave in the air\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
                         
                }
                break;
            case 13:
                {
                    moveName = "Freeze";
                    moveType = "Attack";
                    attackMulti = 1.1F;
                    element = "Ice";  
                    moveDescription = "Deals damage to the target with a very cold blast\n"+"Power: "+Math.Round(attackMulti*100)+"";
                                  
                }
                break;
            case 14:
                {
                    moveName = "Freeze Burn";
                    moveType = "Attack Opponents";
                    attackMulti = 0.6F;   
                    element = "Ice";  
                    moveDescription = "Deals damage to opponents with a bone chilling blast, though Slimes don't have bones.. Right?\n"+"Power: "+Math.Round(attackMulti*100)+"";
    
                }
                break;
            case 15:
                {
                    moveName = "Lightning Strike";
                    moveType = "Attack";
                    attackMulti = 1.8F;
                    element = "Lightning";   
                    moveDescription = "Strikes the target with mighty lightning, dealing a lot of damage\n"+"Power: "+Math.Round(attackMulti*100)+"";
              
                }
                break;
            case 16:
                {
                    moveName = "Shock";
                    moveType = "Attack Opponents";
                    attackMulti = 1F;   
                    element = "Lightning"; 
                    moveDescription = "Zaps the opponents and deals damage\n"+"Power: "+Math.Round(attackMulti*100)+"";
     
                }
                break;
            case 17:
                {
                    moveName = "Charge";
                    moveType = "Self Stat Change";
                    statChangeMulti = 1.2F;
                    targetedStat = "Atk";   
                    moveDescription = "Builds up power and increases attack\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
        
                }
                break;
            case 18: ///duplicate. replace
                {
                    moveName = "Chill";
                    moveType = "Stat Change N";
                    statChangeMulti = 0.8;
                    targetedStat = "Spd";  
                    moveDescription = "Decreases the target's speed by releasing a chiling wave in the air\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";

                }
                break;
            case 19:
                {
                    moveName = "Mud Slap";
                    moveType = "Stat Change N";
                    statChangeMulti = 0.80;
                    targetedStat = "Acc";   
                    moveDescription = "Decreases the target's accuracy by slapping them with fresh mudd\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
         
                }
                break;
            case 20:
                {
                    moveName = "Mud Slide";
                    moveType = "Opponents Stat Change";
                    statChangeMulti = 0.80;
                    targetedStat = "Spd";
                    moveDescription = "Decreases the opponents' speed by spewing a wave of hot mudd\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
            
                }
                break;
            case 21:
                {
                    moveName = "Festive Spirit";
                    moveType = "Team Stat Change";
                    statChangeMulti = 1.15;
                    targetedStat = "Atk";      
                    moveDescription = "Increases your team' attack through the jolly spirit of a non-specific holiday\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
      
                }
                break;
            case 22:
                {
                    moveName = "Snowball";
                    moveType = "Attack";
                    attackMulti = 1.4F;
                    element = "Ice";  
                    moveDescription = "Throws a perfectly shaped snowball in the target's face, dealing damage\n"+"Power: "+Math.Round(attackMulti*100)+"";
               
                }
                break;
            case 23:
                {
                    moveName = "Embers";
                    moveType = "Attack";
                    attackMulti = 0.7F;
                    element = "Fire"; 
                    moveDescription = "Damages the target with sparks of fire\n"+"Power: "+Math.Round(attackMulti*100)+"";
                
                }
                break;
            case 24:
                {
                    moveName = "Scatter";
                    moveType = "Self Destruct"; 
                    moveDescription = "Scatters this slimes ashes in the wind, destroying itself";
              
                }
                break;
            case 25:
                {
                    moveName = "Polish";
                    moveType = "Self Stat Change";   
                    statChangeMulti=1.2;   
                    targetedStat = "Atk" ;   
                    moveDescription = "Increases attack by polishing this Slime's body\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
     
                }
                break;
            case 26:
                {
                    moveName = "Sharpen";
                    moveType = "Stat Change P";   
                    statChangeMulti = 1.3;   
                    targetedStat = "Atk";   
                    moveDescription = "Increases target's attack by sharpening.. their slimy body?\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
      
                }
                break;
            case 27:
                {
                    moveName = "Bash";
                    moveType = "Attack";  
                    attackMulti = 1.5f;   
                    moveDescription = "Bashes the target into the ground, dealing heavy damage\n"+"Power: "+Math.Round(attackMulti*100)+"";
          
                }
                break;
            case 28:
                {
                    moveName = "Mushroom Journey";
                    moveType = "Random Stat Change";  ///Unique 
                    statChangeMulti =1.5f;    
                    moveDescription = "Sharply increases a random stat thanks to the mysterious and totally legal power of shrooms\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
        
                }
                break;
            case 29:
                {
                    moveName = "Infection";
                    moveType = "Attack";   
                    attackMulti = 1.8f;     
                    moveDescription = "Unleashes fungal spores that deal heavy damage to the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
       
                }
                break;
            case 30:
                {
                    moveName = "Sand Gust";
                    moveType = "D Stat Change N"; //uniqe   
                    targetedStat = "Acc";      
                    statChangeMulti = 0.85f;     
                    moveDescription = "Decreases the target's accuracy by launching sand into their eyes\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";

                }
                break;
            case 31:
                {
                    moveName = "Sand Castle";
                    moveType = "D Self Heal"; //uniqe   
                    healingValue = 3; 
                    moveDescription = "Recover health by forming a sand castle";
         
                }
                break;
            case 32:
                {
                    moveName = "Tides";
                    moveType = "Double Attack"; //uniqe   
                    attackMulti = 0.6f;  
                    moveDescription = "Deals damage to the target by mimicing the movements of the tides\n"+"Power: "+Math.Round(attackMulti*100)+"";
        
                }
                break;
            case 33:
                {
                    moveName = "Bubble Beam";
                    moveType = "Bubble"; //uniqe   
                    attackMulti = 0.7f;   
                    moveDescription = "Unleashes a beam of bubbles that damages the target with a chance to convert their base stats into that of a Bubbly Slime's\n"+"Power: "+Math.Round(attackMulti*100)+"";
       
                }
                break;
            case 34:
                {
                    moveName = "Slippery Soap";
                    moveType = "Stat Change N"; 
                    targetedStat = "Acc";      
                    statChangeMulti = 0.9f;    
                    moveDescription = "Decreases the target's accuracy by covering the ground in bubble soap\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
 
                }
                break;
            case 35:
                {
                    moveName = "Bubble Pop";
                    moveType = "Attack";   
                    attackMulti = 0.5f;   
                    moveDescription = "A bubble pop that surprisingly damages the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
         
                }
                break;
            case 36:
                {
                    moveName = "Poisonous Gas";
                    moveType = "Attack Opponents";
                    attackMulti = 0.7F;   
                    moveDescription = "Spews poisonous gas that damages opponents\n"+"Power: "+Math.Round(attackMulti*100)+"";

                }
                break;
            case 37:
                {
                    moveName = "Venomous Bite";
                    moveType = "Attack";
                    attackMulti = 1.4F;   
                    moveDescription = "A venomous bite that seriously damages the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
    
                }
                break;
            case 38:
                {
                    moveName = "Acid Spray";
                    moveType = "Acid"; //Uniqe
                    attackMulti = 0.3F;  
                    moveDescription = "Sprays acid that burns the target with a chance to convert their base stats into that of a Worn-Out Slime\n"+"Power: "+Math.Round(attackMulti*100)+"";
     
                }
                break;
            case 39:
                {
                    moveName = "Tackle";
                    moveType = "Attack"; 
                    attackMulti = 0.3F;  
                    moveDescription = "A pathatic attack that damages the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
     
                }
                break;
            case 40:
                {
                    moveName = "Smoke Screen";
                    moveType = "Stat Change N"; 
                    targetedStat = "Acc";      
                    statChangeMulti = 0.85f;   
                    moveDescription = "Decreases the target's accuracy by spewing a cloud of smoke in their face\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
  
                }
                break;
             case 41:
                {
                    moveName = "Strong Aroma";
                    moveType = "Stat Change P"; 
                    targetedStat = "Atk";      
                    statChangeMulti = 1.3f;     
                    moveDescription = "An aroma that increases the target's attack\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";

                }
                break;
            case 42:
                {
                    moveName = "Strong Odor";
                    moveType = "Stat Change N"; 
                    targetedStat = "Atk";      
                    statChangeMulti = 0.7f;   
                    moveDescription = "A stench that decreases the target's attack\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
  
                }
                break;
            case 43:
                {
                    moveName = "Suffocation";
                    moveType = "Attack Opponents";
                    attackMulti = 0.5F;      
                    moveDescription = "Releases a suffocating cloud of smoke that damages opponents\n"+"Power: "+Math.Round(attackMulti*100)+"";

                }
                break;
            case 44:
                {
                    moveName = "Pollute";
                    moveType = "Attack"; 
                    attackMulti = 1F;   
                    moveDescription = "An environmentally harmful attack that damages the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
    
                }
                break;
            case 45:
                {
                    moveName = "Controlled Explosion";
                    moveType = "Attack Opponents"; 
                    attackMulti = 1F;   
                    moveDescription = "An explosion that damages the opponents\n"+"Power: "+Math.Round(attackMulti*100)+"";
    
                }
                break;
            case 46:
                {
                    moveName = "Mass Explosion";
                    moveType = "Self Destruct And Damage"; 
                    attackMulti = 1.5F;  
                    moveDescription = "A powerful explosion that takes out the user and deals serious damage to the opponents \n"+"Power: "+Math.Round(attackMulti*100)+"";
     
                }
                break;

            case 47:
                {
                    moveName = "Sticky";
                    moveType = "Stat Change N"; 
                    targetedStat = "Spd";      
                    statChangeMulti = 0.7f;      
                    moveDescription = "Decreases the target's speed by covering them with a sticky substance\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
  
                }
                break;
            case 48:
                {
                    moveName = "Oil Slapp";
                    moveType = "Stat Change N"; 
                    targetedStat = "Atk";      
                    statChangeMulti = 0.8f;    
                    moveDescription = "Intimidates the target by taking them to court, decreasing their attack\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
    
                }
                break;
            case 49:
                {
                    moveName = "Sap";
                    moveType = "Stat Change N"; 
                    targetedStat = "Spd";      
                    statChangeMulti = 0.9f;   
                    moveDescription = "Tree sap that decreases the target's speed\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
     
                }
                break;
            case 50:
                {
                    moveName = "Habitat";
                    moveType = "Habitat"; //Uniqe   
                     moveDescription = "Provide items that are likely to invite Forest Slimes";    
                }
                break;
            case 51:
                {
                    moveName = "Spoonful";
                    moveType = "Heal"; 
                    healingValue = 6;
                    moveDescription = "Feeds the target and recovers their health";
                }
                break;
            case 52:
                {
                    moveName = "Sugar Rush";
                    moveType = "Stat Change P"; 
                    targetedStat = "Spd";      
                    statChangeMulti = 1.12f;     
                    moveDescription = "Increases the target's speed by feeding them\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
   
                }
                break;
            case 53:
                {
                    moveName = "Picnic Time";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.5F;   
                    moveDescription = "Go on a picnic, your opponents will feel sad for not being invited and take damage\n"+"Power: "+Math.Round(attackMulti*100)+"";
    
                }
                break;
            case 54:
                {
                    moveName = "Tasty Scoop";
                    moveType = "Stat Change P"; 
                    targetedStat = "Atk";      
                    statChangeMulti = 1.4f;  
                    moveDescription = "A big scoop of ice cream that increases the target's attack\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";

                }
                break;
            case 55:
                {
                    moveName = "Summoning Circle";
                    moveType = "Summon Circle"; //uniqe
                    moveDescription = "Summons magical items that are likely to invite Castle Slimes";
                     
                }
                break;
            case 56:
                {
                    moveName = "Stardust Burst";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.4F;
                    moveDescription = "A burst of cosmic dust that damages opponents\n"+"Power: "+Math.Round(attackMulti*100)+"";
       
                }
                break;
            case 57:
                {
                    moveName = "Practice";
                    moveType = "Self Stat Change";   
                    statChangeMulti=1.4f;   
                    targetedStat = "Atk" ;    
                    moveDescription = "Increases attack through a reliable approach\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
    
                }
                break;
            case 58:
                {
                    moveName = "Bite";
                    moveType = "Attack"; 
                    attackMulti = 1.7F;   
                    moveDescription = "A powerful attack that will definitely leave a mark on the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
    
                }
                break;
            case 59:
                {
                    moveName = "Burrow";
                    moveType = "Opponents Stat Change";
                    statChangeMulti = 0.80f;
                    targetedStat = "Acc";      
                    moveDescription = "Makes it harder for opponents to hit this slime by burrowing underground\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
      
                }
                break;
            case 60:
                {
                    moveName = "Leap";
                    moveType = "Self Stat Change";   
                    statChangeMulti=1.5f;   
                    targetedStat = "Spd" ; 
                    moveDescription = "Increases speed by jumping like, well.. a bunny\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
       
                }
                break;
            case 61:
                {
                    moveName = "School Fish";
                    moveType = "Attack Opponents"; 
                    attackMulti = 1.2F;     
                    moveDescription = "A swarm of fish that will damage opponents on their way to gain higher education\n"+"Power: "+Math.Round(attackMulti*100)+"";
  
                }
                break;
            case 62:
                {
                    moveName = "Eel Bite";
                    moveType = "Attack"; 
                    attackMulti = 1.7F;      
                    moveDescription = "The bite of an electric eel that lives inside of this Coral Slime, dealing high damage to the target\n"+"Power: "+Math.Round(attackMulti*100)+"";
 
                }
                break;
            case 63:
                {
                    moveName = "Fish Nibbles";
                    moveType = "Attack"; 
                    attackMulti = 0.1F;   
                    moveDescription = "Several fish nibble at the target dealing low damage\n"+"Power: "+Math.Round(attackMulti*100)+"";
    
                }
                break;
            case 64:
                {
                    moveName = "Glimmer";
                    moveType = "Useless";     
                    moveDescription = "Glimmer in place like you have nothing better to do";   
                }
                break;
            case 65:
                {
                    moveName = "Shine";
                    moveType = "Useless";    
                     moveDescription = "Shine like a star";    
                }
                break;
            case 66:
                {
                    moveName = "Shine";
                    moveType = "Useless";  
                    moveDescription = "I accidently dublicated this move three times";      
                }
                break;
            case 67:
                {
                    moveName = "Shine";
                    moveType = "Useless";  
                    moveDescription = "I accidently dublicated this move three times";      
                }
                break;
            case 68:
                {
                    moveName = "Investment";
                    moveType = "Self Heal";
                    healingValue = 10; 
                    moveDescription = "Recovers health by investing in one's self";              
                }
                break;
            case 69:
                {
                    moveName = "Brighten Up";
                    moveType = "Team Stat Change";
                    targetedStat = "Acc" ;
                    statChangeMulti = 1.6f;       
                    moveDescription = "Increases team's accuracy and motivates them\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
       
                }
                break;
            case 70:
                {
                    moveName = "Trash";
                    moveType = "Trash"; //uniqe
                    attackMulti = 0.1F;
                    moveDescription = "A weak attack that slightly damages the target and converts their stats into that of a Garbage Slime\n"+"Power: "+Math.Round(attackMulti*100)+"";

                
                }
                break;
            case 71:
                {
                    moveName = "Swallow";
                    moveType = "Attack"; 
                    attackMulti = 10.0F;    
                    moveDescription = "Swallow the target whole, they are unlikely to survive\n"+"Power: "+Math.Round(attackMulti*100)+"";
   
                }
                break;
            case 72:
                {
                    moveName = "Digest";
                    moveType = "Useless";     
                    moveDescription = "Digest the meal you've had";   
                }
                break;
             case 73:
                {
                    moveName = "Mimic";
                    moveType = "Mimic";        //uniqe
                    moveDescription = "Mimics the target's base stats";
                }
                break;
            case 74:
                {
                    moveName = "Meteor Shower";
                    moveType = "Attack Opponents"; 
                    attackMulti = 2.0F;       
                    moveDescription = "A mighty attack that will send the opponents to the way of Dino Slimes\n"+"Power: "+Math.Round(attackMulti*100)+"";

                }
                break;
            case 75:
                {
                    moveName = "Pie Throw";
                    moveType = "Attack"; 
                    attackMulti = 2.2F;     
                    moveDescription = "A delicious pie that will fly right into the target's face\n"+"Power: "+Math.Round(attackMulti*100)+"";
  
                }
                break;
            case 76:
                {
                    moveName = "Ballon Pop";
                    moveType = "Attack"; 
                    attackMulti = 0.4F;  
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";
     
                }
                break;
            case 77:
                {
                    moveName = "Clown tears";
                    moveType = "Opponents Stat Change";
                    statChangeMulti = 0.60f;
                    targetedStat = "Atk";       
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";
     
                }
                break;
            case 78:
                {
                    moveName = "Hail Storm";
                    element ="Ice";
                    moveType = "Attack Opponents"; 
                    attackMulti = 2.0F;     
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";
  
                }
                break;
            case 79:
                {
                    moveName = "Lightning Strike";
                    element = "Lightning";
                    moveType = "Attack"; 
                    attackMulti = 3F;     
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";
  
                }
                break;
            case 80:
                {
                    moveName = "Mighty Winds";
                    moveType = "Team Stat Change";
                    targetedStat = "Spd" ;
                    statChangeMulti = 1.5f;    
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
 
         
                }
                break;
            case 81:
                {
                    moveName = "Shell Crack";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.4F;       
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";

                }
                break;
            case 82:
                {
                    moveName = "Tentacle Wrap";
                    moveType = "Attack"; 
                    attackMulti = 1.8F;    
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";
   
                }
                break;
            case 83:
                {
                    moveName = "Camouflage";
                    moveType = "Self Stat Change";   
                    statChangeMulti=2.5f;   
                    targetedStat = "Atk" ;   
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
     
                }
                break;
            case 84:
                {
                    moveName = "Inky Escape";
                    moveType = "Stat Change N"; 
                    targetedStat = "Acc";      
                    statChangeMulti = 0.8f;  
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Decrease: "+(Math.Round(statChangeMulti*100) - 100)+"%";

                }
                break;
            case 85:
                {
                    moveName = "Forage";
                    moveType = "Forage";   //uniqe
                    statChangeMulti=1.4f;   
                    targetedStat = "Atk" ;   
                    healingValue = 8;    
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Increase: "+(Math.Round(statChangeMulti*100) - 100)+"%";
 
                }
                break;
            case 86:
                {
                    moveName = "Claw";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.6F;     
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";
  
                }
                break;
            case 87:
                {
                    moveName = "Alchemy";
                    moveType = "Alchemy"; //uniqe     
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n";

                }
                break;
            case 88:
                {
                    moveName = "Bounce";
                    moveType = "Attack Opponents"; 
                    attackMulti = 0.8F;  
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";
     
                }
                break;
            case 89:
                {
                    moveName = "Belly Slam";
                    moveType = "Attack"; 
                    attackMulti = 1.8F;       
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n"+"Power: "+Math.Round(attackMulti*100)+"";

                }
                break;
            case 90:
                {
                    moveName = "Snack Time";
                    moveType = "Self Heal"; 
                    healingValue = 4;      
                    moveDescription = "This move is used by a boss, you shouldn't be able to read this\n";

                }
                break;
            case 91:
                {
                    moveName = "Second Act";
                    moveType = "Full Heal"; 
                    healingValue = 15;     
                    moveDescription = "Greatly recovers health\n";
 
                }
                break;

            


            default:
                    moveName = "Struggle";
                    moveType = "Useless";
                    moveDescription = "It's not the Slime that's struggling, it's the developers\n";
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