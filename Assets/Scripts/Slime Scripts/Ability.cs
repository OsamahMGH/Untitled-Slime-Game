public class Ability{
    public int abilityID;
    public string name = "Ability";

    string condition = "When does this ability activate?";
    public bool isActive = false;
    public string abilityDescription = "This is an ability";

    public Ability(int iD){
        abilityID = iD;
    }

    public bool activateAbility(){

        switch(condition){

            case "if Hit":

                break;

        }

        return true;
    }
}