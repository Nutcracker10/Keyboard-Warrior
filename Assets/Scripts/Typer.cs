using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{

    public WordBank wordBank = null;
    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private AudioSource typing;
    private AudioSource returnSound;

    public static int score;
    public static int multiplier;

    public static int health;

    private void Start() {
        
        SetCurrentWord();

        AudioSource[] sound;
        sound = GetComponents<AudioSource>();
        typing = sound[0];
        returnSound = sound[1];

        score = 0;
        multiplier = 1;

        health = 3;
    }

    private void SetCurrentWord() {
        currentWord = wordBank.getWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string word) {
        remainingWord = word;
        wordOutput.text = remainingWord;
    }

    private void Update() {
        CheckInput();
    }

    private void CheckInput() {
        if (Input.anyKeyDown && ( ! PauseMenu.gameIsPaused )) {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1) {
                EnterLetter(keysPressed);
            }
            
        }
    }

    private void EnterLetter(string typedLetter) {
        if (IsCorrectLetter(typedLetter)) {
            RemoveLetter();
            typing.Play();

            if(IsWordComplete() ) {
                score += (100 * multiplier);

                if (multiplier != 5) {
                    multiplier++;
                }

                returnSound.Play();
                SetCurrentWord();
            }
        } else {
            multiplier = 1;
        }
    }

    private bool IsCorrectLetter(string letter) {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter() {
        string newString = remainingWord.Remove(0,1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete() {
        return remainingWord.Length == 0;
    }
}
