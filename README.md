# OcuCount.NET
OcuCount.NET is a class designed to count the occurences of words in a string. It is designed to be easy to use and simple to implement.

## Basic Use

To start off, try the following.

```C#
//Ensure this is at the top of your code
using ocucount.Counter;

//Use this where needed
Counter c = new Counter("To start off, try the following. It's a start.")
//c.dict will give you your current values but that's not exactly what we want to do. The following will output 2 to the console.
console.WriteLine(c.getWordCount("start").num)
```
## Comparing to words
The following will return the difference between the usage of 2 words.
```C#
int diff = c.compareWords("start","try")
console.WriteLine(diff)
```


## Converting to JSON
For the purposes of feature parity with the Node JS version, you can convert your count to JSON with the following.
```C#
string s = c.ToJSONString()
console.WriteLine(s)
```
