using ConsoleFluentValidationListParameter.Model;
using ConsoleFluentValidationListParameter.Validator;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace ConsoleFluentValidationListParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentListValidator validations = new StudentListValidator();
            var model = new StudentInformationCollectionModel { StudentInformationList = GetStudentLessonList() };
            ValidationResult result = validations.Validate(model);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    item.FormattedMessagePlaceholderValues.TryGetValue("CollectionIndex", out object index);
                    Console.WriteLine((int)index + 1 + ". satırdaki " + item.ErrorMessage);
                }
            }
            Console.ReadLine();
        }
        private static List<StudentInformationModel> GetStudentLessonList()
        {
            List<StudentInformationModel> list = new List<StudentInformationModel>();

            list.Add(new StudentInformationModel { Name = "Mehmet Akif", Surname = "Vuruc1u", Age = 40, Gender = "Erkek", Email = "mehmetakif@gmail.com", PhoneNumber = "5553332211" });
            list.Add(new StudentInformationModel { Name = "Hasan", Surname = "Mutlu", Age = 45, Gender = "Erkek", Email = "hasan", PhoneNumber = "5332223366" });
            list.Add(new StudentInformationModel { Name = "", Surname = "Dogan", Age = 40, Gender = "Kadın", Email = "cansu@com", PhoneNumber = "5442221100" });
            list.Add(new StudentInformationModel { Name = "Ziya", Surname = "Kaya", Age = 40, Gender = "Erkek", Email = "ziya@gmail.com", PhoneNumber = "5351111111" });
            list.Add(new StudentInformationModel { Name = "Müge", Surname = "Güneş", Age = 41, Gender = "Kadın", Email = "muge@gmail.com", PhoneNumber = "05432223311" });

            return list;
        }
    }
}
