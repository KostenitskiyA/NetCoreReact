namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ получения группы
    /// </summary>
    public class GetGroupResponce
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; } = string.Empty;
    }
}
