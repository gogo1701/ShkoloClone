using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShkoloClone.Models
{
    public class Student
    {
        //[JsonPropertyName()] before every field. It tells the JsonSerializer what name the field should have in the JSON file.
        //[JsonConverter(typeof(JsonStringEnumConverter))] before fields which use an enum type. Basically just tells the JsonSerializer to convert the enum type to a string.
        
        private int _id;
        
        private string _firstName;
        
        private string _lastName;
        
        private string _email;
        
        private string _phone;
       
        private string _address;




    }
}
