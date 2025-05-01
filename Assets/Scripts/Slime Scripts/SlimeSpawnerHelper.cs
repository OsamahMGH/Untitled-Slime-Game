
using UnityEngine;



public class SlimeSpawnerHelper : MonoBehaviour
{
    public GameObject waterSlime;
    public GameObject rockSlime,magmaSlime,grassSlime,iceSlime,fungalSlime,
    sandySlime,cloudySlime,electricSlime,muddySlime,bubblySlime,poisonSlime,woenOutSlime,
    snowySlime,incenseSlime,smokySlime,oilySlime,metalSlime,ashySlime,bombSlime,oakySlime,
    magicSlime,bunnySlime,honeySlime,jamySlime,iceCreamSlime,coralSlime,goldenSlime,pyriteSlime,
    luminousSlime,garbageSlime,hungrySlime,mimicSlime,cosmicSlime,clownSlime,stormySlime,octoSlime,
    inkSlime,bearSlime,arcaneSlime,largeSlime,averageSlime,miniSlime;
    public Vector3 fall0,fall1,fall2,fall3,
    winter0,winter1,winter2,winter3,
    forest0,forest1,forest2,forest3,
    city0,city1,city2,city3,
    island0,island1,island2,island3;
    //string str = "test";
    GameObject s0,s1,s2,s3;


    public void spawnSlime(int id, int pos,string stage){

        switch(stage){

            case "Forest":
                switch(pos){
                    case 0:
                        s0 = spawnSlime(id,forest0);
                        break;
                    case 1:
                        s1 = spawnSlime(id,forest1);
                        break;
                    case 2:
                        s2 = spawnSlime(id,forest2);
                        break;
                    case 3:
                        s3 = spawnSlime(id,forest3);
                        break;
                }
                break;

            case "Fall":
                switch(pos){
                    case 0:
                        s0 = spawnSlime(id,fall0);
                        break;
                    case 1:
                        s1 = spawnSlime(id,fall1);
                        break;
                    case 2:
                        s2 = spawnSlime(id,fall2);
                        break;
                    case 3:
                        s3 = spawnSlime(id,fall3);
                        break;
                }
                break;

                case "Winter":
                switch(pos){
                    case 0:
                        s0 = spawnSlime(id,winter0);
                        break;
                    case 1:
                        s1 = spawnSlime(id,winter1);
                        break;
                    case 2:
                        s2 = spawnSlime(id,winter2);
                        break;
                    case 3:
                        s3 = spawnSlime(id,winter3);
                        break;
                }
                break;

                case "Island":
                switch(pos){
                    case 0:
                        s0 = spawnSlime(id,island0);
                        break;
                    case 1:
                        s1 = spawnSlime(id,island1);
                        break;
                    case 2:
                        s2 = spawnSlime(id,island2);
                        break;
                    case 3:
                        s3 = spawnSlime(id,island3);
                        break;
                }
                break;

                 case "City":
                switch(pos){
                    case 0:
                        s0 = spawnSlime(id,city0);
                        break;
                    case 1:
                        s1 = spawnSlime(id,city1);
                        break;
                    case 2:
                        s2 = spawnSlime(id,city2);
                        break;
                    case 3:
                        s3 = spawnSlime(id,city3);
                        break;
                }
                break;


        }
    }
    public GameObject spawnSlime(int id,Vector3 vec){
        //Debug.Log(str);



        switch(id){
                    case 1:
                        return SlimeSpawner.spawn(waterSlime,forest1);
                          //vec, transform.rotation);
                }
            
            
            return SlimeSpawner.spawn(waterSlime,forest1);//erase

    }


}
