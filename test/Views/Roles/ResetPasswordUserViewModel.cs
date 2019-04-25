using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test.Views.Roles
{
    public class ResetPasswordUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан новый пароль")]
        [StringLength(100, ErrorMessage = "{0} должен содержать не менее {2} и не более {1} символов.", MinimumLength = 6)]
        [RegularExpression(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]*", ErrorMessage = "Пароль должен содержать:\r\n -хотя бы одно число;\r\n -хотя бы один спецсимвол !@#$%^&*; \r\n -хотя бы одну латинскую букву в нижнем регистре; \r\n -хотя бы одну латинскую букву в верхнем регистре.")]

        public string NewPassword { get; set; }
    }
}
