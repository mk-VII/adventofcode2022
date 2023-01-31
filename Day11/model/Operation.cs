namespace Day11.Model;

public class Operation {
    private string _operator;
    private string _value;

    public Operation(string op, string value)
    {
        _operator = op;
        _value = value;
    }

    public int Perform(Item item) => _operator switch {
        "+" => item.WorryLevel + GetValueToUpdateBy(item.WorryLevel),
        "-" => item.WorryLevel - GetValueToUpdateBy(item.WorryLevel),
        "*" => item.WorryLevel * GetValueToUpdateBy(item.WorryLevel),
        "/" => item.WorryLevel / GetValueToUpdateBy(item.WorryLevel),
        _ => throw new ArgumentOutOfRangeException("not a valid operator")
    };

    private int GetValueToUpdateBy(int worryLevel) => 
        _value.Equals("old") 
            ? worryLevel 
            : int.Parse(_value);
}