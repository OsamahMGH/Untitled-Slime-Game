public class Slime {
    int speciesID;
    string speciesName="Slime";

    string speciesDescription = "This is a Slime";

    int hitPointModifier=1;
    public int maxHP=10;
    public int currentHP;
    int attackModifier=1;
    int baseAttack=1;
    public int currentAttack;
    int baseSpeed=1;
    public int currentSpeed;
    public int damageTaken=0;
    public int oozeLevel=1;
    public double accuracy=1;
    int[] moves;
    int ability = 0;
    public Slime(int iD, int oLvl=1, int dmgTaken=0){

        speciesID = iD;
        damageTaken = dmgTaken;

        switch(iD){

            case 1:
                {
                    speciesName = "Water";
                    hitPointModifier = 5;
                    attackModifier = 2;
                    baseSpeed = 3;
                    moves = new int[] {1,2,3};
                }

                break;

            case 2:
                {
                    speciesName = "Magma";
                    hitPointModifier = 4;
                    attackModifier = 3;
                    baseSpeed = 4;
                    moves = new int[] {1,2,3};
                }

                break;
            case 3:
                {
                    speciesName = "Rock";
                    hitPointModifier = 6;
                    attackModifier = 3;
                    baseSpeed = 1;
                    moves = new int[] {1,2,3};
                }

                break;
            case 4:
                {
                    speciesName = "Grass";
                    hitPointModifier = 9;
                    attackModifier = 1;
                    baseSpeed = 5;
                    moves = new int[] {1,2,3};
                }

                break;
            case 5:
                {
                    speciesName = "Ice";
                    hitPointModifier = 4;
                    attackModifier = 5;
                    baseSpeed = 4;
                    moves = new int[] {1,2,3};
                }

                break;
            case 6:
                {
                    speciesName = "Cloudy";
                    hitPointModifier = 4;
                    attackModifier = 2;
                    baseSpeed = 8;
                    moves = new int[] {1,2,3};
                }

                break;
            case 7:
                {
                    speciesName = "Electric";
                    hitPointModifier = 4;
                    attackModifier = 6;
                    baseSpeed = 7;
                    moves = new int[] {1,2,3};
                }

                break;
            case 8:
                {
                    speciesName = "Muddy";
                    hitPointModifier = 8;
                    attackModifier = 1;
                    baseSpeed = 2;
                    moves = new int[] {1,2,3};
                }

                break;
            case 9:
                {
                    speciesName = "Snow";
                    hitPointModifier = 6;
                    attackModifier = 4;
                    baseSpeed = 2;
                    moves = new int[] {1,2,3};
                }

                break;
            case 10:
                {
                    speciesName = "Ash";
                    hitPointModifier = 2;
                    attackModifier = 1;
                    baseSpeed = 5;
                    moves = new int[] {1,2,3};
                }

                break;
            default:
                    speciesName = "Water";
                    hitPointModifier = 5;
                    attackModifier = 2;
                    baseSpeed = 3;
                    moves = new int[] {1,2,3};
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

    public bool convertSlime(int newID){

        //remove this slime and create a replacement of the new species (Damage taken and O levl should be retained)

        return true;

    }
    void useMoveH(){}
    public void checkAbility(){}
    public int takeDamage(int dmg){

        return 0;
    }
    public int healDamage(int healAmount){

        return 0;
    }

    

}