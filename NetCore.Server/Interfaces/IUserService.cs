﻿using NetCore.Server.Models;

namespace NetCore.Server.Interfaces
{
    /// <summary>
    /// Провайдер авторизации
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="user">Пользователь для регистрации</param>
        /// <returns>Авторизированный пользователь</returns>
        public Task<Account> SignInAsync(User user);

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Авторизированный пользователь</returns>
        public Task<Account> LogInAsync(int userId);

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="user">Данные пользователя для входа</param>
        /// <returns>Авторизированный пользователь</returns>
        public Task<Account> LogInAsync(User user);
    }
}
