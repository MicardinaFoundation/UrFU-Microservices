namespace RecuperatorCore.Models
{
    public class UserAddDto
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UName { get; set; }

        /// <summary>
        /// Login пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
    }
}
