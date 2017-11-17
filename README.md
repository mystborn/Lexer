# Lexer
This library provides a simple and easy to use lexer implementation.

# License
This library uses the [MIT Lisence](https://github.com/mystborn/Lexer/blob/master/LICENSE)

# Installation
To install this library, you can use the following nuget command:

```
Install-Package Myst.LexicalAnalysis -Version 1.2.0 
```

or you can find it in the nuget package manager.

# Example
It's extremely simple to use. First, create a new `Lexer`. Then add `TokenDefinition`s to it. 
Then you can tokenize a string using that lexer. 

Hello, Parser:
```cs
var lexer = new Lexer();
lexer.AddDefinition(new TokenDefinition("hello|hi|greetings", "Greeting"));
lexer.AddDefinition(new TokenDefinition(",", "Comma"));
lexer.AddDefinition(new TokenDefinition("world", "World"));

foreach(var token in lexer.Tokenize("hello, world")) 
{
    Console.WriteLine(token);
}
```

The following is an example lexer that can be used to tokenize Context Free Grammar Productions.

```cs
lexer = new Lexer();
lexer.AddDefinition(new TokenDefinition(@"<\S+?>\s*?->", "Left"));
lexer.AddDefinition(new TokenDefinition(@"\((?:[^()]|(?<open>\()|(?<-open>\)))+(?(open)(?!))\)", "Group"));
lexer.AddDefinition(new TokenDefinition(@"<\S+?>", "NonTerminal"));
lexer.AddDefinition(new TokenDefinition(@"((?<=\s*)[a-zA-Z_][a-zA-Z0-9_]*(?=\s*))|('\S*?')", "Terminal"));
lexer.AddDefinition(new TokenDefinition(@"\?", "Question"));
lexer.AddDefinition(new TokenDefinition(@"\*", "Star"));
lexer.AddDefinition(new TokenDefinition(@"\+", "Plus"));
lexer.AddDefinition(new TokenDefinition(@"\|", "Or"));

foreach(var token in lexer.Tokenize("<T> -> a <T> c")) 
{
    // Perform operations using the tokens...
}
```
