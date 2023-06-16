// See https://aka.ms/new-console-template for more information

using PipesNewVersion;

Console.WriteLine("Hello, World!");
Console.OutputEncoding = System.Text.Encoding.UTF8;

var board = new Board(10,5);
board.DrawBoard();

while (true)
{
    board.userinput();

}
