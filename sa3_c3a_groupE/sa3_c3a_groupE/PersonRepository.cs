using System;
using System.Collections.Generic;
using System.Text;
using sa3_c3a_groupE.Models;
using SQLite;

namespace sa3_c3a_groupE
{
    public class PersonRepository
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }
        private string person_firstName;
        private string person_lastName;
        private int person_age;
        private string person_gender;
        private string person_inital_height;
        private string person_converted_height;
        private string person_initial_weight;
        private string person_converted_weight;
        private string person_inital_salary;
        private string person_converted_salary;


        public PersonRepository(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Person>();
        }

        public void basicInfo(string last, string first, int age, string gender)
        {
            person_lastName = last;
            person_firstName = first;
            person_age = age;
            person_gender = gender;
        }

        public void getHeight(string initial, string converted)
        {
            person_inital_height = initial;
            person_converted_height = converted;
        }

        public void getWeight(string initial, string converted)
        {
            person_initial_weight = initial;
            person_converted_weight = converted;
        }

        public void getSalary(string initial, string converted)
        {
            person_inital_salary = initial;
            person_converted_salary = converted;
        }

        public void AddNewPerson()
        {
            int result = 0;
            try
            {
                result = conn.Insert(new Person
                {
                    FirstName = person_firstName,
                    LastName = person_lastName,
                    Age = person_age,
                    Gender = person_gender,
                    InitialHeight = person_inital_height,
                    InitialWeight = person_initial_weight,
                    InitialSalary = person_inital_salary,
                    ConvertedHeight = person_converted_height,
                    ConvertedWeight = person_converted_weight,
                    ConvertedSalary = person_converted_salary
                });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, person_lastName);
                //StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", person_lastName, ex.Message);
                //StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<Person> GetAllPeople()
        {
            try
            {
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }

        

    }
}
