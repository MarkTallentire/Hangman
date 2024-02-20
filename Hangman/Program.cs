

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


    public void Game()
    {
        var inputOutput = new InputOutput(_word, _guesses);
        
        while (_numberOfGuesses <= 5)
        {
            inputOutput.Render();
            
            var guess = inputOutput.GetGuess();
            _guesses.Add(guess);
            
            inputOutput.Render();
            if (CheckIfWon())
            {
                Console.WriteLine("You're winner!");
                Environment.Exit(0);
            };

            if (!CheckGuess(guess)) _numberOfIncorrectGuesses++;
            _numberOfGuesses++;
        }
        
        Console.WriteLine("You Lose");
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
    private string _word;
    private List<char> _guesses;
    
    public InputOutput(string word, List<char> guesses)
    {
        _word = word;
        _guesses = guesses;
    }

    public char GetGuess()
    {
        Console.Write("Your guess:");
        return Console.ReadKey(true).KeyChar;
    }
    
    public void Render()
    {
        Console.Clear();
        for (int i = 0; i < _word.Length; i++)
        {
            if(_guesses.Contains(char.ToLower(_word[i])))
                Console.Write(_word[i]);
            else
                Console.Write("_");
            
            if(i != _word.Length - 1)
                Console.Write(" ");
        }
        
        Console.WriteLine();
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