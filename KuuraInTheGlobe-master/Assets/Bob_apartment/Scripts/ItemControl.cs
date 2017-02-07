using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemControl : MonoBehaviour {
    public static int amountofFood;
    public static int amountofToys;
    int counter;
    // Use this for initialization
    void Start ()
    {
        //PlayerPrefs.SetInt("GivePlayerFoodAndToysCounter", counter);
        counter = PlayerPrefs.GetInt("GivePlayerFoodAndToysCounter");

        amountofFood = PlayerPrefs.GetInt("AmountofFood");
        amountofToys = PlayerPrefs.GetInt("AmountofBalls");

        //gives the player five cans of food and five balls, when he enters the game for the first time
        if (counter == 0)
        {
            PlayerPrefs.SetInt("AmountofFood", 5);
            PlayerPrefs.SetInt("AmountofBalls", 5);
            counter++;
            PlayerPrefs.SetInt("GivePlayerFoodAndToysCounter", counter);

            amountofFood = PlayerPrefs.GetInt("AmountofFood");
            amountofToys = PlayerPrefs.GetInt("AmountofBalls");

            Debug.Log("Current amount of food is " + PlayerPrefs.GetInt("AmountofFood") +
                "and the current amount of toys is " + PlayerPrefs.GetInt("AmountofBalls"));

            counter = PlayerPrefs.GetInt("GivePlayerFoodAndToysCounter");
            Debug.Log("counter is " + counter);
        }

        amountofFood = PlayerPrefs.GetInt("AmountofFood");
        amountofToys = PlayerPrefs.GetInt("AmountofBalls");

        //if the amount of food or toys is below zero those will be set to zero
        if (amountofFood < 1)
        {
            PlayerPrefs.SetInt("AmountofFood", 0);
        }

        if (amountofToys < 1)
        {
            PlayerPrefs.SetInt("AmountofBalls", 0);
        }

        amountofFood = PlayerPrefs.GetInt("AmountofFood");
        amountofToys = PlayerPrefs.GetInt("AmountofBalls");

        Debug.Log("Current amount of food is " + PlayerPrefs.GetInt("AmountofFood") +
                "and the current amount of toys is " + PlayerPrefs.GetInt("AmountofBalls"));

        counter = PlayerPrefs.GetInt("GivePlayerFoodAndToysCounter");
        Debug.Log("counter is " + counter);

    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    //adds food
    public void AddFood(int value)
    {
        amountofFood = PlayerPrefs.GetInt("AmountofFood");
        amountofFood += value;
        PlayerPrefs.SetInt("AmountofFood", amountofFood);
    }

    //adds balls
    public void AddBall(int value)
    {
        amountofToys = PlayerPrefs.GetInt("AmountofBalls");
        amountofToys += value;
        PlayerPrefs.SetInt("AmountofBalls", amountofToys);
    }

    //looses balls
    public void LoseBall(int value)
    {
        amountofToys = PlayerPrefs.GetInt("AmountofBalls");
        amountofToys -= value;
        PlayerPrefs.SetInt("AmountofBalls", amountofToys);
    }

    //looses food
    public void LoseFood(int value)
    {
        amountofFood = PlayerPrefs.GetInt("AmountofFood");
        amountofFood -= value;
        PlayerPrefs.SetInt("AmountofFood", amountofFood);
    }
}
