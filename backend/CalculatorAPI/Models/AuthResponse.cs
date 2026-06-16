namespace CalculatorAPI.Models
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public int UserIndex { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UName { get; set; }
    }
}
