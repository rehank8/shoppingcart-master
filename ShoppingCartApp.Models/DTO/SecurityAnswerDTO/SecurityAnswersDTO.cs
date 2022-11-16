using ShoppingCartApp.Models.DTO.Common;
using ShoppingCartApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.DTO.SecurityAnswerDTO
{
    public class SecurityAnswersDTO : EntityDTO<string>
    {
        public string Answers { get; set; }
        public string FKQuestionId { get; set; }
        public SecurityAnswers ConvertToModel()
        {
            SecurityAnswers answers = new SecurityAnswers();
            answers.Id = Id;
            answers.Answers = Answers;
            answers.IsActive = IsActive;
            answers.FKQuestionId = FKQuestionId;
            return answers;
        }
    }

    public class AddSecurityAnswersDTO : AddEntityDto<string>
    {
        public string Answers { get; set; }
        public string FKQuestionId { get; set; }
        public SecurityAnswers ConvertToModel()
        {
            SecurityAnswers answers = new SecurityAnswers();
            answers.Id = Id;
            answers.Answers = Answers;
            answers.IsActive = IsActive;
            answers.FKQuestionId = FKQuestionId;
            return answers;
        }
    }

    public class UpdateSecurityAnswersDTO : UpdateEntityDtO<string>
    {
        public string Answers { get; set; }
        public string FKQuestionId { get; set; }
        public SecurityAnswers ConvertToModel()
        {
            SecurityAnswers answers = new SecurityAnswers();
            answers.Id = Id;
            answers.Answers = Answers;
            answers.IsActive = IsActive;
            answers.FKQuestionId = FKQuestionId;
            return answers;
        }
    }
}
