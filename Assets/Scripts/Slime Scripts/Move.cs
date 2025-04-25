

public class Move{
    int moveID;
    string moveType = "Attack";
    string moveDescription = "This is a Move";
    double attackMulti = 0F;
    int healingValue = 0;
    int statChangeMulti = 0;
    string element = "None";
    string name = "Move";

    public Move(int iD){
        moveID =iD;

        switch(moveID){

            case 1:
                {
                    name = "Splash";
                    moveType = "Attack";
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
            


            default:
                    name = "Struggle";
                    moveType = "Useless";
                break;

        }
    }

    void useMove(Slime target, Slime source){

        switch(moveType){

            case "Attack":
                target.takeDamage((int) (source.currentAttack * attackMulti));
                break;

            case "Self Heal":
                source.healDamage(healingValue);
                break;
            default:
                //Text: move was used, nothing happened
                break;
        }

    }

    //AOE Moves
    void useMove(Slime target,Slime target2, Slime source){

        switch(moveType){

            case "Attack Opponents":
                target.takeDamage((int) (source.currentAttack * attackMulti));
                target2.takeDamage((int) (source.currentAttack * attackMulti));
                break;

            default:
                //Text: move was used, nothing happened
                break;
        }

    }


    
}