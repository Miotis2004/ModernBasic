using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernBasic
{

    public enum DataType
    {
        Integer,
        Float,
        String,
        Boolean
    }
    public class Variable
    {
        public DataType Type { get; set; }
        public object Value { get; set; }

        public Variable(DataType type, object value)
        {
            Type = type;
            Value = value;
        }
    }

    public class VariableStore
    {
        private Dictionary<string, Variable> variables = new Dictionary<string, Variable>();

        public void SetVariable(string name, Variable variable)
        {
            variables[name] = variable;
        }

        public Variable GetVariable(string name)
        {
            if (variables.ContainsKey(name))
            {
                return variables[name];
            }
            else
            {
                throw new Exception($"Variable '{name}' not defined.");
            }
        }

        public bool TryGetVariable(string name, out Variable variable)
        {
            return variables.TryGetValue(name, out variable);
        }
    }
}
