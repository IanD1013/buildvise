using _1.Memento;

TextBox textBox = new();
TextHistory textHistory = new();

textBox.SetText("Hello");
textHistory.Backup(textBox.Save());

textBox.SetText("Hello World!");
textHistory.Backup(textBox.Save());