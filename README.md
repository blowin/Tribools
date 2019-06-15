# Tribools

[Tribool implementation](https://en.wikipedia.org/wiki/Three-valued_logic)
***
## Examples
The tribool class supports conversion from bool values and contain Indefinitely:
```C#
var tribool = Tribool.True;
Tribool indefinitelyTribool = Tribool.Indefinitely;
Tribool trueTribool = true;
Tribool falseTribool = false;
```
Tribool supports conversions to bool for use in conditional statements:
```C#
var tribool = Tribool.True;
if (tribool)
    Console.WriteLine("Is true\n");
else if (!tribool)
    Console.WriteLine("Is false\n");
else
    Console.WriteLine("Is indefinitely\n");
```
Tribool supports the 4-state logic operators ! (negation), && (AND), and || (OR), ^ (XOR) with bool and tribool values. For instance:

```C#
var x = Tribool.True;
var y = Tribool.False;
if(x && y) // false
{
    Console.WriteLine("X and Y is true");
}
if(!(x && y)) // true
{
    Console.WriteLine("X or Y is false");
}
if(x || y) // true
{
    Console.WriteLine("X or Y is true");
}
if(x ^ y) // true
{
    Console.WriteLine("X or Y is true");
}
```
Ttribool supports 3-state equality comparisons via the operators == and !=. These return a tribool:
```C#
var x = Tribool.True;
var y = Tribool.False;
Console.WriteLine("X == true: {0}", x == true); // true
Console.WriteLine("Y == false: {0}", y == false); // true
Console.WriteLine("Y == true: {0}", y == true); // false
```
It can be checked whether the value is undefined:
```C#
var x = Tribool.True;
var y = Tribool.Indefinitely;
Console.WriteLine("X == Indefinitely: {0}", Tribool.Maybe(x)); // false
Console.WriteLine("Y == Indefinitely: {0}", Tribool.Maybe(y)); // true
```
Increase and decrease in degree ++(Up), --(Down):
```C#
var x = Tribool.True;
var y = Tribool.False;
Console.WriteLine("X++: {0}", --x); // Indefinitely
Console.WriteLine("X++: {0}", --x); // False

Console.WriteLine("Y--: {0}", ++y); // Indefinitely
Console.WriteLine("Y--: {0}", ++y); // True
```

Tables ternary logic

| A | A↗ | ↘A |
|---|----|----|
| F | U  | F  |
| U | T  | F  |
| T | T  | U  |

| A⋀ B | F | U | T |
|------|---|---|---|
| F    | F | F | F |
| U    | F | U | U |
| T    | F | U | T |

A     | ¬ A
-------- | ---
F | T
U    | U
T     | F

| A ∨ B | F | U | T |
|-------|---|---|---|
| F     | F | U | T |
| U     | U | U | T |
| T     | T | T | T |
 
| A xor B | F | U | T |
|------|---|---|---|
| F    | F | U | T |
| U    | U | U | U |
| T    | T | U | T |
