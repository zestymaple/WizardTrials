using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty_settings : MonoBehaviour
{
    public int diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = PlayerPrefs.GetInt("game.difficulty");

    }

    public int get_health(Enemies i)

    {
        int health = 0;

        switch (diff)
        {
            case 0: //easy

                switch (i)
                {
                    case Enemies.Skeleton:
                        health = 100;
                        break;
                    case Enemies.Boss:
                        health = 1000;
                        break;
                    case Enemies.Slime:
                        health = 50;
                        break;
                    case Enemies.Mage:
                        health = 100;
                        break;
                    case Enemies.Djinn:
                        health = 50;
                        break;
                }                  
                break;

            case 1: //med
                switch (i)
                {
                    case Enemies.Skeleton:
                        health = 150;
                        break;
                    case Enemies.Boss:
                        health = 1500;
                        break;
                    case Enemies.Slime:
                        health = 75;
                        break;
                    case Enemies.Mage:
                        health = 150;
                        break;
                    case Enemies.Djinn:
                        health = 75;
                        break;
                }
                break;

            case 2: //hard
                switch (i)
                {
                    case Enemies.Skeleton:
                        health = 200;
                        break;
                    case Enemies.Boss:
                        health = 2000;
                        break;
                    case Enemies.Slime:
                        health = 100;
                        break;
                    case Enemies.Mage:
                        health = 200;
                        break;
                    case Enemies.Djinn:
                        health = 100;
                        break;
                }
                break;
        }
        return health;
    }

    public enum Enemies
    {
        Skeleton,
        Boss,
        Slime,
        Mage,
        Djinn
    }


}
