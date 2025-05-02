
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
                        s2.transform.Rotate(0f,180f,0f);
                        break;
                    case 3:
                        s3 = spawnSlime(id,forest3);
                        s3.transform.Rotate(0f,180f,0f);
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
                        s2.transform.Rotate(0f,180f,0f);
                        break;
                    case 3:
                        s3 = spawnSlime(id,fall3);
                        s3.transform.Rotate(0f,180f,0f);
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
                        s2.transform.Rotate(0f,180f,0f);
                        break;
                    case 3:
                        s3 = spawnSlime(id,winter3);
                        s3.transform.Rotate(0f,180f,0f);
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
                        s2.transform.Rotate(0f,180f,0f);
                        break;
                    case 3:
                        s3 = spawnSlime(id,island3);
                        s3.transform.Rotate(0f,180f,0f);
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
                        s2.transform.Rotate(0f,180f,0f);
                        break;
                    case 3:
                        s3 = spawnSlime(id,city3);
                        s3.transform.Rotate(0f,180f,0f);
                        break;
                }
                break;


        }
    }
    public GameObject spawnSlime(int id,Vector3 vec){
        //Debug.Log(str);



        switch(id){
                    case 1:
                        return SlimeSpawner.spawn(waterSlime,vec);
                    case 2:
                        return SlimeSpawner.spawn(magmaSlime,vec);
                    case 3:
                        return SlimeSpawner.spawn(rockSlime,vec);
                    case 4:
                        return SlimeSpawner.spawn(grassSlime,vec);
                    case 5:
                        return SlimeSpawner.spawn(iceSlime,vec);
                    case 6:
                        return SlimeSpawner.spawn(cloudySlime,vec);
                    case 7:
                        return SlimeSpawner.spawn(electricSlime,vec);
                    case 8:
                        return SlimeSpawner.spawn(muddySlime,vec);
                    case 9:
                        return SlimeSpawner.spawn(snowySlime,vec);
                    case 10:
                        return SlimeSpawner.spawn(ashySlime,vec);
                    case 11:
                        return SlimeSpawner.spawn(metalSlime,vec); 
                    case 12:
                        return SlimeSpawner.spawn(fungalSlime,vec);
                    case 13:
                        return SlimeSpawner.spawn(sandySlime,vec);
                    case 14:
                        return SlimeSpawner.spawn(bubblySlime,vec);
                    case 15:
                        return SlimeSpawner.spawn(poisonSlime,vec);
                    case 16:
                        return SlimeSpawner.spawn(woenOutSlime,vec);
                    case 17:
                        return SlimeSpawner.spawn(incenseSlime,vec);
                    case 18:
                        return SlimeSpawner.spawn(smokySlime,vec);
                    case 19:
                        return SlimeSpawner.spawn(bombSlime,vec);
                    case 20:
                        return SlimeSpawner.spawn(oilySlime,vec); 
                    case 21:
                        return SlimeSpawner.spawn(oakySlime,vec); 
                    case 22:
                        return SlimeSpawner.spawn(honeySlime,vec); 
                    case 23:
                        return SlimeSpawner.spawn(jamySlime,vec); 
                    case 24:
                        return SlimeSpawner.spawn(iceCreamSlime,vec); 
                    case 25:
                        return SlimeSpawner.spawn(magicSlime,vec); 
                    case 26:
                        return SlimeSpawner.spawn(bunnySlime,vec); 
                    case 27:
                        return SlimeSpawner.spawn(coralSlime,vec); 
                    case 28:
                        return SlimeSpawner.spawn(goldenSlime,vec); 
                    case 29:
                        return SlimeSpawner.spawn(goldenSlime,vec); 
                    case 30:
                        return SlimeSpawner.spawn(luminousSlime,vec);
                    case 31:
                        return SlimeSpawner.spawn(garbageSlime,vec); 
                    case 32:
                        return SlimeSpawner.spawn(hungrySlime,vec); 
                    case 33:
                        return SlimeSpawner.spawn(mimicSlime,vec); 
                    case 34:
                        return SlimeSpawner.spawn(cosmicSlime,vec); 
                    case 35:
                        return SlimeSpawner.spawn(clownSlime,vec); 
                    case 36:
                        return SlimeSpawner.spawn(stormySlime,vec); 
                    case 37:
                        return SlimeSpawner.spawn(octoSlime,vec); 
                    case 38:
                        return SlimeSpawner.spawn(inkSlime,vec); 
                    case 39:
                        return SlimeSpawner.spawn(bearSlime,vec); 
                    case 40:
                        return SlimeSpawner.spawn(arcaneSlime,vec); 
                    case 41:
                        return SlimeSpawner.spawn(largeSlime,vec); 
                    case 42:
                        return SlimeSpawner.spawn(averageSlime,vec); 
                    case 43:
                        return SlimeSpawner.spawn(miniSlime,vec); 
                    default:
                        return SlimeSpawner.spawn(averageSlime,vec);

                }
            


    }

    public void destroySlime(int pos){

        Debug.Log("Destroy "+pos);

        switch(pos){
            case 0:
                Destroy(s0);
                break;
            case 1:
                Destroy(s1);
                break;
            case 2:
                Destroy(s2);
                break;
            case 3:
                Destroy(s3);
                break;
        }

    }
}
