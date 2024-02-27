using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_InputField inputField;
    int randomNumber;
    int maxAttempts = 3;
    int currentAttempts;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }
    
    void GameSetup()
    {
        
        randomNumber = Random.Range(1, 11);

        // Reset the current attempts to the maximum
        currentAttempts = maxAttempts;

        // Clear the input field
        inputField.text = "";

        // Set the game over flag to false
        gameOver = false;

        // Update the header text to show the remaining attempts
        header.text = "Guess a number between 1 and 10\nYou have " + currentAttempts + " attempts left";
    }

    public void SubmitGuess()
    {
        // Check if the game is over
        if (gameOver)
        {
            // Do nothing
            return;
        }

        // Check if the input field is empty
        if (inputField.text == "")
        {
            // Do nothing
            return;
        }

        // Check if the input field contains a valid number
        int guess;
        if (!int.TryParse(inputField.text, out guess))
        {
            // Do nothing
            return;
        }

        // Check if the guess is correct
        if (guess == randomNumber)
        {
            // The player has won the game
            // Update the header text to show the victory message
            header.text = "You guessed it right!\nYou win!";

            // Set the game over flag to true
            gameOver = true;
        }
        else
        {
            // The player has guessed wrong
            // Decrease the current attempts by one
            currentAttempts--;

            // Check if the player has any attempts left
            if (currentAttempts > 0)
            {
                // The player can still guess
                // Update the header text to show the remaining attempts and a hint
                header.text = "Wrong guess!\nYou have " + currentAttempts + " attempts left!";
            }
            else
            {
                // The player has no attempts left
                // Update the header text to show the loss message and the correct answer
                header.text = "You ran out of attempts!\nYou lose!\nThe correct number was " + randomNumber;

                // Set the game over flag to true
                gameOver = true;
            }
        }
    }

    public void ResetGame()
    {
        // Call the GameSetup method to restart the game
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText()
    {
        header.text = "I'm thinking of a number between 1 and 10! You have 3 guesses.";
    }

    public void DestroyCanvas()

    {
        Destroy(gameObject);
    }
}
