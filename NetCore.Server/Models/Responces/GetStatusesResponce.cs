namespace NetCore.Server.Models.Responces
{
    /// <summary>
    /// Ответ получения статусов
    /// </summary>
    public class GetStatusesResponce
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
