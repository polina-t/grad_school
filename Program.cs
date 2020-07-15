using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String[] nature = {"B1", "B2", "B3"};
            String[] options = {"A1", "A2", "A3"};
            LinkedList<State> states = new LinkedList<State>();
            states.AddLast(new State(nature[0], options[0], 5d));
            states.AddLast(new State(nature[0], options[1], 3d));
            states.AddLast(new State(nature[0], options[2], 2d));
            
            states.AddLast(new State(nature[1], options[0], 5d));
            states.AddLast(new State(nature[1], options[1], 4d));
            states.AddLast(new State(nature[1], options[2], 4d));
            
            states.AddLast(new State(nature[2], options[0], 7d));
            states.AddLast(new State(nature[2], options[1], 6d));
            states.AddLast(new State(nature[2], options[2], 8d));
            
            LinkedList<string> optionList = new LinkedList<string>();
            
            foreach (State st in states)
            {
               optionList.AddLast(st.Option);
            }
           
            LinkedList<State> last = new LinkedList<State>();
            State state;
            double alfa = 0.8d;
            double alfa_1 = 1.0d - alfa;
            //Получение лучшего и худшего состояний
             foreach (string option in options) 
             {
                 State sourceMin;
                 State sourceMax;
                 LinkedList<State> list = new LinkedList<State>(states.Where( x => String.Equals(x.Option, option)).ToList());
             
                 sourceMin = list.Min();
                 sourceMax = list.Max();
                 //Умножим на весовой коэффициент самый высокий и на весовой коэффициент-1 самый низкий.
                Double value2 = (sourceMax.Value1 * alfa) + (sourceMin.Value1 * alfa_1);
                last.AddLast(new State(sourceMin.NatureState, sourceMin.Option, value2));
            }
            state = last.Max();
            Console.WriteLine("Лучший вариант " + state.Option + " при " + state.NatureState + " с приростом " + state.Value1);
        }
    
        public class State  : IComparable{
    
            private string natureState;
           private double value1; 
             private string option;

            public int CompareTo(Object obj) {
                State otherValue = obj as State;
                return this.Value1.CompareTo(otherValue.value1);
            }

            public State(string natureState, string option, double value1)
            {
                NatureState = natureState;
                Option = option;
                Value1 = value1;
            }
            public string NatureState  
              {
                get { return natureState; }   
                set { natureState = value; }  
              }

            public string Option  
              {
                get { return option; }   
                set { option = value; }  
              }

            public double Value1   
              {
                get { return value1; }   
                set { value1 = value; }  
              }
          }
    }
}
