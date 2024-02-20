

//Choose a random word from the dictionary.
//Display _ instead of letters
//Ask user for a letter
//If letter is in word, display letter
//If all letters found, win the game. Lose the game after 5 guesses
var hangmanGame = new HangmanGame();

public class HangmanGame
{
    private string _word;
    private List<char> _guesses = new();
    private int _numberOfGuesses = 0;
    private int _numberOfIncorrectGuesses = 0;

    public HangmanGame()
    {
        var dictionary = new Dictionary();
        var random = new Random();
        _word = dictionary.Words[random.Next(0, dictionary.Words.Count - 1)];
        Game();
    }

    private void Game()
    {
        var inputOutput = new InputOutput();
        
        while (_numberOfGuesses <= 5)
        {
            inputOutput.Render(_word, _guesses);
            
            var guess = inputOutput.GetGuess();
            _guesses.Add(guess);
            
            inputOutput.Render(_word, _guesses);
            if (CheckIfWon())
            {
                inputOutput.ShowGameWon();
            };

            if (!CheckGuess(guess)) _numberOfIncorrectGuesses++;
            _numberOfGuesses++;
        }
       inputOutput.ShowGameOver();
    }

    private bool CheckGuess(char guess)
    {
        return _guesses.Contains(guess);
    }

    private bool CheckIfWon()
    {
        for (int i = 0; i < _word.Length; i++)
        {
            if (!_guesses.Contains(char.ToLower(_word[i])))
                return false;
        }
        return true;
    }
}


public class InputOutput
{

    public char GetGuess()
    {
        Console.Write("Your guess:");
        return Console.ReadKey(true).KeyChar;
    }
    
    public void Render(string word, List<char> guesses)
    {
        Console.Clear();
        for (int i = 0; i < word.Length; i++)
        {
            if(guesses.Contains(char.ToLower(word[i])))
                Console.Write(word[i]);
            else
                Console.Write("_");
            
            if(i != word.Length - 1)
                Console.Write(" ");
        }
        
        Console.WriteLine();
    }

    public void ShowGameOver()
    {
        Console.WriteLine("You Lose");
        Environment.Exit(0);
    }

    public void ShowGameWon()
    {
        Console.WriteLine("You're winner!");
        Environment.Exit(0);
    }
}


public class Dictionary
{
    public List<string> Words { get; private set; } = new()
    {
        "Test",
        "Hangman",
        "Check",
        "Double",
    };
}