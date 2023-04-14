using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TutorialsTeacher_MVC.Models
{

    public class Student
    {

        [Key]
        public int StudentId { get; set; }

        [Display(Name = "Student name")]
        [Required(ErrorMessage = "Please enter name")]
        public string StudentName { get; set; }
        
        [Required(ErrorMessage = "Please write Age")]
        [RegularExpression("[0-9]+")]
        public int Age { get; set; }
        public bool IsActive { get; set; }

        public string Gender { get; set; }

        public string[] Genders = new[] { "Male", "Female" };

        public string[] NewGendersArray = new[] { "Male", "Female", "Not Specified" };
        public string[] NewGender { get; set; }
        public List<SelectListItem> NewGenders { get { 
            return NewGendersArray.Select(a =>
            new SelectListItem
            {
                Value = a,
                Text = a
            }).ToList();
            }
            set { }
        }

        //TODO: learn handling with OnGet handler
/*        public void OnGet()
        {
            NewGenders = NewGendersArray.Select(a =>
            new SelectListItem
            {
                Value = a,
                Text = a
            }).ToList();
        }*/
        public WeekDay FavouriteWeekday { get; set; }

        public string Password { get; set; }

        public Student()
        {
            Gender = "Male";
            NewGender = new string[] { "Male" };
            FavouriteWeekday = WeekDay.Wednesday;
        }
    }

    public enum WeekDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday
    }
}
