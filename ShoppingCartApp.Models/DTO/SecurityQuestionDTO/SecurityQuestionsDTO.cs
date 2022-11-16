using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.DTO.SecurityQuestionDTO
{
    public class SecurityQuestionsDTO : EntityDTO<string>
    {
        public string Questions { get; set; }
        public SecurityQuestions ConvertToModel()
        {
            SecurityQuestions questions = new SecurityQuestions();
            questions.Id = Id;
            questions.Questions = Questions;
            questions.IsActive = IsActive;
            return questions;
        }
    }

    public class AddSecurityQuestionsDTO : AddEntityDto<string>
    {
        public string Questions { get; set; }
        public SecurityQuestions ConvertToModel()
        {
            SecurityQuestions questions = new SecurityQuestions();
            questions.Id = Id;
            questions.Questions = Questions;
            questions.IsActive = IsActive;
            return questions;
        }
    }

    public class UpdateSecurityQuestionsDTO : UpdateEntityDtO<string>
    {
        public string Questions { get; set; }
        public SecurityQuestions ConvertToModel()
        {
            SecurityQuestions questions = new SecurityQuestions();
            questions.Id = Id;
            questions.Questions = Questions;
            questions.IsActive = IsActive;
            return questions;
        }
    }
}
