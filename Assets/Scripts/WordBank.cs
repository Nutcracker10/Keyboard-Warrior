using System.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    private List<string> easyWords = new List<string>() {
        "Pancake", "Are", "Delicious"
    };
    private List<string> mediumWords = new List<string>() {

    };
    private List<string> hardWords = new List<string>() {

    };

    private List<string> words = new List<string>() {};

    private List<string> workingWords = new List<string>();

    public enum Difficulties { Easy, Medium, Hard};
    public static Difficulties difficulty = Difficulties.Easy;

   private void Awake() {
       
        switch(SettingsMenu.difficulty) {

            case SettingsMenu.Difficulties.Easy:
                words = loadFile("/easy.txt");
                break;
            
            case SettingsMenu.Difficulties.Medium:
                words = loadFile("/medium.txt");
                break;

            case SettingsMenu.Difficulties.Hard:
                words = loadFile("/hard.txt");
                break;

            default:
                words = loadFile("/easy.txt");
                break;
        }

        workingWords.AddRange(words);
        shuffle(workingWords);
        toLower(workingWords);
   }

// Loads word selection for player
   private List<string> loadFile(string fileName) {
        string[] dict = System.IO.File.ReadAllLines(Application.streamingAssetsPath + fileName);        
        List<string> list = new List<string>(dict);
        return list;
   }

    private void shuffle(List<string> list) {
        for (int i=0; i<list.Count; i++){
            int random = Random.Range(i, list.Count);
            string temp = list[i];

            list[i] = list[random];
            list[random] = temp;
        }
    }

    private void toLower(List<string> list) {
        for(int i=0; i < list.Count; i++) {
            list[i] = list[i].ToLower();
        }
    }

    public string getWord() {
        string newWord = string.Empty;

        if (workingWords.Count != 0) {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }

        return newWord;
    }
}
