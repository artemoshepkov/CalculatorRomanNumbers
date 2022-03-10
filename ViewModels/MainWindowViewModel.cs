using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using CalculatorRomanNumber.Models;

namespace CalculatorRomanNumber.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string output = "";

        RomanNumber result;

        private string operation = "NoSign";

        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => Output = str);
        }

        public string Output
        {
            set
            {
                if (output == "Invalid command")
                {
                    output = "";
                    operation = "";
                }


                if (result == null)
                    initializationResult(value);


                if (operation != "NoSign")
                {
                    if (value == "+" || value == "-" || value == "*" || value == "/")
                        return;
                    CalculateRomanNumbers(value);
                }


                if (value == "+" || value == "-" || value == "*" || value == "/")
                    operation = value;
                else if (value == "=")
                {
                    output = "";
                    this.RaiseAndSetIfChanged(ref output, result.ToString());
                    return;
                }

                this.RaiseAndSetIfChanged(ref output, value);
            }
            get
            {
                return output;
            }
        }

        private void CalculateRomanNumbers(string number)
        {
            try
            {
                if (operation == "+")
                    result += RomanNumberExtend.Create(number);

                else if (operation == "-")
                    result -= RomanNumberExtend.Create(number);

                else if (operation == "*")
                    result *= RomanNumberExtend.Create(number);

                else if (operation == "/")
                    result /= RomanNumberExtend.Create(number);
            }
            catch (RomanNumberException e)
            {
                this.RaiseAndSetIfChanged(ref output, "Invalid command");
            }
            operation = "NoSign";
        }

        private void initializationResult(string firstRomanNumber)
        {
            result = RomanNumberExtend.Create(firstRomanNumber);
        }


        public ReactiveCommand<string, string> OnClickCommand { get; set; }
    }
}