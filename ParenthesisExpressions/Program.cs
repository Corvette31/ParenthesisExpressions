using System;

namespace ParenthesisExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            char openingSymbol = '(';
            char closingSymbol = ')';
            int countOpeningSymbols = 0;
            int countClosingSymbols = 0;
            int firstOpeningSymbols = 0;
            int lastOpeningSymbols = 1;
            int attachmentLevel = 0;
            int maxAttachmentLevel = 0;
            int openClose = 1;
            int openCloseReset = 1;
            int zeroNumber = 0;
            int nexCymbol = 1;
            bool isExpressionCorrect = true;

            Console.Write("Введите строку из символов \'(\' и \')\' : ");
            userInput = Console.ReadLine();

            if (userInput[firstOpeningSymbols] == closingSymbol || userInput[userInput.Length - lastOpeningSymbols] == openingSymbol)
            {
                isExpressionCorrect = false;
            }
            else
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (userInput[i] == openingSymbol)
                    {
                        countOpeningSymbols++;
  
                        for (int j = i + nexCymbol; j < userInput.Length; j++)
                        {

                            if (userInput[j] == closingSymbol)
                            {
                                openClose--;
                            }
                            else if (userInput[j] == openingSymbol)
                            {
                                openClose++;
                            }

                            if (openClose == zeroNumber)
                            {
                                break;
                            }
                        }

                        if (openClose != zeroNumber)
                        {
                            isExpressionCorrect = false ;
                            break;
                        }

                        openClose = openCloseReset;
                        attachmentLevel++;

                        if (attachmentLevel > maxAttachmentLevel)
                        {
                            maxAttachmentLevel = attachmentLevel;
                        }
                    }

                    if (userInput[i] == closingSymbol)
                    {
                        countClosingSymbols++;
                        attachmentLevel--;
                    }
                }
            }

            if (countOpeningSymbols != countClosingSymbols)
            {
                isExpressionCorrect = false;
            }

            if (isExpressionCorrect == false)
            {
                Console.WriteLine("Введенное выражение не корректное");
            } 
            else
            {
                Console.WriteLine($"Введенное выражение корректное, максимальная глубина вложения скобок : {maxAttachmentLevel}");
            }
        }
    }
}
