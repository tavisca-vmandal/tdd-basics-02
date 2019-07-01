using System;
using System.Collections.Generic;
using System.Text; 
using System.Globalization;
namespace ConsoleCalculator
{
    public class Calculator
    {
        private double number=0;            //current number in operation
        private char lastOperator;          //last Operator encountered
        private bool setOperator=false;     //set true if opertor has occurred
        private bool isFirstOperator=true;  //keep track of first operator
        private bool isCalculated=false;    //set true if equalTo operation has occurred
        private double firstNumber=0;      //stores the first or previous number for calculation
        private string result="";          //stores result of calculation
        private bool setDot=false;         //to keep track if dot operator has occurred already  
        private StringBuilder input=new StringBuilder();//stores the key presses as string

        private Boolean IsDot(char key)
        {
            if(key.Equals('.'))
                return true;
            else
                return false;
        }
        private Boolean IsDigit(char key)
        {
            int digit = key-'0';
            if(digit>=0&&digit<=9)
                return true;
            else
                return false;
        }
        private Boolean IsOperator(char key)
        {
            if(key.Equals('+')||key.Equals('-')||key.Equals('/')||key.Equals('x')||key.Equals('X'))
                return true;
            else
                return false;
        }
         private Boolean IsEqualOperator(char key)
        {
            
            if(key.Equals('='))
                return true;
            else
                return false;
        }
        private Boolean IsToggle(char key)
        {
            if(key.Equals('s')||key.Equals('S'))
                return true;
            else
                return false;
        }
        private string ToggleNumber()
        {
            number=number*(-1);
            return number.ToString();
        }
        private Boolean IsClear(char key)
        {
            if(key.Equals('c')||key.Equals('C'))
                return true;
            else
                return false;
        }
        private string ResetCalculator()//reset all variables to initial value
        {
            firstNumber=0;
            number=0;
            setOperator=false;
            isFirstOperator=true;
            setDot=false;
            input.Clear();
            result="";
            return "0";
        }
        private string Addition(double firstNumber,double secondNumber)
        {
            return (firstNumber+secondNumber).ToString();
        }

        private string Substraction(double firstNumber,double secondNumber)
        {
            return (firstNumber-secondNumber).ToString();
        }

        private string Multiplication(double firstNumber,double secondNumber)
        {
            return (firstNumber*secondNumber).ToString();
        }

        private string Division(double firstNumber,double secondNumber)
        {
            return (firstNumber/secondNumber).ToString();
        }

        private string  Operation()
        {
            if(lastOperator.Equals('+'))
            {
                return  Addition(firstNumber,number);
            }
            else if(lastOperator.Equals('-'))
            {
                return  Substraction(firstNumber,number);
            }
            else if(lastOperator.Equals('/'))
            {
                if(number==0)   //Error handling if divisor is 0
                     return "-E-";
  
                else
                     return  Division(firstNumber,number); 
            }
            else
            {
                return  Multiplication(firstNumber,number);  
            }
                 
        }
        private string DetermineNumber(char key)//determine the number after multiple key presses
        {
            if(setOperator||isCalculated)//if Operator is Set that means new number is entered 
                input.Clear();  //clear the old number
        
            input.Append(key.ToString());//appends the key press to stringBuilder as string
            number = double.Parse(input.ToString(), CultureInfo.InvariantCulture);//converts to double for calculation 
            setOperator=false;//new number is proccessed so SetOpertor is false
            isCalculated=false;
            return input.ToString();
        }
        private string OperationOnOperator(char key)
        {
            setDot=false;//if opertor is pressed so last number and its dot shoud be reset
            lastOperator=key;//stores the operator
            setOperator=true;
            if(isFirstOperator==true)//if first operator is encountered 
            {
                isCalculated=false;
                firstNumber=number; //firstNumber is the initial number entered
                isFirstOperator=false;//isfirstOperator is reset
                return number.ToString();
            }
            else if(isCalculated||setOperator)//if operator is pressed just after equalTo 
            {
                isCalculated=false;
                return firstNumber.ToString();//firstNumber stores the result of last operation
            }
            else    //to handle consecutive operation
            {
                isCalculated=false;
                result = Operation();
                firstNumber=Convert.ToDouble(result);//stores the result as firstnumber for next operation
                return result;
            }                     
        }
        private string EqualToOperation()
        {
            setDot=false; 
            if(isCalculated) //to handle consecutive equalTo
                return result;//just return the last result 
            if(setOperator) // to handle equalTo just after operator
                number=firstNumber;    
            result = Operation();
            if(number==0)//to eliminate exception case,result returns "=E=" which cannot be converted to double
                 return result;
            firstNumber=Convert.ToDouble(result);
            setOperator=false;
            isCalculated=true;
            return result;
        }

        public string SendKeyPress(char key)
        {
           if(IsDot(key))
            {
                if(!setDot)
                {
                   setDot=true;
                   result = DetermineNumber(key);
                }
                else
                    result = number.ToString();

                return result;    
            }
            else if(IsDigit(key))
            {
                 result=DetermineNumber(key);
                 return result;
            }
            else if(IsOperator(key))
            {
                return OperationOnOperator(key);
            }
            else if(IsEqualOperator(key))
            {
                return EqualToOperation();
            }
            else if(IsToggle(key))
            {
                setDot=false;
                return ToggleNumber();
            }
            else if(IsClear(key))
            {
                setDot=false;
                return ResetCalculator();
            }
            else //ignore all other key press
                return result;
        }
    }
}
