using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        private string leftValue;
        private string rightValue;
        private char operation;

        public void putElement(char element)
        {
            if (isBuildingLeftValue(element))
            {
                if (leftValue == null)
                {
                    if (isDot(element) || isOperation(element))
                    {
                        return;
                    }
                    leftValue = element.ToString();
                }
                else
                {
                    if (isOperation(element))
                    {
                        operation = element;
                        return;
                    }
                    else if (isDot(element))
                    {
                        if (!leftValue.Contains('.'))
                        {
                            leftValue += element;
                        }
                    }
                    else
                    {
                        leftValue += element;
                    }
                }
            }
            else if (isBuildingRightValue(element))
            {
                if (rightValue == null)
                {
                    if (isOperation(element))
                    {
                        operation = element;
                        return;
                    }
                    else if (isDot(element))
                    {
                        return;
                    }
                    else
                    {
                        rightValue = element.ToString();
                    }
                }
                else
                {
                    if (isOperation(element))
                    {
                        return;
                    }
                    else if (isDot(element))
                    {
                        if (!rightValue.Contains('.'))
                        {
                            rightValue += element;
                        }
                    }
                    else
                    {
                        rightValue += element;
                    }
                }
            }
        }

        public void initLeftValue(string value)
        {
            leftValue = value;
        }

        private bool isOperation(char element)
        {
            return (element == '+' || element == '-' || element == '*' || element == '/');
        }

        private bool isDot(char element)
        {
            return element == '.';
        }

        private bool isBuildingLeftValue(char element)
        {
            return (operation == '\0' && rightValue == null);
        }

        private bool isBuildingRightValue(char element)
        {
            return (operation != '\0' && leftValue != null);
        }

        public string calc()
        {
            if (leftValue != null && rightValue != null && operation != '\0')
            {
                switch (operation)
                {
                    case '+':
                        return (double.Parse(leftValue) + double.Parse(rightValue)).ToString();
                    case '-':
                        return (double.Parse(leftValue) - double.Parse(rightValue)).ToString();
                    case '*':
                        return (double.Parse(leftValue) * double.Parse(rightValue)).ToString();
                    case '/':
                        return (double.Parse(leftValue) / double.Parse(rightValue)).ToString();
                    default:
                        break;
                }
            }
            return null;
        }

        public string getDisplay()
        {
            string display = null;
            if (leftValue != null)
            {
                display += leftValue;
            }
            if (operation != '\0')
            {
                display += " " + operation + " ";
            }
            if (rightValue != null)
            {
                display += rightValue;
            }
            return display == null ? "0" : display;
        }

        public void reset()
        {
            leftValue = null;
            rightValue = null;
            operation = '\0';
        }
    }
}
