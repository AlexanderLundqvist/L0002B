using System;

namespace PersonalInfoRegistration
{
    // Class represents a person. It has fields for basic information about the person and methods
    // to determine if a SSN is correct and which gender the person has.
    public class person
    {
        // Fields for an instance of the class person
        public string firstName;
        public string lastName;
        public string ssn;
        private string ssnConverted;
        private int[] parsedSSN;
        public string gender;

        // Constructor method 
        public person(string firstName, string lastName, string ssn)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ssn = ssn;
            this.ssnConverted = ssn.Replace("-", "");
            this.parsedSSN = ssnToArray();
            this.gender = findGender();
            
        }

        private int[] ssnToArray ()
        {
            // Converting the string into an array for better use in algorithm
            parsedSSN = new int[this.ssnConverted.Length];
            int counter = 0;
            for (int i = 0; i < this.ssnConverted.Length; i++)
            {
                parsedSSN[i] = Convert.ToInt32(this.ssnConverted.Substring(counter, 1));
                counter++;
            }
            return parsedSSN;
        }

        public bool correctSSN ()
        {
            bool answer;

            int sum = 0;
            int temp = 0;
            for (int i = 0; i < this.parsedSSN.Length; i++)
            {
                if (i % 2 == 0)
                {
                    temp = this.parsedSSN[i] * 2;
                    // Snippet bellow is because 2 digit numbers get summed
                    if ( temp > 9 )
                    {
                        int a = temp / 10; // Get the "10th" digit
                        int b = temp % 10; // Get the first digit
                        temp = a + b;
                    }
                    sum += temp;
                }
                else
                {
                    sum += this.parsedSSN[i] * 1;
                }
            }

            if (sum % 10 == 0)
            {
                answer = true;
            }
            else
            {
                answer = false;
            }

            return answer;
        }

        private string findGender ()
        {
            int genderValue = parsedSSN[parsedSSN.Length - 2];
            string answer = "";
            if (genderValue % 2 == 0)
            {
                answer = "Female";
            }
            else
            {
                answer = "Male";
            }
            return answer;
        }

        // Standard getter methods for the fields
        public string getFirstName ()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public string getSSN()
        {
            return this.ssn;
        }
        public string getGender()
        {
            return this.gender;
        }

        //Delete this
        public int[] getSSNParsed()
        {
            return this.parsedSSN;
        }
    }
}
