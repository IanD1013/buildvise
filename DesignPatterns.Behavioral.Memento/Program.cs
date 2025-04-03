// client

using DesignPatterns.Behavioral.Memento;

TextBox textBox = new();
TextHistory textHistory = new();

textBox.SetText("Hello");
textHistory.Backup(textBox.Save());

textBox.SetText("Hello, World!");
textHistory.Backup(textBox.Save());

Console.WriteLine($"Current text: {textBox.GetText()}"); // hello world 

textHistory.Undo(textBox);
Console.WriteLine($"After undo: {textBox.GetText()}"); // hello

textHistory.Undo(textBox);
Console.WriteLine($"After second undo: {textBox.GetText()}"); // hello

textHistory.Redo(textBox);
Console.WriteLine($"After first redo: {textBox.GetText()}");