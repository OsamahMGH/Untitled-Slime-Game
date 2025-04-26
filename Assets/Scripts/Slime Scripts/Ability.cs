public class Ability{
    public int abilityID;
    public string name = "Ability";

    string abilityType = "When does this ability activate?";
    public bool isActive = false;
    public string abilityDescription = "This is an ability";

    string elementForChecking = "None";

    Slime holder;
    public Ability(int iD, Slime abilityHolder){
        abilityID = iD;
        holder = abilityHolder;
    }

    public bool checkAbility(string triggerEvent, string element="None"){

        switch(triggerEvent){

            case "Hit With Element":
                 if (abilityType.Equals(triggerEvent) && element.Equals(elementForChecking))
                    activateAbility();
                break;
            default:
                if (abilityType.Equals(triggerEvent))
                    activateAbility();
                break;

        }

        return true;
    }

    //for abilities that affect another slime
    public bool checkAbility(string triggerEvent,Slime target, string element="None"){
   switch(triggerEvent){

            case "Hit With Element":
                 if (abilityType.Equals(triggerEvent) && element.Equals(elementForChecking))
                    activateAbility(); //pass target
                break;
            default:
                if (abilityType.Equals(triggerEvent))
                    activateAbility(); //pass target
                break;

        }

        return true;
    }

    public bool activateAbility(){ //activate each ability once the activation/trigger condition has been checked

        switch(abilityID){

            case 1:

                break;

            default:

                break;
        }

        return true;
    }
}